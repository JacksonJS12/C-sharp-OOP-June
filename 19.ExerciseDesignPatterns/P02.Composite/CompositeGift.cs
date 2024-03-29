﻿using System;
using System.Collections.Generic;

namespace P02.Composite
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        protected readonly ICollection<GiftBase> nestedGifts;
        public CompositeGift(string name, int price) : base(name, price)
        {
            this.nestedGifts = new HashSet<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            this.nestedGifts.Add(gift);
        }

        public bool Remove(GiftBase gift)
        {
          return  this.nestedGifts.Remove(gift);
        }
        public override int CalculateTotalPrice()
        {
            int totalPrice = 0;

            Console.WriteLine($"{this.nestedGifts} contains the following products with prices: ");
            foreach (var nestedGift in this.nestedGifts)
            {
                totalPrice += nestedGift.CalculateTotalPrice();
            }
            return totalPrice;
        }
    }
}
