using System;
using System.Collections.Generic;

#nullable disable

namespace Session2_API_CORE.Models
{
    public partial class LoyaltyCard
    {
        public int Id { get; set; }
        public string LoyaltyСard { get; set; }
        public string CardHolder { get; set; }
        public int? Balance { get; set; }

        public LoyaltyCard(int id, string loyaltyСard, string cardHolder, int? balance)
        {
            Id = id;
            LoyaltyСard = loyaltyСard;
            CardHolder = cardHolder;
            Balance = balance;
        }
    }
}
