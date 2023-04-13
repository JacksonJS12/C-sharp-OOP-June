namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Text;

    public class TextBook_Testing
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructortTest()
        {
            TextBook book = new TextBook("Title", "Author", "SomeCategory");

            Assert.AreEqual("Title", book.Title);
            Assert.AreEqual("Author", book.Author);
            Assert.AreEqual("SomeCategory", book.Category);
        }

        [Test]
        public void ToStringTest()
        {
            TextBook book = new TextBook("Title", "Author", "Category");

            string print = "Book: Title - 0\r\n" +
                "Category: Category\r\n" +
                "Author: Author";

            Assert.AreEqual(print, book.ToString());
        }
    }
    public class UniversityLibrary_Teting
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddTextBookToLibrary_Test()
        {
            UniversityLibrary universityLibrary = new UniversityLibrary();
            TextBook book = new TextBook("Title", "Author", "SomeCategory");

            universityLibrary.AddTextBookToLibrary(book);

            Assert.AreEqual(1, universityLibrary.Catalogue.Count);
        }

        [Test]
        public void LoanTextBook_Test()
        {
            UniversityLibrary universityLibrary = new UniversityLibrary();
            TextBook book = new TextBook("Title", "Author", "SomeCategory");
            book.Holder = "Sam";

            int bookInventoryNumber = 0;
            string studentName = "Sam";

            Assert.AreEqual(book.Holder, studentName);
            Assert.AreEqual(bookInventoryNumber, book.InventoryNumber);

            //(int bookInventoryNumber, string studentName)
            //TextBook textBook = this.textBooks.FirstOrDefault(t => t.InventoryNumber == bookInventoryNumber);

            //if (textBook.Holder == studentName)
            //{
            //    return $"{studentName} still hasn't returned {textBook.Title}!";
            //}
            //else
            //{
            //    textBook.Holder = studentName;

            //    return $"{textBook.Title} loaned to {studentName}.";
            //}
        }
    } 
}