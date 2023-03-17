using LZW.Utils;

namespace LZW;

internal static class Decompressor
{
    public static (byte[],int) Decompress(byte[] bytes)
    {
        var result = new List<byte>();
        var table = InitializeTable();
        (var tableKeys,var positionBWT) = GetTableKeysAndBWTPosition(bytes);

        var tableSize = 256;
        var tablePointer = 256;

        List<byte> newPrefix;
        for (var i = 0; i < tableKeys.Length; ++i)
        {
            var key = tableKeys[i];
            if (tableSize == 65536)
            {
                table = InitializeTable();
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
        return (result.ToArray(), positionBWT);
    }

    private static Dictionary<int, List<byte>> InitializeTable()
    {
        var table = new Dictionary<int, List<byte>>();
        for (var i = 0; i < 256; ++i)
        {
            table[i] = new List<byte>()
            {
                (byte)i
            };
        }
        return table;
    }

    private static (int[], int) GetTableKeysAndBWTPosition(byte[] bytes)
    {
        var positionBWT = BitConverter.ToInt32(new byte[] {bytes[1], bytes[2], bytes[3], bytes[4]});

        var isLast = bytes[0] == 1;
        var buffer = new TableNumberBuffer();
        var tableSize = 256;
        var newBitsSizeFlag = 512;

        for (var i = 5; i < bytes.Length; ++i)
        {
            var oneByte = bytes[i];
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

            var newNumber = buffer.AddByte(oneByte, i == bytes.Length - 1 && isLast);
            if (newNumber)
            {
                tableSize++;
            }
        }

        return (buffer.Numbers.ToArray(),positionBWT);
    }
}