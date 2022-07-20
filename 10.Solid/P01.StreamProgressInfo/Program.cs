using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            //Examples
            File file = new File("photo", 200, 12);
            Music music = new Music("Led Zeppelin", "Physical Graffiti", 350, 23);

            StreamProgressInfo fileProgress = new StreamProgressInfo(file);
            StreamProgressInfo musicProgress = new StreamProgressInfo(music);

            Console.WriteLine(fileProgress.CalculateCurrentPercent());
            Console.WriteLine(musicProgress.CalculateCurrentPercent());
        }
    }
}
