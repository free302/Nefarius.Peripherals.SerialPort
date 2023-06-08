using System;
using Tyrael.Driver.SerialPort;

namespace PInvokeSerialPort.Sample;

internal class Program
{
    private static void Main()
    {
        var serialPort = new SerialPort("com4") { UseRts = HsOutput.Online };
        serialPort.DataReceived += x =>
        {
            Console.Write($"{x:X2} ");
        };

        serialPort.Open();
        serialPort.Write("START\r\n");
        Console.ReadKey();
    }
}