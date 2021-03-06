﻿using AlphaTab.Collections;

namespace AlphaTab.IO
{
    internal static class IOHelper
    {
        public static int ReadInt32BE(this IReadable input)
        {
            var ch1 = input.ReadByte();
            var ch2 = input.ReadByte();
            var ch3 = input.ReadByte();
            var ch4 = input.ReadByte();

            return (ch1 << 24) | (ch2 << 16) | (ch3 << 8) | ch4;
        }

        public static int ReadInt32LE(this IReadable input)
        {
            var ch1 = input.ReadByte();
            var ch2 = input.ReadByte();
            var ch3 = input.ReadByte();
            var ch4 = input.ReadByte();

            return (ch4 << 24) | (ch3 << 16) | (ch2 << 8) | ch1;
        }

        public static uint ReadUInt32LE(this IReadable input)
        {
            var ch1 = input.ReadByte();
            var ch2 = input.ReadByte();
            var ch3 = input.ReadByte();
            var ch4 = input.ReadByte();

            return Platform.Platform.ToUInt32((ch4 << 24) | (ch3 << 16) | (ch2 << 8) | ch1);
        }

        public static ushort ReadUInt16LE(this IReadable input)
        {
            var ch1 = input.ReadByte();
            var ch2 = input.ReadByte();

            return Platform.Platform.ToUInt16((ch2 << 8) | ch1);
        }

        public static short ReadInt16LE(this IReadable input)
        {
            var ch1 = input.ReadByte();
            var ch2 = input.ReadByte();

            return Platform.Platform.ToInt16((ch2 << 8) | ch1);
        }

        public static uint ReadUInt32BE(this IReadable input)
        {
            var ch1 = input.ReadByte();
            var ch2 = input.ReadByte();
            var ch3 = input.ReadByte();
            var ch4 = input.ReadByte();

            return Platform.Platform.ToUInt32((ch1 << 24) | (ch2 << 16) | (ch3 << 8) | ch4);
        }

        public static ushort ReadUInt16BE(this IReadable input)
        {
            var ch1 = input.ReadByte();
            var ch2 = input.ReadByte();

            return Platform.Platform.ToUInt16((ch1 << 8) | ch2);
        }

        public static short ReadInt16BE(this IReadable input)
        {
            var ch1 = input.ReadByte();
            var ch2 = input.ReadByte();

            return Platform.Platform.ToInt16((ch1 << 8) | ch2);
        }

        public static byte[] ReadByteArray(this IReadable input, int length)
        {
            var v = new byte[length];
            input.Read(v, 0, length);
            return v;
        }

        public static string Read8BitChars(this IReadable input, int length)
        {
            var b = new byte[length];
            input.Read(b, 0, b.Length);
            return Platform.Platform.ToString(b, "utf-8");
        }

        public static string Read8BitString(this IReadable input)
        {
            var s = new StringBuilder();
            var c = input.ReadByte();
            while (c != 0)
            {
                s.AppendChar(c);
                c = input.ReadByte();
            }

            return s.ToString();
        }

        public static string Read8BitStringLength(this IReadable input, int length)
        {
            var s = new StringBuilder();
            var z = -1;
            for (var i = 0; i < length; i++)
            {
                var c = input.ReadByte();
                if (c == 0 && z == -1)
                {
                    z = i;
                }

                s.AppendChar(c);
            }

            var t = s.ToString();
            if (z >= 0)
            {
                return t.Substring(0, z);
            }

            return t;
        }

        public static int ReadSInt8(this IReadable input)
        {
            var v = input.ReadByte();
            return ((v & 255) >> 7) * -256 + (v & 255);
        }


        public static int ReadInt24(this byte[] input, int index)
        {
            var i = input[index] | (input[index + 1] << 8) | (input[index + 2] << 16);
            if ((i & 0x800000) == 0x800000)
            {
                i = i | (0xFF << 24);
            }

            return i;
        }

        public static short ReadInt16(this byte[] input, int index)
        {
            return Platform.Platform.ToInt16(input[index] | (input[index + 1] << 8));
        }
    }
}
