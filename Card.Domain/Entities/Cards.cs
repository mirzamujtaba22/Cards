using System.ComponentModel.DataAnnotations;

namespace Cards.Domain.Entities
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public string? CardholderName { get; set; }
        public string? CardNumberr { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public int CVC { get; set; }

    }
}
