using Task1;


byte[] bytes = { 1,2,3,4,5};

var b = Compressor.Compress(bytes);

var c = Compressor.Decompress(b.Item1);

foreach (var item in c)
{
    Console.WriteLine(item);
}