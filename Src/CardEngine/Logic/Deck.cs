#region

using System;
using System.Collections.Generic;
using CardEngine.Interfaces;

#endregion

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
                catch (Exception ex)
                {
                }
                return null;
            }
        }
    }
}