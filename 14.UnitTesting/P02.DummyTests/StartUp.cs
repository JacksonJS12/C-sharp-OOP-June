public class StartUp
{
    static void Main(string[] args)
    {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(100, 100);

        axe.Attack(dummy);
    }
}
