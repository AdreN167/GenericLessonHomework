using System;
using System.Globalization;

namespace GenericLessonHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            // чтобы игра не длилась вечно (а это возможно из-за перетасовки карт таким образом, 
            // что игроки каждый ход просто обмениваются картами), я решил ввести ограничение по ходам.
            // Победитель определяется по наибольшему числу карт в руке.
            var game = new Game(6, 50);

            game.Play();
        }
    }
}
