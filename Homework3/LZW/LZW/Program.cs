using LZW;
using LZW.Utils;

string path = "D:\\TrashBox\\statements (2).pdf";
string path1 = "D:\\ProgrammingWay\\Spbu programming\\SPbU_Programming_2Sem_CSharp\\SPbU_Programming_CSharp_2Sem\\Homework3\\LZW\\LZW\\test1.exe";
string path2 = "D:\\ProgrammingWay\\Spbu programming\\SPbU_Programming_2Sem_CSharp\\SPbU_Programming_CSharp_2Sem\\Homework3\\LZW\\LZW\\test2.bin";
string path3 = "D:\\ProgrammingWay\\Spbu programming\\SPbU_Programming_2Sem_CSharp\\SPbU_Programming_CSharp_2Sem\\Homework3\\LZW\\LZW\\test3.pdf";
byte[] bytes = File.ReadAllBytes(path);



//byte[] BwtResult = BWT.DirectTransformation(bytes).Item1;


//(byte[] check2, bool isLast2) = Encoder.Encode(BwtResult);
//File.WriteAllBytes(path2, check2);
//Console.WriteLine("With BWT: " + ((double)new FileInfo(path).Length / new FileInfo(path2).Length));


(uint[] data,byte[] check, bool isLast) = Encoder.Encode(bytes);
File.WriteAllBytes(path1, check);
Console.WriteLine("Withount BWT: " + ((double)new FileInfo(path).Length / new FileInfo(path1).Length));
byte[] decoder = Decoder.Decode(check, isLast,data);
File.WriteAllBytes(path3, decoder);

for (int i = 0; i < decoder.Length; i++)
{
    if (decoder[i] != bytes[i])
    {
        Console.WriteLine(i);
        break;
    }
}


