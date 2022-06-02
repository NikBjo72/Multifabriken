using System;
using System.Collections.Generic;

namespace multifabriken_NikBjo72
{
    class Candy{

        protected string flavour; // Sats som definierar variabeln flavour till en string. Protected så att värdet inte kan ändras annat än i klassen.
        protected double quantity; // Sats som definierar variabeln quantity till en double. Protected så att värdet inte kan ändras annat än i klassen.

        public Candy (string inputFlavour, double inputQuantity){ // Konstruktor för klassen och som kräver värden på variablerna innan ett nytt objekt kan skapas.

            flavour = inputFlavour;
            quantity = inputQuantity;          

        }

        public static void inputPropertyForCandy(List<Candy> orderedCandy){ // Metod i klassen som skriver ut information i konsolen, hanterar inmatade värden samt lägger till det nya objektet i listan för typen (klassen).

            Console.Clear();
            Console.Write("*** Välkommen till godisbeställning! ***");
            Console.WriteLine();
            
            string flavour ="";
            bool err = false;
            while (!err){ // Loop som frågar efter smak och lägger i variablen flavour.
                Console.WriteLine();
                Console.Write("Önskad smak på godiset: "); // Hanterar ev. tom sträng och visar då felmeddelande.
                flavour = Console.ReadLine();
                if(string.IsNullOrEmpty(flavour)){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Var god skriv in önskad smak på godiset:");
                    Console.ResetColor();
                }
                else err = true;
            }

            Console.Clear();
            err = false;
            string quantity = "";
            double quantityParse = 0.0;
            while (!err){ // Loop som frågar efter mängd och lägger i (double) variablen quantity. Hanterar också fel inmatning av data, tex. text, komma och punkt.
                Console.Write("Ange önskad mängd i kilo: ");
                quantity = Console.ReadLine();
                quantity = quantity.Replace('.', ',');
                err = double.TryParse(quantity, out quantityParse);
                if (!err){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Skriv in önskad mängd med siffror.");
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }

            Console.Clear();
            orderedCandy.Add(new Candy(flavour, quantityParse)); // Lägger till det nya objektet i listan för typen.
            Console.WriteLine();
            Console.WriteLine($"Din beställning av godis:");
            int lastCandy = orderedCandy.Count - 1;
            Console.WriteLine();
            orderedCandy[lastCandy].whritePropertyForCandy(); // Skriver i konsolen ut specifikationerna på den nybeställda produkten.
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att återgå till beställningsmenyn.");
            Console.ReadKey();
        }

        public void whritePropertyForCandy(){ // Metod för att i konsolen skriva ut specifikationen på ett objekt av typen Candy.
            Console.WriteLine($"Godissmak: {flavour}.");
            Console.WriteLine($"Antal kilo godis: {quantity:N1} kg.");
        }

        public static void printListCandy(List<Candy> orderedCandy){ // Metod för att i konsolen skriva ut specifikationen på varje objekt av typen Candy som ligger i listan orderedCandy.

            if (orderedCandy.Count > 0){ // Kollar om det finns objekt i listan
                int amountCandy = 1;
                Console.WriteLine("*** Beställt godis ***");

                foreach (var candyInfo in orderedCandy){ // Foreach-loop skriver ut specifikation för varje objekt i listan, samt numrerar varje beställning av typen.
                    Console.WriteLine();
                    Console.WriteLine($"Godisbeställning nr: {amountCandy}");
                    candyInfo.whritePropertyForCandy();
                    Console.WriteLine();   
                    amountCandy++;
                }
            }
            else {
                Console.WriteLine("*** Du har inget beställt godis! ***"); // Skrivs ut om det inte finns några objekt i listan.
                Console.WriteLine();
            }
        }
    }
} 