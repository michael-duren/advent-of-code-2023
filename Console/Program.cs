string testPath = Paths[0].Test;
string inputPath = Paths[0].Input;

List<string> test = ReadInput(testPath).ToList();

test.ForEach(Console.WriteLine);
