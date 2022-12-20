using CryptographyCourseProject;


string key1;
string key3;
try
{
    Console.WriteLine("Enter key for VerticalSubstitution1 (Key1):");
    key1 = Console.ReadLine();
    Utils.validateKey(key1);

    Console.WriteLine("Enter key for VerticalSubstitution2 (Key3):");
    key3 = Console.ReadLine();
    Utils.validateKey(key3);

    Console.WriteLine("Enter text:");
    Console.Write("P = ");
    var input = Console.ReadLine();

    var tst = new TSTAlgorithm(key1, key3, input);

    Console.WriteLine();

    Console.WriteLine("Generated substitution table: ");
    PrintDict(tst.Key2);

    Console.WriteLine();

    var encrypted = tst.Encrypt(input);

    Console.WriteLine("Result after VerticalTransposition1Enc:");
    Console.Write("c1 = ");
    PrintList(tst.c1);

    Console.WriteLine();

    Console.WriteLine("Result after DirectSubstitutionEnc:");
    Console.Write("c2 = ");
    PrintList(tst.c2);

    Console.WriteLine();

    Console.WriteLine("Result after VerticalTransposition2Enc and final cryptogram:");
    Console.Write("C = ");
    PrintList(encrypted);

    Console.WriteLine();

    var decrypted = tst.Decrypt(encrypted);

    Console.WriteLine("Result after VerticalTransposition2Dec:");
    Console.Write("c2 = ");
    PrintList(tst.c2);

    Console.WriteLine();

    Console.WriteLine("Result after DirectSubstitutionDec:");
    Console.Write("c1 = ");
    PrintList(tst.c1);

    Console.WriteLine();

    Console.WriteLine("Result after VerticalTransposition1Dec:");
    Console.Write("P = ");
    Console.WriteLine(decrypted);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}



//PrintNestedList(tst.CreateCryptogramTable(encrypted.Count / tst.Key3.Length, encrypted));
//Console.WriteLine();
//PrintList(tst.VerticalTransposition2Dec(tst.Key3, encrypted));

//var decrypted =
//Console.WriteLine();
//PrintList(tst.Decrypt(encrypted));


void PrintList<T>(List<T> list)
{
    foreach (T item in list)
        Console.Write($"{item} ");

    Console.WriteLine();
}

void PrintDict<TKey, TValue>(Dictionary<TKey, TValue> dict)
{
    foreach (var item in dict.Keys)
        Console.WriteLine($"{item} -> {dict[item]}");

    Console.WriteLine();
}

void PrintNestedList<T>(List<List<T>> list)
{
    foreach (var row in list)
    {
        Console.WriteLine();
        foreach (var item in row)
            Console.Write(item);
    }

    Console.WriteLine();
}
