namespace CryptographyCourseProject
{
    public static class Utils
    {
        public static void validateKey(string key)
        {
            if (key == null || key.Equals(""))
                throw new InvalidDataException("You must enter a key!");


            for (int i = 0; i < key.Length; i++)
                for (int j = i + 1; j < key.Length; j++)
                {
                    if (key[j] == key[i])
                        throw new InvalidDataException($"Key {key} should have unique characters only!");

                    if (!char.IsLetter(key[j]))
                        throw new InvalidDataException("Key should contain only letters!");

                    if (key[j] < 'a' || key[j] > 'z')
                        throw new InvalidDataException("Invalid characters in key! (Latin alphabet only)");
                }
        }

        public static void validateInput(string input, string key1, string key3)
        {
            if (input == null)
                throw new InvalidDataException("Enter a message!");

            foreach(var c in input)
                if (char.IsLetter(c) && (c < 'a' || c > 'z'))
                    throw new InvalidDataException("Invalid characters in message! (Latin alphabet only)");

            if(input.Length < key1.Length || input.Length < key3.Length)
                throw new InvalidDataException("Message cannot be shorter than any of the keys!");
        }
    }
}
