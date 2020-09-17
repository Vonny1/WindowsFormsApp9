using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using QuickType;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string workersite = "http://127.0.0.1:8000/sqltable/workertable";
            var workertable = JsonConvert.DeserializeObject<List<WorkerTable>>(ClassRequest.Get(workersite));
            string texttest;

            foreach (var WorkerTable in workertable)
            {
                Console.WriteLine(WorkerTable.Pk + "|" + WorkerTable.Fields.Firstname + " " + WorkerTable.Fields.Lastname + " " + WorkerTable.Fields.Patronymic);
                texttest = WorkerTable.Pk + "|" + WorkerTable.Fields.Firstname + " " + WorkerTable.Fields.Lastname + " " + WorkerTable.Fields.Patronymic;
                listBox1.Items.Add(texttest);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string workersite = "http://127.0.0.1:8000/sqltable/workerfullinfotable";
            var workerfullinfotable = JsonConvert.DeserializeObject<WorkerFullinfo[]>(ClassRequest.Get(workersite));
            string texttest;


            foreach (var WorkerFullinfo in workerfullinfotable)
            {
                texttest = WorkerFullinfo.Pk + "|" + WorkerFullinfo.Fields.Address + " " + WorkerFullinfo.Fields.Phonenumber;
                listBox1.Items.Add(texttest);

            }



            //string objecttest = workerfullinfotable[2].Pk + "|";
            //listBox1.Items.Add(objecttest);

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
