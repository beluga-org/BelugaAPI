using System.Security.Cryptography;

namespace BelugaAPI.Application.Utils;

public static class TokenGenerator
{
    public static string GenerateToken(int length = 32)
    {
        byte[] tokenBytes = new byte[length];
    
        // Gera bytes aleatórios seguros usando RandomNumberGenerator
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(tokenBytes);
        }

        // Converte os bytes em uma string Base64 para gerar o token
        return Convert.ToBase64String(tokenBytes);
    }
}