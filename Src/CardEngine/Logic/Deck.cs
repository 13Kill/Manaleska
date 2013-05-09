using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEngine.Logic
{
    class Deck
    {
        private List<Card> mCards = new List<Card>();

        public Card this[int index]
        {
            get
            {
                try
                {
                    return mCards.ElementAt(index);
                }
                catch (System.Exception ex)
                {
                	
                }
                return null;
            }
        }
    }
}
