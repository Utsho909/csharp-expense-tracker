using System;
using System.IO;

class ExpenseTracker
{
    static string filePath = "expenses.txt";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- Expense Tracker ---");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. View Expenses");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();

            if (choice == "1") AddExpense();
            else if (choice == "2") ViewExpenses();
            else if (choice == "3") break;
            else Console.WriteLine("Invalid choice.");
        }
    }

    static void AddExpense()
    {
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter amount: ");
        string amount = Console.ReadLine();

        string entry = $"{DateTime.Now} | {desc} | ${amount}";
        File.AppendAllText(filePath, entry + Environment.NewLine);
        Console.WriteLine("✅ Expense added!");
    }

    static void ViewExpenses()
    {
        if (File.Exists(filePath))
        {
            Console.WriteLine("\n📄 Expense History:");
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("No expenses recorded yet.");
        }
    }
}
