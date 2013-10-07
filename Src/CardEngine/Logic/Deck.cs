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
        private readonly List<Card> _cards = new List<Card>();

        public ICard this[int index]
        {
            get
            {
                try
                {
                    return _cards[index];
                }
                catch (System.Exception ex)
                {
                	
                }
                return null;
            }
        }
    }
}
