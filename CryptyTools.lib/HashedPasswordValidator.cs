using System;

namespace CryptoTools.lib
{
  internal static class HashedPasswordValidator
  {
    /// <summary>
    /// Validates a password given a hash of the correct one.
    /// </summary>
    /// <param name="password">The password to check.</param>
    /// <param name="correctHash">A hash of the correct password.</param>
    /// <returns>True if the password is correct. False otherwise.</returns>
    public static bool Validate(string password, string correctHash)
    {
      // Extract the parameters from the hash
      char[] delimiter = { CryptoToolsConstants.HASH_OUTPUT_DELIMITER };
      var split = correctHash.Split(delimiter);
      var iterations = Int32.Parse(split[CryptoToolsConstants.ITERATION_INDEX]);
      var salt = Convert.FromBase64String(split[CryptoToolsConstants.SALT_INDEX]);
      var hash = Convert.FromBase64String(split[CryptoToolsConstants.PBKDF2_INDEX]);

      var testHash = HashCreator.Create(password, salt, iterations, hash.Length);
      
      return SlowEquals(hash, testHash);
    }

    /// <summary>
    /// Compares two byte arrays in length-constant time. This comparison
    /// method is used so that password hashes cannot be extracted from
    /// on-line systems using a timing attack and then attacked off-line.
    /// </summary>
    /// <param name="a">The first byte array.</param>
    /// <param name="b">The second byte array.</param>
    /// <returns>True if both byte arrays are equal. False otherwise.</returns>
    private static bool SlowEquals(byte[] a, byte[] b)
    {
      var diff = (uint)a.Length ^ (uint)b.Length;
      for (var i = 0; i < a.Length && i < b.Length; i++)
        diff |= (uint)(a[i] ^ b[i]);
      return diff == 0;
    }
  }
}