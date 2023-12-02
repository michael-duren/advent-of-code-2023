namespace Shared;

public abstract class Helpers
{
        public static List<string> ReadInput(string path)
        {
            IEnumerable<string>? file = File.ReadLines(path) ?? throw new FileNotFoundException("File not found", path);
            return file.ToList();
        }
}