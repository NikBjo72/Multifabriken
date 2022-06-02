using System;
using System.Collections.Generic;

namespace multifabriken_NikBjo72
{
    class Tofu{

        protected string spice; // Två satser som definierar en variabel till string och en till int. Protected så att värdet inte kan ändras annat än i klassen.
        protected int quantity;

        public Tofu (string inputSpice, int inputQuantity){ // Konstruktor för klassen och som kräver värden på variablerna innan ett nytt objekt kan skapas.

            spice = inputSpice;
            quantity = inputQuantity;          
        }

        public static void inputPropertyForTofu(List<Tofu> orderedTofu){ // Metod i klassen som skriver ut information i konsolen, hanterar inmatade värden samt lägger till det nya objektet i listan för typen (klassen).

            Console.Clear();
            Console.Write("*** Välkommen till tofubeställning! ***");
            Console.WriteLine();

            string tofuSpice ="";
            bool err = false;
            while (!err){ // Loop som frågar efter kryddning på tofu och lägger i variabel. Loop för att kunna felhantera inmatning.
                Console.WriteLine();
                Console.Write("Önskad kryddning på tofu: ");
                tofuSpice = Console.ReadLine();
                if(string.IsNullOrEmpty(tofuSpice)){ // Om fel på inmatat sträng, skrivs felmeddelande ut.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Var god skriv in en önskad kryddning på tofun.");
                    Console.ResetColor();
                }
                else err = true;
            }

            Console.Clear();
            string tofuQuantity ="";
            int tofuQuantityInt = 0;
            err = false;
            while (!err){ // Loop som frågar efter mängd av tofu och lägger i variabel. Loop för att kunna felhantera inmatning.
                Console.WriteLine();
                Console.Write("Önskad mängd (heltal liter): ");
                tofuQuantity = Console.ReadLine();
                err = int.TryParse(tofuQuantity, out tofuQuantityInt);
                if(!err){ // Om fel på inmatat sträng, skrivs felmeddelande ut.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Var god och skriv heltal med siffror.");
                    Console.ResetColor();
                }
            }

            Console.Clear();
            orderedTofu.Add(new Tofu(tofuSpice, tofuQuantityInt)); // Lägger till det nya objektet i listan för typen.
            Console.WriteLine();
            Console.WriteLine($"Din beställning av tofu:"); // Bekräftar beställning genom att skriva ut inmatade värden.
            int lastTofu = orderedTofu.Count - 1; // Kollar antalet ojekt i listan minus ett, för att få fram index och lägger i variabel.
            Console.WriteLine();
            orderedTofu[lastTofu].whritePropertyForTofu(); // Skriver med hjälp av metod i klassen ut specifikationerna på den nybeställda produkten.
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att återgå till beställningsmenyn.");
            Console.ReadKey();
        }
        public void whritePropertyForTofu(){ // Metod för att i konsolen skriva ut värdena i ett objekt av klasstypen.

            Console.WriteLine($"Kryddning på tofu: {spice}.");
            Console.WriteLine($"Mängd tofu: {quantity} liter.");
        }

        public static void printListTofu(List<Tofu> orderedTofu){ // Metod för att i konsolen skriva ut specifikationen på varje objekt av klasstypen som ligger i listan för klassen.
            
            if (orderedTofu.Count > 0){ // Kollar om det finns objekt i listan orderedTofu.
                int amountTofu = 1;
                Console.WriteLine("*** Beställd tofu ***");

                foreach (var tofuInfo in orderedTofu){ // Foreach-loop skriver ut specifikation för varje objekt i listan, samt numrerar varje beställning av typen.
                    Console.WriteLine();
                    Console.WriteLine($"Tofubeställning nr: {amountTofu}");
                    tofuInfo.whritePropertyForTofu(); // Anropar metod i klassen som skriver ut värden för varje objekt.
                    Console.WriteLine();   
                    amountTofu++;
                }
            }
            else {
                Console.WriteLine("*** Du har ingen beställd tofu! ***"); // Skrivs ut om det inte finns något beställt.
                Console.WriteLine();
            };
        }
    }
} 