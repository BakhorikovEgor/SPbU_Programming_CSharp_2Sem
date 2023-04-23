using SkipListRealization;


var list = new SkipList<int>();
list.Add(0);
list.Add(1);
list.Add(-1);
list.Add(10);
list.Add(5);
list.Add(12);

Console.WriteLine(list.IndexOf(10));