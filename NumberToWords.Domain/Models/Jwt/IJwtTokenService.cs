namespace NumberToWords.Domain.Models.Jwt
{
    public interface IJwtTokenService
    {
        string GenerateToken(string userName);
    }
}
