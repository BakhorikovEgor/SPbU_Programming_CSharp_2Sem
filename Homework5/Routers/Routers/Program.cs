using Routers;

string a = """
    1: 3 (4), 2 (11), 5 (6), 6 (5), 5 (3)
    2: 7 (12), 9 (10), 4 (3)
    3: 7 (7)
    4: 3 (8)
    5: 2 (12)
    6: 9 (13), 4 (5)
    7: 8 (59), 6 (3), 3 (5)
    8: 9 (5)
    """;
string configuration = ConfigurationBuilder.BuildConfiguration(a);
Console.WriteLine(configuration);