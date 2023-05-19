using Task1;


byte[] bytes = { 0,0, 1,1, 2,2, 3,3, 4,4, 5,5 };

var b = Compressor.Compress(bytes);
Console.WriteLine(b.Item2);