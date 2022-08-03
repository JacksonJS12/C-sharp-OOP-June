namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;
        [SetUp]
        public void SetUp()
        {
            this.db = new Database();
        }

        [TestCase(new int[] {})]
        [TestCase(new int[] {1})]
        [TestCase(new int[] {1, 2, 3})]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void ConstructorShouldAddLessThan16Elements(int[] elementsToAdd)
        {
            Database testDb = new Database(elementsToAdd);


        }
    }
}
