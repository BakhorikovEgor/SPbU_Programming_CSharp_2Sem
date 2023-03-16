using LZW;
using LZW.Utils;

string path = "D:\\TrashBox\\VerbsEnglish.xlsx";
string path1 = "D:\\ProgrammingWay\\Spbu programming\\SPbU_Programming_2Sem_CSharp\\SPbU_Programming_CSharp_2Sem\\Homework3\\LZW\\LZW\\test1.xlsx";
string path2 = "D:\\ProgrammingWay\\Spbu programming\\SPbU_Programming_2Sem_CSharp\\SPbU_Programming_CSharp_2Sem\\Homework3\\LZW\\LZW\\test3.lksx";
byte[] bytes = File.ReadAllBytes(path);



byte[] BwtResult = BWT.DirectTransformation(bytes).Item1;


(byte[] check2, bool isLast2) = Encoder.Encode(BwtResult);
File.WriteAllBytes(path1, check2);
Console.WriteLine("With BWT: " + ((double)new FileInfo(path).Length / new FileInfo(path1).Length));


(byte[] check,bool isLast) = Encoder.Encode(bytes);

byte[] check3 = Decoder.Decode(check, isLast);
byte[] check4 = Decoder.Decode(check2, isLast2);

File.WriteAllBytes(path2, check);
Console.WriteLine("Withount BWT: " + ((double)new FileInfo(path).Length / new FileInfo(path2).Length));

for (int i = 0; i < bytes.Length; ++i)
{
    Console.WriteLine(bytes[i] + " " + check3[i]);

}
