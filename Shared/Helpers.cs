namespace Shared;

public static class Helpers
{
    public static List<string> ReadInput(string path)
    {
        IEnumerable<string>? file = File.ReadLines(path) ?? throw new FileNotFoundException("File not found", path);
        return file.ToList();
        // return file.Select(l => l.Trim()).ToList();
    }

    public static Result<T> Ok<T>(T value)
    {
        return new Result<T>() { Ok = value, Err = "" };
    }

    public static Result<T> Err<T>(string error)
    {
        return new Result<T>() { Err = error };
    }

    public struct Result<T>
    {
        public T Ok { get; set; }
        public string Err { get; set; }
    }
}