namespace CryptographyCourseProject
{
    public static class Utils
    {
        public static void validateKey(string key)
        {
            if (key == null || key.Equals(""))
                throw new Exception("You must enter a key!");


            for (int i = 0; i < key.Length; i++)
                for (int j = i + 1; j < key.Length; j++)
                {
                    if (key[j] == key[i])
                        throw new Exception($"Key {key} should have unique characters only!");

                    if (!char.IsLetter(key[j]))
                        throw new Exception("Key should contain only letters!");

                    if (key[j] < 'a' || key[j] > 'z')
                        throw new Exception("Invalid characters in key! (Latin alphabet only)");
                }
        }

        public static void validateInput(string input)
        {
            if (input == null)
                throw new Exception("Enter a message!");

            foreach(var c in input)
                if (c < 'a' || c > 'z')
                    throw new Exception("Invalid characters in message! (Latin alphabet only)");
        }
    }
}
