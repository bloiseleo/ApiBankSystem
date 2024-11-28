namespace PicPayChallenge.Domain.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Decimal Amount { get; set; }
    }
}
