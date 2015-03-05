using System;
using System.Security.Cryptography;

namespace CryptoTools.lib
{
  /// <summary>
  /// Salted password hashing with Create-SHA1.
  /// Author: havoc AT defuse.ca
  /// www: http://crackstation.net/hashing-security.htm
  /// Compatibility: .NET 3.0 and later.
  /// </summary>
  public class PasswordHashCreator
  {
    /// <summary>
    /// Creates a salted Create hash of the password.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <returns>The hash of the password.</returns>
    public static string Create(string password)
    {
      // Generate a random salt
      var csprng = new RNGCryptoServiceProvider();
      var salt = new byte[CryptoToolsConstants.SALT_BYTE_SIZE];
      csprng.GetBytes(salt);

      // Hash the password and encode the parameters
      var hash = HashCreator.Create(
				password,
				salt, 
				CryptoToolsConstants.PBKDF2_ITERATIONS, 
				CryptoToolsConstants.HASH_BYTE_SIZE);

      return string.Format(
				CryptoToolsConstants.HASH_OUTPUT_FORMAT,
				CryptoToolsConstants.PBKDF2_ITERATIONS,
				Convert.ToBase64String(salt),
				Convert.ToBase64String(hash));
    }
  }
}