﻿namespace Tyrael.Driver.SerialPort
{
    /// <summary>
    ///     Byte type with enumeration constants for ASCII control codes.
    /// </summary>
    public enum ASCII : byte
    {
        NULL = 0x00,
        SOH = 0x01,
        STH = 0x02,
        ETX = 0x03,
        EOT = 0x04,
        ENQ = 0x05,
        ACK = 0x06,
        BELL = 0x07,
        BS = 0x08,
        HT = 0x09,
        LF = 0x0A,
        VT = 0x0B,
        FF = 0x0C,
        CR = 0x0D,
        SO = 0x0E,
        SI = 0x0F,
        DC1 = 0x11,
        DC2 = 0x12,
        DC3 = 0x13,
        DC4 = 0x14,
        NAK = 0x15,
        SYN = 0x16,
        ETB = 0x17,
        CAN = 0x18,
        EM = 0x19,
        SUB = 0x1A,
        ESC = 0x1B,
        FS = 0x1C,
        GS = 0x1D,
        RS = 0x1E,
        US = 0x1F,
        SP = 0x20,
        DEL = 0x7F
    }
}