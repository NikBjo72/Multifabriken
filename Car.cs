using System;
using System.Collections.Generic;

namespace multifabriken_NikBjo72
{
    class Car{

        protected string regNumber; // Tre satser som definierar variabler till string. Protected så att värdet inte kan ändras annat än i klassen.
        protected string color;
        protected string model;

        public Car (string inputRegNumber, string inputColor, string inputModel){ // Konstruktor för klassen och som kräver värden på variablerna innan ett nytt objekt kan skapas.

            regNumber = inputRegNumber;
            color = inputColor;
            model = inputModel;            

        }

        protected static int AmountLettersOrDigits(string text) // En metod i klassen som används för att kolla mängden tecken i en string.
        {
            int amount = 0;
            foreach (char c in text)
            {
                if (Char.IsLetterOrDigit(c))
                    amount++;
            }
            return amount;
        }
        public static void inputPropertyForCar(List<Car> orderedCars){ // Metod i klassen som skriver ut information i konsolen, hanterar inmatade värden samt lägger till det nya objektet i listan för typen (klassen).

            Console.Clear();
            Console.Write("*** Välkommen till bilbeställningen! ***");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Din skylt måste ha minst två och högst sju tecken.\nSom tecken räknas bokstäver, siffror och mellanrum.\nSkylten måste ha minst två synliga tecken.\nDen kombination du väljer kommer att vara centrerad på skylten.");
            Console.ResetColor();
            Console.WriteLine();

            string regPlate ="";
            bool err = false;
            while (!err){ // Loop som frågar efter text på registreringsskylt och lägger i variablen regPlate. 
                Console.Write("Önskad registreringsskyltstext: ");
                regPlate = Console.ReadLine();
                if(regPlate.Length < 2 || regPlate.Length > 7 || string.IsNullOrWhiteSpace(regPlate) || AmountLettersOrDigits(regPlate) < 2){ // Hanterar också ev. tom sträng, bara whitespace, för få synliga tecken samt för få och för många tecken.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Var god och skriv in text på registreringsskylt eller minska till sju tecken.");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else err = true;
            }
            Console.WriteLine();
            regPlate = regPlate.ToUpper(); // Gör att tecken i strängen till VERSALER (som på en reg. skylt).

            Console.Clear();
            string color ="";
            err = false;
            while (!err){ // Loop som frågar efter färg på bilen och lägger i variabel. Loop för att kunna felhantera.
                Console.Write("Önskad färg på bilen: ");
                color = Console.ReadLine();
                if(string.IsNullOrEmpty(color)){ // Hanterar ev. tom sträng.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Var god och skriv in önskad färg.");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else err = true;
            }

            Console.Clear();
            string model ="";
            err = false;
            while (!err){ // Loop som frågar efter bilmärke på bilen och lägger i variabel.
                Console.Write("Önskat bilmärke: ");
                model = Console.ReadLine();
                if(string.IsNullOrEmpty(model)){ // Hanterar ev. tom sträng.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Var god och skriv in önskad bilmodell.");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else err = true;
            }
            Console.Clear();
            orderedCars.Add(new Car(regPlate, color, model)); // Lägger till det nya objektet i listan för typen.
            Console.WriteLine();
            Console.WriteLine("Du har beställt en bil med denna konfigurationen:");
            Console.WriteLine();
            int lastCar = orderedCars.Count - 1;
            orderedCars[lastCar].whritePropertyForCar(); // Skriver i konsolen ut specifikationerna på den nybeställda produkten.
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att återgå till beställningsmenyn.");
            Console.ReadKey();   
        }

        public void whritePropertyForCar(){ // Metod för att i konsolen skriva ut specifikationen på ett objekt av klasstypen.

            Console.WriteLine($"Text på registreringsskylt: {regNumber}");
            Console.WriteLine($"Färg: {color}");
            Console.WriteLine($"Bilmärke: {model}");
        }

        public static void printListCars(List<Car> orderedCars){ // Metod för att i konsolen skriva ut specifikationen på varje objekt av klasstypen som ligger i listan för klassen.

            if (orderedCars.Count > 0){ // Kollar om det finns objekt i listan
                int amountCars = 1;
                Console.WriteLine("*** Beställda bilar ***");

                foreach (var carInfo in orderedCars){ // Foreach-loop skriver ut specifikation för varje objekt i listan, samt numrerar varje beställning av typen.
                    Console.WriteLine();
                    Console.WriteLine($"Bil nr: {amountCars}");
                    carInfo.whritePropertyForCar();
                    Console.WriteLine();   
                    amountCars++;
                }
            }
            else {
                Console.WriteLine("*** Du har inga beställda bilar! ***"); // Skrivs ut om det inte finns några objekt i listan.
                Console.WriteLine();
            };
        }
    }
}