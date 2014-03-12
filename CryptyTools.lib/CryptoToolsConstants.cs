namespace CryptoTools.lib
{
  internal static class CryptoToolsConstants
  {
    // The following constants may be changed without breaking existing hashes.
    public const int SALT_BYTE_SIZE = 24;
    public const int HASH_BYTE_SIZE = 24;
    public const int PBKDF2_ITERATIONS = 1000;

    public const int ITERATION_INDEX = 0;
    public const int SALT_INDEX = 1;
    public const int PBKDF2_INDEX = 2;

    public const char HASH_OUTPUT_DELIMITER = ':';
    public const string HASH_OUTPUT_FORMAT = "{0}:{1}:{2}";
  }
}