using System;
using System.Collections.Generic;

namespace multifabriken_NikBjo72
{
    class Lace{

        protected string color; // Två satser som definierar en variabel till string och en till int. Protected så att värdet inte kan ändras annat än i klassen.
        protected int length;

        public Lace (string inputColor, int inputLength){ // Konstruktor för klassen och som kräver värden på variablerna innan ett nytt objekt kan skapas.

            color = inputColor;
            length = inputLength;          

        }
        public void whritePropertyForLace(){ // Metod för att i konsolen skriva ut specifikationen på ett objekt av klasstypen.

            Console.WriteLine($"Färg på snöret: {color}.");
            Console.WriteLine($"Längd på snöret: {length} meter.");
        }
        public static void inputPropertyForLace(List<Lace> orderedLace){ // Metod i klassen som skriver ut information i konsolen, hanterar inmatade värden samt lägger till det nya objektet i listan för typen (klassen).

            Console.Clear();
            Console.Write("*** Välkommen till beställning av snöre! ***");
            Console.WriteLine();

            string laceColor ="";
            bool err = false;
            while (!err){ // Loop som frågar efter färg på snöret och lägger i variabel. Loop för att kunna felhantera inmatning.
                Console.WriteLine();
                Console.Write("Önskad färg på snöret: ");
                laceColor = Console.ReadLine();
                if(string.IsNullOrEmpty(laceColor)){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Var god skriv in en önskad färg på snöret:");
                    Console.ResetColor();
                }
                else err = true;
            }

            Console.Clear();
            string laceLength ="";
            int laceLengthInt = 0;
            err = false;
            while (!err){ // Loop som frågar efter längd på snöret och lägger i variabel. Loop för att kunna felhantera inmatning.
                Console.Write("Önskad längd (heltal meter): ");
                laceLength = Console.ReadLine();
                err = int.TryParse(laceLength, out laceLengthInt);
                if(!err){ // Om fel på inmatat sträng, skrivs felmeddelande ut.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Var god och skriv heltal med siffror.");
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }

            Console.Clear();
            orderedLace.Add(new Lace(laceColor, laceLengthInt)); // Lägger till det nya objektet i listan för typen.
            Console.WriteLine();
            Console.WriteLine($"Din beställning av snöre:"); // Bekräftar beställning genom att skriva ut inmatade värden.
            int lastLace = orderedLace.Count - 1; // Kollar antalet ojekt i listan minus ett, för att få fram index och lägger i variabel.
            Console.WriteLine();
            orderedLace[lastLace].whritePropertyForLace(); // Skriver i konsolen ut specifikationerna på den nybeställda produkten.
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att återgå till beställningsmenyn.");
            Console.ReadKey();
        }
        public static void printListLace(List<Lace> orderedLace){ // Metod för att i konsolen skriva ut specifikationen på varje objekt av klasstypen som ligger i listan för klassen.

            if (orderedLace.Count > 0){ // Kollar om det finns objekt i listan
                int amountLace = 1;
                Console.WriteLine("*** Beställda snören ***");

                foreach (var laceInfo in orderedLace){ // Foreach-loop skriver ut specifikation för varje objekt i listan, samt numrerar varje beställning av typen.
                    Console.WriteLine();
                    Console.WriteLine($"Snöre nr: {amountLace}");
                    laceInfo.whritePropertyForLace(); // Anropar metod i klassen som skriver ut värden för varje objekt.
                    Console.WriteLine();   
                    amountLace++;
                }
            }
            else {
                Console.WriteLine("*** Du har inga betställda snören! ***");
                Console.WriteLine();
            };
        }
    }
} 