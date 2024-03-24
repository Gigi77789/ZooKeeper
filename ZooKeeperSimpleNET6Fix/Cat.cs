using System;

namespace ZooManager
{
    public class Cat : Animal
    {
        public Cat(string name)
        {
            emoji = "🐱";
            species = "cat";
            this.name = name;
            reactionTime = new Random().Next(1, 6); // reaction time 1 (fast) to 5 (medium)Cat
        }

        public int turnsSinceLastHunt { get; private set; } = 0;//track the non-eating turn 

        public override void Activate()
        {
            base.Activate();
            turnsSinceLastHunt++; //add turns
            Console.WriteLine("I am a cat. Meow.");
           // Flee();
           // Hunt();
            ActionOrder();
        }



        public void ActionOrder()
        {
            // fled or not?
            bool hasFled = Flee();

            // if not, then hunt
            if (!hasFled)
            {
                Hunt();
            }
        }

        /* Note that our cat is currently not very clever about its hunting.
         * It will always try to attack "up" and will onlyßseek "down" if there
         * is no mouse above it. This does not affect the cat's effectiveness
         * very much, since the overall logic here is "look around for a mouse and
         * attack the first one you see." This logic might be less sound once the
         * cat also has a predator to avoid, since the cat may not want to run in
         * to a square that sets it up to be attacked!
         */
        public bool Flee()
        {
            if (Game.Seek(location.x, location.y, Direction.up, "raptor"))
            {
                return Game.Retreat(this, Direction.down);
            }
            if (Game.Seek(location.x, location.y, Direction.down, "raptor"))
            {
                return Game.Retreat(this, Direction.up);
            }
            if (Game.Seek(location.x, location.y, Direction.left, "raptor"))
            {
                return Game.Retreat(this, Direction.right);
            }
            if (Game.Seek(location.x, location.y, Direction.right, "raptor"))
            {
                return Game.Retreat(this, Direction.left);
            }
            return false;
        }

        public void Hunt()
        {
            if (Game.Seek(location.x, location.y, Direction.up, "mouse") || Game.Seek(location.x, location.y, Direction.up, "chick"))
            {
                Game.Attack(this, Direction.up);
                turnsSinceLastHunt = 0;//if hunt, reset the value of turnsSinceLastHunt to 0
            }
            else if (Game.Seek(location.x, location.y, Direction.down, "mouse") || Game.Seek(location.x, location.y, Direction.down, "chick"))
            {
                Game.Attack(this, Direction.down);
                turnsSinceLastHunt = 0;
            }
            else if (Game.Seek(location.x, location.y, Direction.left, "mouse") || Game.Seek(location.x, location.y, Direction.left, "chick"))
            {
                Game.Attack(this, Direction.left);
                turnsSinceLastHunt = 0;
            }
            else if (Game.Seek(location.x, location.y, Direction.right, "mouse") || Game.Seek(location.x, location.y, Direction.right, "chick"))
            {
                Game.Attack(this, Direction.right);
                turnsSinceLastHunt = 0;
            }
        }
    }
}

