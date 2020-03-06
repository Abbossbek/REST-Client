using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Http;

namespace REST_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            WebRequest req = WebRequest.Create(textBox1.Text);  //http://159.65.238.226:7777/kiosk/transaction
            req.Method = "GET";
            req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("kiosk1:kiosk2020"));
            //req.Credentials = new NetworkCredential("username", "password");
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            richTextBox1.Text= (new StreamReader(resp.GetResponseStream())).ReadToEnd();
            richTextBox1.Text= (new StreamReader(resp.GetResponseStream())).ReadToEnd();
            richTextBox1.Text= (new StreamReader(resp.GetResponseStream())).ReadToEnd();
            richTextBox1.Text= (new StreamReader(resp.GetResponseStream())).ReadToEnd();
            richTextBox1.Text= (new StreamReader(resp.GetResponseStream())).ReadToEnd();
            richTextBox1.Text= (new StreamReader(resp.GetResponseStream())).ReadToEnd();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
                WebRequest req = WebRequest.Create(textBox1.Text);
                req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("kiosk1:kiosk2020"));


                //// Set the Method property of the request to POST.
                //req.Method = "POST";
                //byte[] byteArray = Encoding.UTF8.GetBytes(richTextBox1.Text);
                //// Set the ContentType property of the WebRequest.
                //req.ContentType = "application/json";
                //// Set the ContentLength property of the WebRequest.
                //req.ContentLength = byteArray.Length;
                //// Get the request stream.
                //Stream dataStream = req.GetRequestStream();
                //// Write the data to the request stream.
                //dataStream.Write(byteArray, 0, byteArray.Length);
                //// Close the Stream object.
                //dataStream.Close();
                //// Get the response.
                //WebResponse response = req.GetResponse();
                //// Display the status.
                //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                //// Get the stream containing content returned by the server.
                //dataStream = response.GetResponseStream();
                //// Open the stream using a StreamReader for easy access.
                //StreamReader reader = new StreamReader(dataStream);
                //// Read the content.
                //string responseFromServer = reader.ReadToEnd();
                //// Display the content.
                //Console.WriteLine(responseFromServer);
                //// Clean up the streams.
                //reader.Close();
                //dataStream.Close();
                //response.Close();

                req.Method = "POST";
                var httpClient = new HttpClient();

                var postData = richTextBox1.Text;
            var content = new StringContent(postData, Encoding.UTF8, "application/json");

            var response =  httpClient.PostAsync(textBox1.Text, content);
            
            response.Result.EnsureSuccessStatusCode();

            var responseJson =  response.Result.Content.ReadAsStringAsync();
            Console.WriteLine(responseJson);
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
