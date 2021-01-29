using System;
namespace GenericLessonHomework
{
    public class Karta
    {
        public Type Type { get; set; }
        public Suit Suit { get; set; }

        public Karta(Type type, Suit suit)
        {
            Type = type;
            Suit = suit;
        }

        public void Display()
        {
            Console.Write($"|{Type} - {Suit}| ");
        }
    }
}
