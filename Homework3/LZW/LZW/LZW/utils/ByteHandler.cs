namespace LZW.Utils;

public static class ByteHandler
{
    public static byte[] FromUIntToByteArray(uint number)
    {
        byte[] allBytes = BitConverter.GetBytes(number);
        List<byte> result = new List<byte>();

        int pointer = 0;
        while (allBytes.Any(x => x != 0))
        {
            result.Add(allBytes[pointer]);
            allBytes[pointer++] = 0;
        }

        return result.ToArray();
    }

    public static uint FromByteArrayToUint(byte[] bytes, uint bytePointer, byte bytesToRead)
    {
        switch (bytesToRead)
        {
            case 1:
                return BitConverter.ToUInt32(new byte[] { bytes[bytePointer], 0, 0, 0 });
            case 2:
                return BitConverter.ToUInt32(new byte[] { bytes[bytePointer], bytes[bytePointer + 1], 0, 0 });
            case 3:
                return BitConverter.ToUInt32(new byte[] { bytes[bytePointer], bytes[bytePointer + 1], bytes[bytePointer + 2], 0 });
            case 4:
                return BitConverter.ToUInt32(new byte[] { bytes[bytePointer], bytes[bytePointer + 1], bytes[bytePointer + 2], bytes[bytePointer + 3] });
            default:
                throw new Exception();
        }
    }

}