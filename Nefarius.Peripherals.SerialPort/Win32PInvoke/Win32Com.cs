﻿using System;
using System.Runtime.InteropServices;

namespace Tyrael.Driver.SerialPort.Win32PInvoke
{
    internal class Win32Com
    {

        [DllImport("kernel32.dll")]
        internal static extern Boolean GetHandleInformation(IntPtr hObject, out UInt32 lpdwFlags);

        
        [DllImport("kernel32.dll")]
        internal static extern Boolean SetCommMask(IntPtr hFile, UInt32 dwEvtMask);

        // Constants for dwEvtMask:
        internal const UInt32 EV_RXCHAR = 0x0001;
        internal const UInt32 EV_RXFLAG = 0x0002;
        internal const UInt32 EV_TXEMPTY = 0x0004;
        internal const UInt32 EV_CTS = 0x0008;
        internal const UInt32 EV_DSR = 0x0010;
        internal const UInt32 EV_RLSD = 0x0020;
        internal const UInt32 EV_BREAK = 0x0040;
        internal const UInt32 EV_ERR = 0x0080;
        internal const UInt32 EV_RING = 0x0100;
        internal const UInt32 EV_PERR = 0x0200;
        internal const UInt32 EV_RX80FULL = 0x0400;
        internal const UInt32 EV_EVENT1 = 0x0800;
        internal const UInt32 EV_EVENT2 = 0x1000;

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern Boolean WaitCommEvent(IntPtr hFile, IntPtr lpEvtMask, IntPtr lpOverlapped);

        [DllImport("kernel32.dll")]
        internal static extern Boolean CancelIo(IntPtr hFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern Boolean ReadFile(IntPtr hFile, [Out] Byte[] lpBuffer, UInt32 nNumberOfBytesToRead,
                                                out UInt32 nNumberOfBytesRead, IntPtr lpOverlapped);

        [DllImport("kernel32.dll")]
        internal static extern Boolean TransmitCommChar(IntPtr hFile, Byte cChar);

        /// <summary>
        /// Control port functions.
        /// </summary>
        [DllImport("kernel32.dll")]
        internal static extern Boolean EscapeCommFunction(IntPtr hFile, UInt32 dwFunc);

        // Constants for dwFunc:
        internal const UInt32 SETXOFF = 1;
        internal const UInt32 SETXON = 2;
        internal const UInt32 SETRTS = 3;
        internal const UInt32 CLRRTS = 4;
        internal const UInt32 SETDTR = 5;
        internal const UInt32 CLRDTR = 6;
        internal const UInt32 RESETDEV = 7;
        internal const UInt32 SETBREAK = 8;
        internal const UInt32 CLRBREAK = 9;

        [DllImport("kernel32.dll")]
        internal static extern Boolean GetCommModemStatus(IntPtr hFile, out UInt32 lpModemStat);

        // Constants for lpModemStat:
        internal const UInt32 MS_CTS_ON = 0x0010;
        internal const UInt32 MS_DSR_ON = 0x0020;
        internal const UInt32 MS_RING_ON = 0x0040;
        internal const UInt32 MS_RLSD_ON = 0x0080;

        /// <summary>
        /// Status Functions.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern Boolean GetOverlappedResult(IntPtr hFile, IntPtr lpOverlapped,
                                                           out UInt32 nNumberOfBytesTransferred, Boolean bWait);

        //Constants for lpErrors:
        internal const UInt32 CE_RXOVER = 0x0001;
        internal const UInt32 CE_OVERRUN = 0x0002;
        internal const UInt32 CE_RXPARITY = 0x0004;
        internal const UInt32 CE_FRAME = 0x0008;
        internal const UInt32 CE_BREAK = 0x0010;
        internal const UInt32 CE_TXFULL = 0x0100;
        internal const UInt32 CE_PTO = 0x0200;
        internal const UInt32 CE_IOE = 0x0400;
        internal const UInt32 CE_DNS = 0x0800;
        internal const UInt32 CE_OOP = 0x1000;
        internal const UInt32 CE_MODE = 0x8000;
        
    }
}