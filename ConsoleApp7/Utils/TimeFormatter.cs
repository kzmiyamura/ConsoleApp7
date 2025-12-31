// TimeFormatter.cs
namespace ConsoleApp7.Utils
{
    public static class TimeFormatter
    {
        public static string Format(double seconds)
        {
            int minutes = (int)(seconds / 60);
            int secs = (int)(seconds % 60);
            int hundredths = (int)((seconds * 100) % 100);
            return $"{minutes:00}:{secs:00}.{hundredths:00}";
        }
    }
}