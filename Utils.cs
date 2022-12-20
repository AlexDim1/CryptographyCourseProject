namespace CryptographyCourseProject
{
    public static class Utils
    {
        public static void validateKey(string key)
        {
            for (int i = 0; i < key.Length; i++)
                for (int j = i + 1; j < key.Length; j++)
                {
                    if (key[j] == key[i])
                        throw new Exception($"Key {key} should have unique characters only!");

                    if (!char.IsLetter(key[j]))
                        throw new Exception("Key should contain only letters!");
                }
        }
    }
}
