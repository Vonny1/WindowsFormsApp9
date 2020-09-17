using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickType;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Bson;
using System.Runtime;
using System.Text.Json.Serialization;
using System.IO;
using Newtonsoft.Json.Serialization;

namespace WindowsFormsApp9
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            Console.WriteLine("hello");
            //string jsonstring = File.ReadAllText("D:/C# projects/json_test/workerjson.txt");
            string workersite = "http://127.0.0.1:8000/sqltable/";
            string text = ClassRequest.Get(workersite);
            var workertable = JsonConvert.DeserializeObject<WorkerClass[]>(text);
            string texttest;


            foreach (var WorkerClass in workertable)
            {
                Console.WriteLine(WorkerClass.Pk + "|" + WorkerClass.Fields.Firstname + " " + WorkerClass.Fields.Lastname + " " + WorkerClass.Fields.Patronymic);
                texttest = WorkerClass.Pk + "|" + WorkerClass.Fields.Firstname + " " + WorkerClass.Fields.Lastname + " " + WorkerClass.Fields.Patronymic;
            }
        }
    }
}
