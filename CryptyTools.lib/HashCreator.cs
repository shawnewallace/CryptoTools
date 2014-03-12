using System.Security.Cryptography;

namespace CryptoTools.lib
{
  internal static class HashCreator
  {
    /// <summary>
    /// Computes the Create-SHA1 hash of a password.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <param name="salt">The salt.</param>
    /// <param name="iterations">The Create iteration count.</param>
    /// <param name="outputBytes">The length of the hash to generate, in bytes.</param>
    /// <returns>A hash of the password.</returns>
    public static byte[] Create(string password, byte[] salt, int iterations, int outputBytes)
    {
      var pbkdf2 = new Rfc2898DeriveBytes(password, salt) {IterationCount = iterations};
      return pbkdf2.GetBytes(outputBytes);
    }
  }
}