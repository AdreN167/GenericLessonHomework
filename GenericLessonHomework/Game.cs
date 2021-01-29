using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GenericLessonHomework
{
    public class Game
    {
        private const int cardsInDeck = 36;
        private const int minimumCountOfPlayers = 2;
        private const int maximumCountOfPlayers = 6;
        private const int minimumSteps = 20;

        private List<Karta> _deckOfCards;
        private List<Player> _players;
        private int _steps;

        public Game(int countOfPlayers, int steps)
        {
            _deckOfCards = new List<Karta>();

            _steps = minimumSteps;
            if (steps < minimumSteps)
            {
                _steps = steps;
            }

            for (int s = 0; s < 4; s++)
            {
                var suit = Enum.GetName(typeof(Suit), s);
                for (int t = 6; t <= 14; t++)
                {
                    var type = Enum.GetName(typeof(Type), t);
                    _deckOfCards.Add(new Karta((Type)Enum.Parse(typeof(Type), type), (Suit)Enum.Parse(typeof(Suit), suit)));
                }
            }


            Shufle();

            _players = new List<Player>();

            if (countOfPlayers < minimumCountOfPlayers || countOfPlayers > maximumCountOfPlayers)
            {
                countOfPlayers = minimumCountOfPlayers;
            }

            for (int i = 0; i < countOfPlayers; i++)
            {
                _players.Add(new Player());
            }

            HandOut();
        }

        private void Shufle()
        {
            var random = new Random();

            for (int i = 0; i < _deckOfCards.Count; i++)
            {
                int j = random.Next(i);
                var buffer = _deckOfCards[i];
                _deckOfCards[i] = _deckOfCards[j];
                _deckOfCards[j] = buffer;
            }
        }

        private void HandOut()
        {
            while (_deckOfCards.Count > 0)
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    _players[i].Cards.Add(_deckOfCards[_deckOfCards.Count - 1]);
                    _deckOfCards.RemoveAt(_deckOfCards.Count - 1);
                }
            }
        }

        public void Play()
        {
            int step = 0;
            var table = new List<Karta>();
            int winner = 0;

            while (step < _steps) 
            {
                Console.WriteLine($"{++step} step:");

                Karta maxCard = null;

                for (int i = 0; i < _players.Count; i++)
                {
                    if (_players[i].Cards.Count != 0)
                    {
                        maxCard = _players[i].Cards[_players[i].Cards.Count - 1];
                        winner = i;
                        break;
                    }
                }

                for (int i = 0; i < _players.Count; i++)
                {
                    if (_players[i].Cards.Count != 0)
                    {
                        Console.Write($"\t{i + 1} player({_players[i].Cards.Count}) -> ");
                        _players[i].Cards[_players[i].Cards.Count - 1].Display();
                        Console.WriteLine();


                        table.Add(_players[i].Cards[_players[i].Cards.Count - 1]);

                        if ((int)_players[i].Cards[_players[i].Cards.Count - 1].Type > (int)maxCard.Type)
                        {
                            maxCard = _players[i].Cards[_players[i].Cards.Count - 1];
                            winner = i;
                        }

                        _players[i].Cards.RemoveAt(_players[i].Cards.Count - 1);
                    }
                }

                Console.WriteLine($"Cards are taken by {winner + 1} player. He has {_players[winner].Cards.Count} cards.");
                _players[winner].Cards.InsertRange(0, table);
                
                Console.WriteLine();

                table.Clear();
            }

            int winnerCountCards = _players[0].Cards.Count;
            winner = 0;

            for (int i = 1; i < _players.Count; i++)
            {
                if (_players[i].Cards.Count > winnerCountCards)
                {
                    winnerCountCards = _players[i].Cards.Count;
                    winner = i;
                }
            }

            Console.WriteLine($"Winner is {winner + 1} player! He has {winnerCountCards} cards!");

        }
    }
}
