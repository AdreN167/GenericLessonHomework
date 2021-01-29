using System;
using System.Collections.Generic;
using System.Text;

namespace GenericLessonHomework
{
    public class Player
    {
        public List<Karta> Cards { get; set; } = new List<Karta>();

        public void DisplayKards()
        {
            Console.WriteLine($"Count of cards: {Cards.Count}");
            foreach(var card in Cards)
            {
                card.Display();
            }
            Console.WriteLine();
        }
    }
}
