using System;

namespace ZooManager
{
    public class Raptor : Bird/*
	                             * I've decided to keep four buttons.
	                             * In my version, animals die if they go without food for three rounds.
	                             * So, if I want four types of birds, I'll need to raise four chicks, 
	                             * but their survival chances won't be high unless I constantly rotate feeding them. 
	                             * This would impact the experience of playing with other animals. 
	                             * Now, I've displayed all four buttons, increasing animal diversity and player flexibility. 
	                             * They can choose to start with chicks or directly raise adult chickens.*/
    {
		public Raptor(string name)
        {
            emoji = "🦅";
            species = "raptor";
            this.name = name;
            reactionTime = 1; // reaction time 1 
        }
        public int turnsSinceLastHunt { get; private set; } = 0;//track the non-eating turn 

        public override void Activate()
        {
            base.Activate();
            turnsSinceLastHunt++;
            Console.WriteLine("I am a raptor. Wow.");
            Hunt();
        }

        /* Note that our cat is currently not very clever about its hunting.
         * It will always try to attack "up" and will only seek "down" if there
         * is no mouse above it. This does not affect the cat's effectiveness
         * very much, since the overall logic here is "look around for a mouse and
         * attack the first one you see." This logic might be less sound once the
         * cat also has a predator to avoid, since the cat may not want to run in
         * to a square that sets it up to be attacked!
         */
        public void Hunt()
        {
            if (Game.Seek(location.x, location.y, Direction.up, "cat") || Game.Seek(location.x, location.y, Direction.up, "mouse"))
            {
                Game.Attack(this, Direction.up);
                turnsSinceLastHunt = 0;
            }
            else if (Game.Seek(location.x, location.y, Direction.down, "cat") || Game.Seek(location.x, location.y, Direction.down, "mouse"))
            {
                Game.Attack(this, Direction.down);
                turnsSinceLastHunt = 0;
            }
            else if (Game.Seek(location.x, location.y, Direction.left, "cat") || Game.Seek(location.x, location.y, Direction.left, "mouse"))
            {
                Game.Attack(this, Direction.left);
                turnsSinceLastHunt = 0;
            }
            else if (Game.Seek(location.x, location.y, Direction.right, "cat") || Game.Seek(location.x, location.y, Direction.right, "mouse"))
            {
                Game.Attack(this, Direction.right);
                turnsSinceLastHunt = 0;
            }
        }

    }
}

