using System;

namespace GameOfWar
{
    public class DrawCardClass
    {
        public static void PrintCard(Card card)
        {
            string face = card.Face.ToString();
            char suit = (char)card.Suite;

            string faceName = card.Face.ToString(); 
            char suitSymbol = (char)card.Suite;    

            string[] cardArt = new string[]
            {
                $" {faceName} ",            
                "┌─────────┐",             
                "│         │",             
                "│         │",             
                $"│    {suitSymbol}    │",  
                "│         │",            
                "│         │",            
                $"└─────────┘",             
                $"  {faceName} "            
            };

            foreach (string line in cardArt)
            {
                Console.WriteLine(line);
            }
        }
    }
}
