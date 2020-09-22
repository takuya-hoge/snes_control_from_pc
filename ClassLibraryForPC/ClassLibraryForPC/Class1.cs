using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace snesControlFromPc
{
    public class snesPad
    {
        // parameter
        public SerialPort serialPort;   // you can change settings.
        public int pressTime = 70;     // default time;

        public snesPad(string portNamem)
        {
            serialPort = new SerialPort(portNamem);
            serialPort.BaudRate = 9600;
        }

        public bool open()
        {
            bool ret = true;

            try
            {
                serialPort.Open();
            }
            catch
            {
                ret = false;
            }

            return ret;
        }

        // this define is input for arduino.
        public const byte BTN_B_ON = 1;
        public const byte BTN_Y_ON = 2;
        public const byte BTN_SELECT_ON = 3;
        public const byte BTN_START_ON = 4;
        public const byte BTN_UP_ON = 5;
        public const byte BTN_DOWN_ON = 6;
        public const byte BTN_LEFT_ON = 7;
        public const byte BTN_RIGHT_ON = 8;
        public const byte BTN_A_ON = 9;
        public const byte BTN_X_ON = 10;
        public const byte BTN_L_ON = 11;
        public const byte BTN_R_ON = 12;
        public const byte BTN_B_OFF = 13;
        public const byte BTN_Y_OFF = 14;
        public const byte BTN_SELECT_OFF = 15;
        public const byte BTN_START_OFF = 16;
        public const byte BTN_UP_OFF = 17;
        public const byte BTN_DOWN_OFF = 18;
        public const byte BTN_LEFT_OFF = 19;
        public const byte BTN_RIGHT_OFF = 20;
        public const byte BTN_A_OFF = 21;
        public const byte BTN_X_OFF = 22;
        public const byte BTN_L_OFF = 23;
        public const byte BTN_R_OFF = 24;
        public const byte BTN_ALL_OFF = 80;

        public void send(byte input)
        {
            byte[] data = { input, (byte)(input+12) };
            serialPort.Write(data, 0, 1);// ON
            System.Threading.Thread.Sleep(pressTime);
            serialPort.Write(data, 1, 1); // OFF
        }

        public void hadoken(byte[] input)
        {
            int read_tmp;

            serialPort.Write(input, 0, input.Length);
            read_tmp = serialPort.ReadByte();
            // Console.WriteLine(read_tmp);
        }
    }
}
