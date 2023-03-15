using LZW;

byte[] bytes = File.ReadAllBytes("D:\\ProgrammingWay\\Spbu programming\\SPbU_Programming_2Sem_CSharp\\SPbU_Programming_CSharp_2Sem\\Homework3\\LZW\\LZW\\test.txt");
List<uint> check = Encoder.Encode(bytes);

for (int i = 0;i < 10; i++)
{
    Console.WriteLine(check[i]);
}