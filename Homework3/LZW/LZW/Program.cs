using LZW;
using LZW.Utils;

string path = "D:\\ProgrammingWay\\Spbu programming\\SPbU_Programming_2Sem_CSharp\\SPbU_Programming_CSharp_2Sem\\Homework3\\LZW\\LZW\\test.txt";
string path1 = "D:\\ProgrammingWay\\Spbu programming\\SPbU_Programming_2Sem_CSharp\\SPbU_Programming_CSharp_2Sem\\Homework3\\LZW\\LZW\\test1.bin";
string path2 = "D:\\ProgrammingWay\\Spbu programming\\SPbU_Programming_2Sem_CSharp\\SPbU_Programming_CSharp_2Sem\\Homework3\\LZW\\LZW\\test2.bin";
string path3 = "D:\\ProgrammingWay\\Spbu programming\\SPbU_Programming_2Sem_CSharp\\SPbU_Programming_CSharp_2Sem\\Homework3\\LZW\\LZW\\test3.exe";
byte[] bytes = File.ReadAllBytes(path);



byte[] BwtResult = BWT.DirectTransformation(bytes).Item1;


//(byte[] check2, bool isLast2) = Encoder.Encode(BwtResult);
//File.WriteAllBytes(path2, check2);
//Console.WriteLine("With BWT: " + ((double)new FileInfo(path).Length / new FileInfo(path2).Length));


(byte[] check, bool isLast) = Encoder.Encode(bytes);
File.WriteAllBytes(path1, check);
Console.WriteLine("Withount BWT: " + ((double)new FileInfo(path).Length / new FileInfo(path1).Length));


byte[] decoded = Decoder.Decode(check, isLast);
File.WriteAllBytes(path3, decoded);

for (int i = 0; i < decoded.Length; i++)
{
    if (decoded[i] != bytes[i])
    {
        Console.WriteLine(i);
        break;
    }
    Console.WriteLine(bytes[i] + " " + decoded[i]);
}

