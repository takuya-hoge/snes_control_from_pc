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
            // Please change com port.
            string p1 = "COM4";
            string p2 = "COM10";

            // Below is the test program
            if (true)//(args.Length == 2)
            {
                test2(p1, p2);
            }
            else
            {
                test1(p1, p2);
            }

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

        static void test1(string p1, string p2)
        {
            Console.WriteLine("test1 Start");

            randomSends player_1 = new randomSends(p1);
            randomSends player_2 = new randomSends(p2);

            player_1.pad.send(snesPad.BTN_ALL_OFF); // Initialization
            player_2.pad.send(snesPad.BTN_ALL_OFF); // Initialization

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
        }

        static void test2(string p1, string p2)
        {
            Console.WriteLine("test1 Start");

            hadokenSends player_1 = new hadokenSends(p1);
            hadokenSends player_2 = new hadokenSends(p2);

            player_1.pad.send(snesPad.BTN_ALL_OFF); // Initialization
            player_2.pad.send(snesPad.BTN_ALL_OFF); // Initialization
#if true
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
#endif

            player_1.start();
            player_2.start();
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

            while (true)
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

    class hadokenSends
    {
        private BackgroundWorker worker;
        public snesPad pad;

        public hadokenSends(string port)
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
            byte[] hadoken = { 90, 1,
                snesPad.BTN_DOWN_ON, 20,
                snesPad.BTN_RIGHT_ON, 20,
                snesPad.BTN_DOWN_OFF, 20,
                snesPad.BTN_RIGHT_OFF, 20,
                snesPad.BTN_Y_ON, 30,
                snesPad.BTN_Y_OFF, 0,
                snesPad.BTN_Y_OFF, 255,
                snesPad.BTN_Y_OFF, 155,
                };
            byte[] tatsumaki_senpuu_kyaku = { 90, 1,
                snesPad.BTN_DOWN_ON, 20,
                snesPad.BTN_LEFT_ON, 20,
                snesPad.BTN_DOWN_OFF, 20,
                snesPad.BTN_LEFT_OFF, 20,
                snesPad.BTN_R_ON, 20,
                snesPad.BTN_R_OFF, 0,
                snesPad.BTN_R_OFF, 255,
                snesPad.BTN_R_OFF, 155,

                };

            hadoken[1] = (byte)(hadoken.Length - 2);
            tatsumaki_senpuu_kyaku[1] = (byte)(tatsumaki_senpuu_kyaku.Length - 2);
            while (true)
            {
                pad.hadoken(hadoken);
                pad.hadoken(tatsumaki_senpuu_kyaku);
            }
        }
    }
}
