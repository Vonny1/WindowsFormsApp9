using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            string workersite = "http://127.0.0.1:8000/sqltable/";
            string text = ClassRequest.Get(workersite);
            var workertable = JsonConvert.DeserializeObject<WorkerClass[]>(text);
            string texttest;


            foreach (var WorkerClass in workertable)
            {
                Console.WriteLine(WorkerClass.Pk + "|" + WorkerClass.Fields.Firstname + " " + WorkerClass.Fields.Lastname + " " + WorkerClass.Fields.Patronymic);
                texttest = WorkerClass.Pk + "|" + WorkerClass.Fields.Firstname + " " + WorkerClass.Fields.Lastname + " " + WorkerClass.Fields.Patronymic;
                listBox1.Items.Add(texttest);
            }   
        }
    }
}
