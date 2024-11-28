namespace PicPayChallenge.Application.Configuration
{
    public class JwtOptions
    {
        public string Iss { get; set; }
        public string Aud { get; set; }
        public byte[] Secret { get; set; }
    }
}
