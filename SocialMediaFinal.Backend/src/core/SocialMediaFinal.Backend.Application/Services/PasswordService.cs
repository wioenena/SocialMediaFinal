using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SocialMediaFinal.Backend.Application.Interfaces.Services;

namespace SocialMediaFinal.Backend.Application.Services;

internal sealed class PasswordService : IPasswordService {
    private const int saltSize = 128 / 8;
    private const int iterationCount = 100000;
    private const int numBytesRequested = 256 / 8;

    public string Hash(string password) {
        var salt = RandomNumberGenerator.GetBytes(saltSize);
        var hash = KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: iterationCount,
            numBytesRequested: numBytesRequested
          );
        var hashBytes = new byte[salt.Length + hash.Length];
        Buffer.BlockCopy(salt, 0, hashBytes, 0, salt.Length);
        Buffer.BlockCopy(hash, 0, hashBytes, salt.Length, hash.Length);
        return Convert.ToBase64String(hashBytes);
    }
    public bool Validate(string password, string hashedPassword) {
        var hashBytes = Convert.FromBase64String(hashedPassword);
        var salt = new byte[saltSize];
        Buffer.BlockCopy(hashBytes, 0, salt, 0, saltSize);
        var storedHash = new byte[hashBytes.Length - saltSize];
        Buffer.BlockCopy(hashBytes, saltSize, storedHash, 0, storedHash.Length);

        var newHash = KeyDerivation.Pbkdf2(
          password: password,
          salt: salt,
          prf: KeyDerivationPrf.HMACSHA256,
          iterationCount: iterationCount,
          numBytesRequested: storedHash.Length
        );

        return CryptographicOperations.FixedTimeEquals(storedHash, newHash);
    }

}
