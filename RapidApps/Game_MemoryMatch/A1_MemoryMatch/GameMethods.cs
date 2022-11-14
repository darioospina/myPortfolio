using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1_MemoryMatch
{
    public class GameMethods: Player
    {
        public void showCards(List<Card> myList)
        {
            for (int i = 0; i <= myList.Count - 1; i++)
            {
                if ((i + 1) % 4 == 0)
                {
                    Console.WriteLine(" " + myList[i].Back + " ");
                }
                else
                {
                    Console.Write(" " + myList[i].Back + " ");
                }
            }
            foreach (var item in myList)
            {

            }
        }
        public Boolean checkIfPaired(List<Card> myList, int num1, int num2, Player player)
        {
            player.Moves++;
            int selection1 = 0;
            int selection2 = 0;
            for (int i = 0; i < myList.Count; i++)
            {
                if (i == num1)
                {
                    selection1 = myList[i].Back;
                }
                if (i == num2)
                {
                    selection2 = myList[i].Back;
                }
            }

            if (selection1 == selection2)
            {
                player.Pairs++;
                foreach (var card in myList)
                {
                    if (card.Back == selection1 || card.Back == selection2)
                    {
                        card.paired = true;
                        return true;
                    }
                }
            }
            
            return false;
        }

        public List<Card> addCards()
        {
            List<Card> listOfCards = new List<Card>();

            Card c1 = new Card(1);
            Card c2 = new Card(2);
            Card c3 = new Card(3);
            Card c4 = new Card(4);
            Card c5 = new Card(5);
            Card c6 = new Card(6);
            Card c7 = new Card(7);
            Card c8 = new Card(8);
            Card c9 = new Card(9);
            Card c10 = new Card(10);
            Card c11 = new Card(1);
            Card c12 = new Card(2);
            Card c13 = new Card(3);
            Card c14 = new Card(4);
            Card c15 = new Card(5);
            Card c16 = new Card(6);
            Card c17 = new Card(7);
            Card c18 = new Card(8);
            Card c19 = new Card(9);
            Card c20 = new Card(10);

            listOfCards.Add(c1);
            listOfCards.Add(c2);
            listOfCards.Add(c3);
            listOfCards.Add(c4);
            listOfCards.Add(c5);
            listOfCards.Add(c6);
            listOfCards.Add(c7);
            listOfCards.Add(c8);
            listOfCards.Add(c9);
            listOfCards.Add(c10);
            listOfCards.Add(c11);
            listOfCards.Add(c12);
            listOfCards.Add(c13);
            listOfCards.Add(c14);
            listOfCards.Add(c15);
            listOfCards.Add(c16);
            listOfCards.Add(c17);
            listOfCards.Add(c18);
            listOfCards.Add(c19);
            listOfCards.Add(c20);

            var random = new Random();
            var randomized = listOfCards.OrderBy(item => random.Next()).ToList();

            return randomized;
        }
    }

}
