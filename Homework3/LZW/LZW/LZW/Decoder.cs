using LZW.Utils;

namespace LZW;

internal static class Decoder
{
    public static byte[] Decode(byte[] bytes,bool isLast)
    {
        List<byte> result = new List<byte>();
        Dictionary<uint, List<byte>> table = InitTable();
        ByteBuffer buffer = new ByteBuffer();

        uint[] numbers = buffer.TableNumbers(bytes,isLast);
        uint currentTableSize = 256;
        List<byte> newPrefix;
        for(uint i = 0; i < numbers.Length;++i)
        {
            uint number = numbers[i];
            if (table.ContainsKey(number))
            {
                if (i  > 0)
                {
                    newPrefix = new List<byte>(table[numbers[i - 1]])
                    {
                        table[number][0]
                    };

                    while (table.ContainsKey(currentTableSize))
                    {
                        currentTableSize++;
                    }
                    table.Add(currentTableSize++, newPrefix);
                }
                result.AddRange(table[number]);
            }
            else
            {
                newPrefix = new List<byte>(table[numbers[i - 1]])
                {
                    table[numbers[i - 1]][0]
                };
                table.Add(number, newPrefix);
                result.AddRange(newPrefix);
            }

            if(currentTableSize == 65536)
            {
                currentTableSize = 256;
                InitTable();
            }

        }   

        return result.ToArray();
    }

    private static Dictionary<uint, List<byte>> InitTable()
    {
        Dictionary<uint, List<byte>>  table = new Dictionary<uint, List<byte>>();
        for (uint i = 0; i < 256; ++i)
        {
            table[i] = new List<byte>()
            {
                (byte)i
            };
        }

        return table;
    }


}