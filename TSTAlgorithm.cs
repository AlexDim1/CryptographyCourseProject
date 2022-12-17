using System.Text;

namespace CryptographyCourseProject
{
    public static class TSTAlgorithm
    {

        // Step 1 and 3 in the Transposition-Substitution-Transposition Algorithm
        public static List<char> VerticalTransposition(string key, string plainText)
        {
            StringBuilder sb = new StringBuilder();
            var result = new List<char>();

            // Get the indices we use for swapping the columns
            var numKey = GetKeyNumbers(key);

            // Divide our plain text into blocks of size key.Length
            var textBlocks = GetStringBlocks(key.Length, plainText);

            List<List<char>> transposedTable = new List<List<char>>();

            // Create our starting table with the blocks of the PT
            var tablePlainText = CreateTable(textBlocks);

            // Apply transposition to columns
            for (int row = 0; row < tablePlainText.Count; row++)
            {
                var newRow = new List<char>();
                for (int newIdx = 1; newIdx <= tablePlainText[0].Count; newIdx++)
                {
                    var valForNewIdx = numKey.IndexOf(newIdx);
                    newRow.Add(tablePlainText[row][valForNewIdx]);
                }

                transposedTable.Add(newRow);
            }

            // Create the cryptogram by taking the chars by column
            for (int col = 0; col < transposedTable[0].Count; col++)
                for (int row = 0; row < transposedTable.Count; row++)
                    result.Add(transposedTable[row][col]);

            return result;
        }

        public static List<int> DirectSubstitution(Dictionary<char, int> key, List<char> plainText)
        {
            var result = new List<int>();

            for (int i = 0; i < plainText.Count; i++)
                result.Add(key[plainText[i]]);


            return result;
        }

        public static Dictionary<char, int> GenerateSubstitutionTable()
        {
            var result = new Dictionary<char, int>();
            var r = new Random();
            var usedValues = new List<int>();

            for (char c = 'a'; c <= 'z'; c++)
            {
                var value = r.Next(20, 100);

                while (usedValues.Contains(value))
                    value = r.Next(20, 100);

                result.Add(c, value);
                usedValues.Add(value);
            }

            char[] chars = new char[] { ' ', ',', ';', ':', '!', '?', '-', '.' };

            foreach (char c in chars)
            {
                var value = r.Next(10, 20);

                while (usedValues.Contains(value))
                    value = r.Next(10, 20);

                result.Add(c, value);
                usedValues.Add(value);
            }

            return result;
        }

        public static List<List<char>> CreateTable(List<string> textBlocks)
        {
            List<List<char>> table = new List<List<char>>();

            for (int i = 0; i < textBlocks.Count; i++)
            {
                var row = new List<char>();

                for (int j = 0; j < textBlocks[i].Length; j++)
                    row.Add(textBlocks[i][j]);

                table.Add(row);
            }

            return table;
        }

        public static List<string> GetStringBlocks(int blockLength, string text)
        {
            List<string> blocks = new List<string>();

            for (int i = 0; i < text.Length; i += blockLength)
            {
                if (i + blockLength <= text.Length)
                {
                    blocks.Add(text.Substring(i, blockLength));
                    continue;
                }

                var shortBlock = text.Substring(i, text.Length - i);
                while (shortBlock.Length < blockLength)
                    shortBlock += ' ';

                blocks.Add(shortBlock);
            }

            return blocks;
        }

        public static List<int> GetKeyNumbers(string key)
        {
            List<int> keyNumbers = new List<int>();
            Dictionary<char, int> charIndex = new Dictionary<char, int>();

            List<char> orderedKey = key.OrderBy(x => x).ToList();
            //Console.WriteLine(orderedKey);

            int ctr = 1;
            foreach (char c in orderedKey)
                charIndex.Add(c, ctr++);

            //foreach(var pair in charIndex)
            //    Console.WriteLine($"{pair.Key}: {pair.Value}");

            foreach (char c in key)
                keyNumbers.Add(charIndex[c]);

            //Console.WriteLine(keyNumbers);

            return keyNumbers;
        }
    }
}
