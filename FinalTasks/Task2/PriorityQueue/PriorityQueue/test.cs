using PriorityQueue;

PriorityQueue<int> q = new PriorityQueue<int>();

q.Enqueue(1, 10);
q.Enqueue(2, 11);
q.Enqueue(3, 12);
Console.WriteLine(q.Dequeue());
Console.WriteLine(q.Dequeue());
Console.WriteLine(q.Dequeue());
