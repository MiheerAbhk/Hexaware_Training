
namespace VirtualArtGallery.util
{
    public class DBPropertyUtil
    {
        public static string GetPropertyString(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            var dict = lines
                .Where(line => !string.IsNullOrWhiteSpace(line) && line.Contains('='))
                .Select(line => line.Split('='))
                .ToDictionary(x => x[0].Trim(), x => x[1].Trim());

            return $"Server={dict["Server"]};Database={dict["Database"]};Trusted_Connection=True;";
        }
    }
}
