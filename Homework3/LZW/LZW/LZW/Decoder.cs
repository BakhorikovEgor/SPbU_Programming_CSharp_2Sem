using LZW.Utils;

namespace LZW;


internal static class Decoder
{
    public static byte[] Decode(byte[] bytes)
    {
        List<byte> result = new List<byte>();

        Dictionary<uint, List<byte>> table = new Dictionary<uint, List<byte>>();
        for (uint i = 0; i < 256; ++i)
        {
            table[i] = new List<byte>()
            {
                (byte)i
            };
        }

        uint tableLength = 256;
        uint bytePointer = 0;
        List<byte> newPrefix;
        while (bytePointer < bytes.Length)
        {
            byte bytesToRead = bytes[bytePointer++];
            uint number = ByteHandler.FromByteArrayToUint(bytes, bytePointer, bytesToRead);

            if (table.ContainsKey(number))
            {
                if (bytePointer > 1)
                {
                    byte previousByte = bytes[bytePointer - 2];
                    newPrefix = new List<byte>(table[previousByte])
                    {
                       table[number][0]
                    };
                    table.Add(tableLength++, newPrefix);
                }
                result.AddRange(table[number]);
            }
            else
            {
                newPrefix = new List<byte>(table[tableLength - 1])
                {
                    table[tableLength - 1][0]
                };
                result.AddRange(newPrefix);
                table.Add(tableLength++, newPrefix);
            }

            bytePointer += bytesToRead;
        }

        return result.ToArray();
    }
    
}
