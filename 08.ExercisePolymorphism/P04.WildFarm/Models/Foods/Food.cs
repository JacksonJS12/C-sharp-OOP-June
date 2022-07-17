namespace P04.WildFarm
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; }
    }
}