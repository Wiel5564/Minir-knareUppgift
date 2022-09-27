using System.Collections;
using System.Text.RegularExpressions;

namespace MiniräknareUppgift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till miniräknaren");
            // Lista för att spara historik för räkningar
            List<string> räkningar = new List<string>();
            // Användaren matar in tal och matematiska operation
            // OBS! Användaren måste mata in ett tal för att kunna ta sig vidare i programmet!
            // Ifall användaren skulle dela 0 med 0 visa Ogiltig inmatning!
            // Lägg resultat till listan
            // Visa resultat
            string input, resultat;
            int index, numA, numB;
            char[] operatorer = { '+', '-', '*', '/' };
            char användOperator;
            while (true)
            {
                Console.WriteLine("Skriv in en ekvation med två tal, t.ex. \"3 + 7\" eller \"10 / 5\":");
                input = Console.ReadLine();
                input = Regex.Replace(input, @"\s", "");
                index = input.IndexOfAny(operatorer);
                if (index == -1)
                {
                    Console.WriteLine("Ogiltig inmatning: måste använda en operator");
                    continue;
                }
                användOperator = input[index];
                try
                {
                    numA = int.Parse(input[..index]);
                    numB = int.Parse(input[(index + 1)..]);
                    switch (användOperator)
                    {
                        case '+':
                            resultat = $"{numA} + {numB} = " + (numA + numB);
                            break;
                        case '-':
                            resultat = $"{numA} - {numB} = " + (numA - numB);
                            break;
                        case '*':
                            resultat = $"{numA} * {numB} = " + (numA * numB);
                            break;
                        case '/':
                            resultat = $"{numA} / {numB} = " + (numA / numB);
                            break;
                        default:
                            Console.WriteLine("Ogiltig inmatning");
                            continue;
                    }
                    Console.WriteLine(resultat);
                    räkningar.Add(resultat);
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Ogiltig inmatning: kan inte dividera med 0");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ogiltig inmatning: använd bara siffror och operatorer");
                }
                // Fråga användaren om den vill visa tidigare resultat
                // Visa tidigare resultat
                Console.WriteLine("Vill du se tidigare resultat? y/n");
                input = Console.ReadLine();
                if (input == "y")
                    foreach (var räkning in räkningar)
                        Console.WriteLine(räkning);
                // Fråga användaren om den vill avsluta eller fortsätta
                Console.WriteLine("Vill du avsluta? y/n");
                input = Console.ReadLine();
                if (input == "y")
                    break;
            }
        }
    }
}