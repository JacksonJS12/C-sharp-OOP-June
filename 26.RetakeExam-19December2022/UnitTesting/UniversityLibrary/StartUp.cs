namespace UniversityLibrary
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            TextBook book = new TextBook("Title", "Author", "Category");
            System.Console.WriteLine(book.ToString());
        }
    }
}
