using System;
namespace ZooManager
{
    public class Animal : Occupant
    {
       // public string emoji;
        //public string species;
        public string name;
        public int reactionTime = 5; // default reaction time for animals (1 - 10)
        public bool acted = false; // has the animal acted yet this turn?
       // public int turnsWithoutEating = 0; //how many turn they didn't eat
        // public Point location;

        /* public void ReportLocation()
         {
             Console.WriteLine($"I am at {location.x},{location.y}");
         }
        */

        virtual public void Activate()
        {
          //  turnsWithoutEating++; //when they activated, add a turn that they didn't eat
            Console.WriteLine($"Animal {name} at {location.x},{location.y} activated");

        }

       
    }
}
