using System;
namespace ZooManager
{
    public class Chick : Bird
    {
        public Chick(string name)
        {
            emoji = "🐥";
            species = "chick";
            this.name = name; // "this" to clarify instance vs. method parameter
            reactionTime = new Random().Next(5, 10); // reaction time of 6 (fast) to 10
            /* Note that Mouse reactionTime range is smaller than Cat reactionTime,
             * so mice are more likely to react to their surroundings faster than cats!
             Mouse*/
        }
        public int turnsSinceLastHunt { get; private set; } = 0;//track the non-eating turns
        public int totalTurns { get; private set; } = 0;//track chick's total turns  

        public override void Activate()
        {
            base.Activate();
            turnsSinceLastHunt++;
            totalTurns++;
            Console.WriteLine("I am a chick. Jijijiji.");
            Flee();
            Hunt();
        }

        /* Note that our mouse is (so far) a teeny bit more strategic than our cat.
         * The mouse looks for cats and tries to run in the opposite direction to
         * an empty spot, but if it finds that it can't go that way, it looks around
         * some more. However, the mouse currently still has a major weakness! He
         * will ONLY run in the OPPOSITE direction from a cat! The mouse won't (yet)
         * consider running to the side to escape! However, we have laid out a better
         * foundation here for intelligence, since we actually check whether our escape
         * was succcesful -- unlike our cats, who just assume they'll get their prey!
         */
        public void Flee()
        {
            if (Game.Seek(location.x, location.y, Direction.up, "cat"))
            {
                if (Game.Retreat(this, Direction.down)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.down, "cat"))
            {
                if (Game.Retreat(this, Direction.up)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.left, "cat"))
            {
                if (Game.Retreat(this, Direction.right)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.right, "cat"))
            {
                if (Game.Retreat(this, Direction.left)) return;
            }
        }

        public void Hunt()
        {
            if (Game.Seek(location.x, location.y, Direction.up, "grass"))
            {
                Game.Attack(this, Direction.up);
                turnsSinceLastHunt = 0;//if hunt, reset the value of turnsSinceLastHunt to 0
            }
            else if (Game.Seek(location.x, location.y, Direction.down, "grass"))
            {
                Game.Attack(this, Direction.down);
                turnsSinceLastHunt = 0;
            }
            else if (Game.Seek(location.x, location.y, Direction.left, "grass"))
            {
                Game.Attack(this, Direction.left);
                turnsSinceLastHunt = 0;
            }
            else if (Game.Seek(location.x, location.y, Direction.right, "grass"))
            {
                Game.Attack(this, Direction.right);
                turnsSinceLastHunt = 0;
            }
        }
    }
}

