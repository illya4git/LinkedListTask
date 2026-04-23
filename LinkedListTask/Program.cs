namespace LinkedListTask;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        // Step 0: Create & fill the list.
        LinkedList list = new LinkedList();
        Console.WriteLine("--- Заповнення списку ---");
        Console.WriteLine("Послідовно введіть усі символи. Натисніть Enter після порожнього вводу аби зупинитись.");

        while (true)
        {
            Console.Write("Символ: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
                break;
            
            list.Prepend(input[0]);
        }
        
        Console.Write("\nПочатковий список: ");
        list.Print();
        
        Console.WriteLine("\n--- Маніпуляції зі списком ---");
        Console.Write("Уведіть шуканий символ: ");
        string targetInput = Console.ReadLine();
        char targetSymbol = string.IsNullOrEmpty(targetInput) ? '!' : targetInput[0];
        
        // Step 1: Locate the first exclamation.
        var (foundNode, index) = list.FindFirstOccurence(targetSymbol);
        if (foundNode == null)
        {
            Console.WriteLine($"\n1. Шуканий символ '{targetSymbol}' не знайдено в списку.");
        }
        else
        {
            Console.WriteLine($"\n1. Перше входження символу '{targetSymbol}' знайдено на позиції {index}.");
        }
        
        // Step 2: Sum all the elements greater than exclamation.
        int sum = list.SumOfElementsGreaterThan(targetSymbol);
        Console.WriteLine($"2. Сума ASCII-кодів для більших елементів: {sum}.");
        
        // Step 3: List all the elements after exclamation.
        var (newList, count) = list.GetElementsAfter(targetSymbol);
        Console.WriteLine($"3. Кількість елементів після символу '{targetSymbol}': {count}.");
        Console.Write("   Новий список: ");
        newList.Print();
        
        // Step 4: Purge all the elements before exclamation.
        Console.Write($"4. Список після видалення елементів перед символом '{targetSymbol}': ");
        list.RemoveElementsBefore(targetSymbol);
        list.Print();
        
        // Pause :)
        Console.ReadLine();
    }
}