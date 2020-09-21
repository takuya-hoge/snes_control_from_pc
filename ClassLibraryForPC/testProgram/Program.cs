using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using snesControlFromPc;
using System.ComponentModel;

namespace testProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            randomSends player_1 = new randomSends("COM4");
            randomSends player_2 = new randomSends("COM10");

            // Using super street fighter 2.
            // Program starts when RYU appears.
            Console.WriteLine("Send Start");
            player_1.pad.send(snesPad.BTN_START_ON); // Start
            System.Threading.Thread.Sleep(1500);
            Console.WriteLine("Send Start");
            player_1.pad.send(snesPad.BTN_START_ON); // Start
            System.Threading.Thread.Sleep(700);
            Console.WriteLine("Send Down");
            player_1.pad.send(snesPad.BTN_DOWN_ON); // Down
            System.Threading.Thread.Sleep(700);
            Console.WriteLine("Send Start");
            player_1.pad.send(snesPad.BTN_START_ON); // Start
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("RYU!");
            player_1.pad.send(snesPad.BTN_A_ON); // RYU
            Console.WriteLine("KEN!");
            player_2.pad.send(snesPad.BTN_A_ON); // KEN
            System.Threading.Thread.Sleep(4000);
            Console.WriteLine("Send Start");
            player_1.pad.send(snesPad.BTN_START_ON); // Start
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Send Start");
            player_1.pad.send(snesPad.BTN_START_ON); // Start

            // randomSends
            player_1.start();
            player_2.start();

            Console.Write("**");
            int origRow = Console.CursorTop;
            int origCol = Console.CursorLeft;

            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                Console.SetCursorPosition(origCol, origRow);
                Console.Write("*");
                System.Threading.Thread.Sleep(1000);
                Console.SetCursorPosition(origCol, origRow);
                Console.Write("/");
            }
        }
    }

    class randomSends
    {
        private BackgroundWorker worker;
        public snesPad pad;

        public randomSends(string port)
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);

            pad = new snesPad(port);
            pad.open();
        }

        public void start()
        {
            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Random rand = new System.Random(20200921);
            byte data;

            while(true)
            {
                data = (byte)rand.Next(1, 12);
                if (data != snesPad.BTN_START_ON)
                {
                    pad.send(data);
                    System.Threading.Thread.Sleep(20);
                }
            }
        }
    }
}
