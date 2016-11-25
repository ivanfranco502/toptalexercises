using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    /*In a casino all the playing cards got mixed up, some of them got lost. You have to collect as many full decks as possible.

You get N mixed up French playing cards as your input.

The cards are of the following ranks:
2, 3, 4, 5, 6, 7, 8, 9, T, J, Q, K, A

The four suits are:
Spade(♠), Club(♣), Heart(♥), and Diamond(♦)

The cards are given using their rank followed by their suit:

2 of Spades: 2S
Ace of Clubs: AC
10 of Hearts: TH

Example: ["9C", "KS", "AC", "AH", "8D", "4C", "KD", "JC", "7D", "9D", "2H", "7C", "3C", "7S", "5C", "6H", "TH"] -> 0
*/
    class Program
    {
        private static int[] _spadeQuantities;
        private static int[] _clubQuantities;
        private static int[] _heartQuantities;
        private static int[] _diamonQuantities;
        private static List<string> _cards;

        static void Main(string[] args)
        {
            _cards = new List<string>
            {
                "9C",
                "KS",
                "AC",
                "AH",
                "8D",
                "4C",
                "KD",
                "JC",
                "7D",
                "9D",
                "2H",
                "7C",
                "3C",
                "7S",
                "5C",
                "6H",
                "TH"
            };

            var result = GetQuantityOfDecks();
        }

        private static int GetQuantityOfDecks()
        {
            int quantityOfDecks = 0;

            _spadeQuantities = new int[13];
            _clubQuantities = new int[13];
            _heartQuantities = new int[13];
            _diamonQuantities = new int[13];

            foreach (string card in _cards)
            {
                var number = card.Substring(0, 1);
                var suit = card.Substring(1, 1);

                var index = GetIndex(number);

                AddCountToSuit(suit, index);
            }

            quantityOfDecks = _spadeQuantities.Min();

            if (quantityOfDecks > _clubQuantities.Min())
                quantityOfDecks = _clubQuantities.Min();
            if (quantityOfDecks > _heartQuantities.Min())
                quantityOfDecks = _heartQuantities.Min();
            if (quantityOfDecks > _diamonQuantities.Min())
                quantityOfDecks = _diamonQuantities.Min();

            return quantityOfDecks;
        }

        private static void AddCountToSuit(string suit, int index)
        {
            switch (suit)
            {
                case "S":
                    _spadeQuantities[index]++;
                    break;
                case "C":
                    _clubQuantities[index]++;
                    break;
                case "H":
                    _heartQuantities[index]++;
                    break;
                case "D":
                    _diamonQuantities[index]++;
                    break;
            }
        }

        private static int GetIndex(string number)
        {
            int index = 0;
            switch (number)
            {
                case "T":
                    index = 9;
                    break;
                case "J":
                    index = 10;
                    break;
                case "Q":
                    index = 11;
                    break;
                case "K":
                    index = 12;
                    break;
                case "A":
                    index = 0;
                    break;
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    index = int.Parse(number) - 1;
                    break;
            }
            return index;
        }
    }
}
