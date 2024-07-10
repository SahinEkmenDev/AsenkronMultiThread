using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsenkronMultiThread
{
    public partial class Form1 : Form
    {

        public int counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnReadFile_Click(object sender, EventArgs e)
        {
            String data = string.Empty;
            Task<string> okuma =ReadFileAsync();

            //   string data =await  ReadFileAsync();
      

            richTextBox2.Text = await new HttpClient().GetStringAsync("https://www.google.com.tr/");
            data = await okuma;

            richTextBox1.Text = data;
        }

        private void BtnCounter_Click(object sender, EventArgs e)
        {
            textBoxCounter.Text = counter++.ToString();
        }



        private string ReadFile()
        {
            string data = string.Empty;

            using (StreamReader s = new StreamReader("Yeni Metin Belgesi.txt"))
            {

                Thread.Sleep(5000);
                data = s.ReadToEnd();

            }
            return data;

        }
        // void task
        // string task<string>

        private async Task<string> ReadFileAsync()
        {

            string data=string.Empty;
            using (StreamReader s=new StreamReader("Yeni Metin Belgesi.txt"))
            {
                 Task<string> myTask = s.ReadToEndAsync();

               await Task.Delay(5000);


                data = await myTask;

                    return data;
            }
            
        }



    }
}
