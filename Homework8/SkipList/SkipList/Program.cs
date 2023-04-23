using SkipListRealization;


var list = new SkipList<int>();
list.Add(0);
list.Add(1);
Console.WriteLine(list.Contains(0));
Console.WriteLine(list.IndexOf(1));

