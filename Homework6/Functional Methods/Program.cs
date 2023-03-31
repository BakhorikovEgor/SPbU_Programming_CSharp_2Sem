using Func;
Console.WriteLine(FunctionalMethods.Fold(new List<string>() {"hello","world"}, 1, (x,y) => x * y.Length));

