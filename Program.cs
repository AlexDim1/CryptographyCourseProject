using CryptographyCourseProject;

Console.WriteLine("Enter key1:");
var key1 = Console.ReadLine();

//Console.WriteLine("Enter key2:");
//var key2 = Console.ReadLine();

Console.WriteLine("Enter key3:");
var key3 = Console.ReadLine();

Console.WriteLine("Enter text:");
var input = Console.ReadLine();
var plainText = input.ToCharArray().ToList();

var tst = new TSTAlgorithm(key1, key3);


PrintDict(tst.Key2);
//Console.WriteLine(TSTAlgorithm.VerticalTransposition(key1, input));
var encrypted = tst.Encrypt(input);
PrintList(tst.VerticalTransposition1Enc(tst.Key1, input));
Console.WriteLine();
PrintList(encrypted);

//PrintNestedList(tst.CreateCryptogramTable(encrypted.Count / tst.Key3.Length, encrypted));
//Console.WriteLine();
//PrintList(tst.VerticalTransposition2Dec(tst.Key3, encrypted));

//var decrypted =
Console.WriteLine();
PrintList(tst.Decrypt(encrypted));


void PrintList<T>(List<T> list)
{
    foreach (T item in list)
        Console.Write($"{item} ");
}

void PrintDict<TKey, TValue>(Dictionary<TKey, TValue> dict)
{
    foreach (var item in dict.Keys)
        Console.WriteLine($"{item} -> {dict[item]}");
}

void PrintNestedList<T>(List<List<T>> list)
{
    foreach (var row in list)
    {
        Console.WriteLine();
        foreach (var item in row)
            Console.Write(item);
    }
}
