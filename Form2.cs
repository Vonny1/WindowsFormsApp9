using Newtonsoft.Json;
using QuickType;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            listBox1.Items.Clear();
            var workerarrive = JsonConvert.DeserializeObject<List<WorkerArrive>>(File.ReadAllText("D:/C# projects/WindowsFormsApp9/workerarrive.txt"));
            string texttest;
            int count=-1;
            List<EffTime> effTimes = new List<EffTime>();
            foreach (var WorkerArrive in workerarrive)
            {
                texttest = WorkerArrive.Pk + " |||  Рабочий:  " + WorkerArrive.Fields.Worker + " : " + WorkerArrive.Fields.Date;
                listBox1.Items.Add(texttest);
                count++;
            }
            var workerdepart = JsonConvert.DeserializeObject<List<WorkerDepart>>(File.ReadAllText("D:/C# projects/WindowsFormsApp9/workerdepart.txt"));
            foreach (var WorkerDepart in workerdepart)
            {
                texttest = WorkerDepart.Fields.Workerarrive + " |||  " + WorkerDepart.Fields.Time.DateTime;
                listBox2.Items.Add(texttest);
            }

            
            int i = 0;
            double df, ds;
            int a = 0;
            int b = 0;
            while (i < count+1)
            {
                if (workerarrive[a].Pk == workerdepart[b].Fields.Workerarrive)
                {
                    effTimes.Add(new EffTime() { Datefirst = DateTime.Now, Datesecond = DateTime.Now, Worker = 10 });
                    effTimes[i].Datefirst = workerarrive[a].Fields.Date;
                    df = TimeSpan.FromHours(effTimes[i].Datefirst.Hour).TotalMinutes + effTimes[i].Datefirst.Minute;

                    effTimes[i].Datesecond = workerdepart[b].Fields.Time;
                    ds = TimeSpan.FromHours(effTimes[i].Datesecond.Hour).TotalMinutes + effTimes[i].Datesecond.Minute;

                    effTimes[i].Worker = workerarrive[a].Fields.Worker;
                    effTimes[i].Efftime = (ds - df) / 60;
                    texttest =workerarrive[a].Pk+" |||  Рабочий:  " +effTimes[i].Worker + "  :  " + effTimes[i].Efftime + "  часов";
                    listBox3.Items.Add(texttest);
                    i++;
                    a++;
                    b = 0;
                }
                else
                {
                    b++;

                }
            };
            
            
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            var workerarrive = JsonConvert.DeserializeObject<List<WorkerArrive>>(File.ReadAllText("D:/C# projects/WindowsFormsApp9/workerarrive.txt"));
            string texttest;
            int count = -1;
            foreach (var WorkerArrive in workerarrive)
            {
                count++;
            }

            List<WorkerArrive> list = new List<WorkerArrive>();
            list.Add(workerarrive[0]);
            var obj = JsonConvert.DeserializeObject<List<WorkerArrive>>(JsonConvert.SerializeObject(list));
            obj[0].Pk = count + 2;
            obj[0].Fields.Worker = Convert.ToInt32(numericUpDown1.Value);
            obj[0].Fields.Date = DateTime.Now;
            workerarrive.Add(obj[0]);

            foreach (var WorkerArrive in workerarrive)
            {
                texttest = WorkerArrive.Pk + "Рабочий: " + WorkerArrive.Fields.Worker + "| " + WorkerArrive.Fields.Date.Day + "." + WorkerArrive.Fields.Date.Month + " : " + WorkerArrive.Fields.Date;
                listBox1.Items.Add(texttest);
            }
            var file = JsonConvert.SerializeObject(workerarrive);
            File.WriteAllText("D:/C# projects/WindowsFormsApp9/workerarrive.txt", file);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            var workerdepart = JsonConvert.DeserializeObject<List<WorkerDepart>>(File.ReadAllText("D:/C# projects/WindowsFormsApp9/workerdepart.txt"));
            string texttest;
            int count = -1;
            foreach (var WorkerDepart in workerdepart)
            {
                count++;
            }

            List<WorkerDepart> list = new List<WorkerDepart>();
            list.Add(workerdepart[0]);
            var obj = JsonConvert.DeserializeObject<List<WorkerDepart>>(JsonConvert.SerializeObject(list));
            obj[0].Pk = count + 2;
            obj[0].Fields.Workerarrive = Convert.ToInt32(numericUpDown2.Value);
            obj[0].Fields.Time = DateTime.Now;
            workerdepart.Add(obj[0]);

            foreach (var WorkerDepart in workerdepart)
            {
                texttest = WorkerDepart.Fields.Workerarrive + "|||" + WorkerDepart.Fields.Time;
                listBox2.Items.Add(texttest);
            }   
            var file = JsonConvert.SerializeObject(workerdepart);
            File.WriteAllText("D:/C# projects/WindowsFormsApp9/workerdepart.txt", file);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void listBox2_ValueMemberChanged(object sender, EventArgs e)
        {
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
