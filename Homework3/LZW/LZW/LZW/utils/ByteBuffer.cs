namespace LZW.Utils;

internal class ByteBuffer
{
    static private readonly byte BITS_IN_BITE = 8;
    public List<byte> Bytes { get; private set; }
    public int NumberBitLength {get; set; }
    private uint currentNumber;
    public byte currentByte { get; private set; }
    private uint currentByteLength;
    private uint currentNumberLength;
     

    public ByteBuffer()
    {
        NumberBitLength = 9;
        Bytes = new List<byte>();
        currentNumber = 0;
        currentByte = 0;
        currentByteLength = 0;
        currentNumberLength = 0;
}

    public void AddToEncode(uint number)
    {
        byte[] bits = BitsOfUint(number);

        int pointer = 0;
        while (currentByteLength < BITS_IN_BITE)
        {
            currentByte = (byte) ((currentByte << 1) + bits[pointer++]);
            currentByteLength++;
        }

        if (currentByteLength == BITS_IN_BITE)
        {
            AddToBufer();
            Add(bits, pointer);
        }
    }

    public uint[] TableNumbers(byte[] bytes,bool isLast)
    {
        List<uint> result = new List<uint>();

        int tableUpdateLength = 65536;
        uint currentTableSize = 256;
        uint newBitsSizeFlag = 512;
        for  (int i = 0;i < bytes.Length;++i)
        {
            byte oneByte = bytes[i];
            if (currentTableSize == newBitsSizeFlag)
            {
                newBitsSizeFlag <<= 1;
                NumberBitLength++;
            }

            if (currentTableSize == tableUpdateLength)
            {
                currentTableSize = 256;
                NumberBitLength = 9;
                newBitsSizeFlag = 512;
            }

            byte[] bits = BitsOfByte(oneByte);
            if (isLast && i == bytes.Length - 1)
            {
                bits = BitsOfByteWithoutZeros(oneByte);

            }
            foreach (byte bit in bits)
            {
                currentNumber = (currentNumber << 1) + bit;
                currentNumberLength++;

                if (currentNumberLength == NumberBitLength)
                {
                    result.Add(currentNumber);
                    currentNumber = 0;
                    currentNumberLength = 0;
                    currentTableSize++;
                }
            }
        }
        
        if (currentNumberLength != 0)
        {
            result.Add(currentNumber);
        }
        return result.ToArray();

    }

    public void AddToBufer()
    {
        Bytes.Add(currentByte);
        currentByte = 0;
        currentByteLength = 0;
    }

    private void Add(byte[] bits, int pointer)
    {
        while (currentByteLength < BITS_IN_BITE && pointer < bits.Length)
        {
            currentByte = (byte)((currentByte << 1) + bits[pointer++]);
            currentByteLength++;
        }


        if (currentByteLength == BITS_IN_BITE)
        {
            AddToBufer();
            Add(bits, pointer);
        }
    }


    private byte[] BitsOfUint(uint number)
    {
        List<byte> bits = new List<byte>();

        int bitsLength = 0;
        while (number > 0)
        {
            bitsLength++;
            bits.Add((byte)(number % 2));
            number >>= 1;
        }
        
        for (int i = 0; i < NumberBitLength - bitsLength; ++i)
        {
            bits.Add(0);
        }

        bits.Reverse();
        return bits.ToArray();
    }
    
    private byte[] BitsOfByte(byte oneByte)
    {
        byte[] bites = new byte[BITS_IN_BITE];
        for (int i = BITS_IN_BITE - 1; i >= 0; --i)
        {
            bites[i] = (byte) (oneByte % 2);
            oneByte >>= 1;
        }

        return bites;
    }

    private byte[] BitsOfByteWithoutZeros(byte oneByte)
    {
        List<byte> bites = new List<byte>();
        while (oneByte > 0)
        {
            bites.Add((byte) (oneByte % 2));
            oneByte >>= 1;
        }


        while (bites.Count + currentNumberLength < NumberBitLength)
        {
            bites.Add(0);
        }

        bites.Reverse();
        return bites.ToArray();
    }


}
