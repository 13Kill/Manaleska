using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardEngine.Interfaces;

namespace CardEngine.Logic
{
    public class Deck : IDeck
    {
        private List<Card> mCards = new List<Card>();

        public ICard this[int index]
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
