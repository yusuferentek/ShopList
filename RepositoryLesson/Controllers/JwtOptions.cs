namespace RepositoryLesson.Controllers
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int Expiration { get; set; }
        public string SecretKey { get; set; }
    }
}
