﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gattclient
{
    class Program
    {
        static byte[] json_crap = {
0x10,  0xb5,  0xad,  0xf1,  0x28,  0x0d,  0x07,  0x91,
0x06,  0x90,  0xfc,  0xf7,  0x13,  0xf9,  0x68,  0x46,
0xfe,  0xf7,  0xfa,  0xf9,  0x00,  0x20,  0x8d,  0xf8,
0x08,  0x00,  0x64,  0x20,  0x03,  0x90,  0x00,  0x20,
0x8d,  0xf8,  0x00,  0x00,  0x64,  0x20,  0x01,  0x90,
0x0f,  0x48,  0x00,  0x78,  0x69,  0x46,  0xfc,  0xf7,
0x21,  0xf9,  0x08,  0x90,  0x08,  0x98,  0x10,  0xb9,
0x08,  0x98,  0x00,  0x28,  0xfc,  0xd0,  0x08,  0x98,
0xfe,  0xf7,  0xee,  0xfb,  0x09,  0x48,  0x00,  0x68,
0x05,  0x28,  0x0a,  0xd1,  0x09,  0x48,  0x00,  0x68,
0xfe,  0xf7,  0x38,  0xfa,  0x04,  0x46,  0x06,  0x48,
0xfe,  0xf7,  0x34,  0xfa,  0x03,  0x49,  0x00,  0x19,
0x08,  0x60,  0x0a,  0xb0,  0x10,  0xbd,  0xc0,  0x46,
0xe4,  0x00,  0x00,  0x20,  0xdc,  0x00,  0x00,  0x20,
0xc8,  0x00,  0x00,  0x20,  0xe0,  0x00,  0x00,  0x20,
0x54,  0x68,  0x69,  0x73,  0x20,  0x69,  0x73,  0x20,
0x61,  0x20,  0x73,  0x74,  0x72,  0x69,  0x6e,  0x67,
0x20,  0x6c,  0x69,  0x74,  0x65,  0x72,  0x61,  0x6c,
0x00,  0xc0,  0x46,  0xc0,  0x73,  0x79,  0x6d,  0x00,
0x54,  0x68,  0x31,  0x73,  0x20,  0x69,  0x73,  0x20,
0x61,  0x20,  0x73,  0x74,  0x72,  0x69,  0x6e,  0x67,
0x00,  0x30,  0x30,  0x30,  0x04,  0x00,  0x00,  0x00,
0x00,  0x00,  0x00,  0x00,  0x00,  0x00,  0x00,  0x00,
0x00,  0x00,  0x00,  0x00, };

        static void Main(string[] args)
        {
            //byte[] data = new byte[] { 0x33, 0x34 }; // '3'
            byte[] data = json_crap;
            int delay = 5000;

            if (args.Length == 0)
            {
            }
            switch (args.Length)
            {
                case 0:
                    System.Console.WriteLine("No path given, using the json_crap.");
                    break;
                case 1:
                    data[0] = byte.Parse(args[0]);
                    break;
                case 2:
                    //text = args[0];
                    data[0] = byte.Parse(args[0]);
                    delay = int.Parse(args[1]);
                    break;
                default:
                    Console.WriteLine("Usage: {0} [text] [delay]", System.AppDomain.CurrentDomain.FriendlyName);
                    Environment.Exit(-1);
                    break;
            }

            Bluetooth bl = new Bluetooth(delay);
            bool ret = bl.Start(data);
            Environment.Exit(ret ? 0 : -1);
        }
    }
}
