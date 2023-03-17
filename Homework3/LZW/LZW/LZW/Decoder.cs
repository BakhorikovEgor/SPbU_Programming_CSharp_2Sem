using LZW.Utils;
using System;

namespace LZW;

internal static class Decoder
{
    public static byte[] Decode(byte[] bytes, bool isLast, uint[] data)
    {
        List<byte> result = new List<byte>();
        Dictionary<uint, List<byte>> table = InitTable();

        uint[] tableKeys = GetTableKeys(bytes, isLast);
        for (int i = 0; i < tableKeys.Length; ++i)
        {
            if (data[i] != tableKeys[i])
            {
                Console.WriteLine(i);
                break;
            }
        }
        uint tableSize = 256;
        uint tablePointer = 256;
        List<byte> newPrefix;
        for (uint i = 0; i < tableKeys.Length; ++i)
        {
            uint key = tableKeys[i];
            if (tableSize == 65536)
            {
                table = InitTable();
                tableSize = 256;
                tablePointer = 256;
            }

            if (table.ContainsKey(key))
            {
                if (tableSize > 256)
                {
                    newPrefix = new List<byte>(table[tableKeys[i - 1]])
                    {
                        table[key][0]
                    };

                    while (table.ContainsKey(tablePointer))
                    {
                        tablePointer++;
                    }

                    table.Add(tablePointer++, newPrefix);
                }

                result.AddRange(table[key]);
            }
            else
            {
                newPrefix = new List<byte>(table[tableKeys[i - 1]])
                {
                    table[tableKeys[i - 1]][0]
                };

                table.Add(key, newPrefix);
                result.AddRange(newPrefix);
            }

            tableSize++;
        }

        return result.ToArray();
    }

    private static Dictionary<uint, List<byte>> InitTable()
    {
        Dictionary<uint, List<byte>> table = new Dictionary<uint, List<byte>>();
        for (uint i = 0; i < 256; ++i)
        {
            table[i] = new List<byte>()
            {
                (byte)i
            };
        }

        return table;
    }

    private static uint[] GetTableKeys(byte[] bytes, bool isLast)
    {
        TableNumberBuffer buffer = new TableNumberBuffer();

        uint tableSize = 256;
        uint newBitsSizeFlag = 512;
        int pointer = 0;
        for (int i = 0; i < bytes.Length; ++i)
        {
            byte oneByte = bytes[i];
            if (tableSize == newBitsSizeFlag)
            {
                newBitsSizeFlag <<= 1;
                buffer.CurrentNumberBitCount++;
            }

            if (tableSize == 65536)
            {
                tableSize = 256;
                newBitsSizeFlag = 512;
                buffer.CurrentNumberBitCount = 9;
            }

            bool newNumber = buffer.Add(oneByte, i == bytes.Length - 1 ? isLast : false);
            if (newNumber)
            {
                tableSize++;
            }
        }

        return buffer.Numbers.ToArray();
    }
}