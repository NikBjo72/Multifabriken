using System;
using System.Collections.Generic;

namespace multifabriken_NikBjo72
{
    class Program
    {
        static void Main(string[] args)
        {
            // Listor för alla typer av produkter
            List<Car> orderedCars = new List<Car>();
            List<Candy> orderedCandy = new List<Candy>();
            List<Lace>  orderedLace = new List<Lace>();
            List<Tofu>  orderedTofu = new List<Tofu>();
            
            bool quit = false; // Boolvariabel som styr när whileloopen ska avslutas

            while (!quit)
            {
                // Inledande text och menyvalen i konsolen
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("*** Välkommen till Multifabriken! ***");
                Console.ResetColor();

                Console.WriteLine();
                Console.WriteLine("I denna menyn kan du välja vilka varor du vill beställa,\nlista valda varor samt avsluta programmet.");
                Console.WriteLine();

                Console.WriteLine("[1] Beställ bil");
                Console.WriteLine("[2] Beställ godis");
                Console.WriteLine("[3] Beställ snöre");
                Console.WriteLine("[4] Beställ tofu");
                Console.WriteLine("[5] Lista din beställning");
                Console.WriteLine("[6] Avsluta programmet");
                Console.WriteLine();
                Console.Write("Ditt val: ");
                string choice = Console.ReadLine();

                switch (choice){ // Switch-sats som hanterar menyvalen

                    case "1":
                        Car.inputPropertyForCar(orderedCars); // Metod i klassen Car, som hanterar inmatad data för att beställa en ny bil. Lägger också till den i listan orderedCars.
                        break;

                    case "2":
                        Candy.inputPropertyForCandy(orderedCandy); // Metod i klassen Candy, som hanterar inmatad data för att beställa nytt godis. Lägger också till den i listan orderedCandy.
                        break;

                    case "3":
                        Lace.inputPropertyForLace(orderedLace); // Metod i klassen Lace, som hanterar inmatad data för att beställa en ntt snöre. Lägger också till den i listan orderedLace.
                        break;

                    case "4":
                        Tofu.inputPropertyForTofu(orderedTofu); // Metod i klassen Tofu, som hanterar inmatad data för att beställa ny tofu. Lägger också till den i listan orderedTofu.
                        break;

                    case "5":
                        Console.Clear();
                        Car.printListCars(orderedCars); // Fyra metoder i de olika klasserna som listar beställda produkter av varje typ.
                        Candy.printListCandy(orderedCandy);
                        Lace.printListLace(orderedLace);
                        Tofu.printListTofu(orderedTofu);
                        Console.WriteLine("Tryck på valfri tangent för att återgå till beställningsmenyn.");
                        Console.ReadKey();
                        break;

                    case "6":
                        quit = true; // Sätter quit till true, så att whileloopen avslutas
                        break;

                    default: // Felmeddelande om användaren inte gör ett val från listan.
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Var god och välj ett nummer ur listan.");
                        Console.ResetColor();
                        Console.WriteLine("Tryck på valfri tangent för att göra ett nytt val.");
                        Console.ReadKey();
                        break;  
                }
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Hej då och tack för din beställning från Multifabriken!"); // Avslutningsmeddelande
            Console.ResetColor();
            Console.WriteLine();
        }  
    }
}
