using LZW;
string path = "D:\\ProgrammingWay\\Spbu programming\\SPbU_Programming_2Sem_CSharp\\SPbU_Programming_CSharp_2Sem\\Homework3\\LZW\\LZW\\test2.txt";
byte[] bytes = File.ReadAllBytes("D:\\ProgrammingWay\\SPbu programming\\SPbU_Programming_2Sem_CSharp\\SPbU_Programming_CSharp_2Sem\\Homework3\\LZW\\LZW\\test.txt");

byte[] check = Encoder.Encode(bytes);
File.WriteAllBytes(path, check);





