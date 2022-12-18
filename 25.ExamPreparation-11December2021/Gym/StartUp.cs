namespace Gym
{
    using Gym.Core;
    using Gym.Core.Contracts;
    using Gym.Models.Athletes;
    using Gym.Models.Equipment;
    using Gym.Models.Gyms;

    public class StartUp
    {
        public static void Main()
        {
            //BoxingGym bGym = new BoxingGym("Boxing Gym");
            //bGym.AddAthlete(new Boxer("Name", "Full", 0));
            //bGym.Exercise();
            //bGym.AddEquipment(new BoxingGloves());
            //System.Console.WriteLine(bGym.GymInfo());

            //return;

            // Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();

            
            
        }
    }
}
