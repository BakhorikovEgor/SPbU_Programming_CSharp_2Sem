using SkipListRealization;


var list = new SkipList<int>();
list.Add(0);
Console.WriteLine(list.Contains(0));
Console.WriteLine(list.Remove(0));
Console.WriteLine(list.Contains(0));
