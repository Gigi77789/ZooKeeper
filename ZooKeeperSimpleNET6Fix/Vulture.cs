using System;

namespace ZooManager
{
	public class Vulture : Bird/*
	                             * I've decided to keep four buttons.
	                             * In my version, animals die if they go without food for three rounds.
	                             * So, if I want four types of birds, I'll need to raise four chicks, 
	                             * but their survival chances won't be high unless I constantly rotate feeding them. 
	                             * This would impact the experience of playing with other animals. 
	                             * Now, I've displayed all four buttons, increasing animal diversity and player flexibility. 
	                             * They can choose to start with chicks or directly raise adult chickens.*/
    {
		public Vulture(string name)
		{
            emoji = "🐦‍⬛";
            species = "vulture";
            this.name = name; // "this" to clarify instance vs. method parameter
            reactionTime = new Random().Next(2, 4);
        }

        public int turnsSinceLastHunt { get; private set; } = 0;//track the non-eating turn 

        public override void Activate()
        {
            base.Activate();
            turnsSinceLastHunt++;
            Console.WriteLine("I am a vulture.");
         //   Flee();
            Hunt();
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

