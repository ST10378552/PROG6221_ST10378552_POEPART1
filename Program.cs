
using RecipesApp;
using System;

class Program
{
    static void Main(string[] args)
    {
        Recipe recipe = new Recipe();
        string userInput;
        bool exit = false;

        Console.ForegroundColor = ConsoleColor.White; // Set text color to white
        Console.WriteLine("Welcome to the Recipe App!\n");

        while (!exit)
        {
            DisplayMenu();
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    AddIngredient(recipe);
                    break;
                case "2":
                    AddStep(recipe);
                    break;
                case "3":
                    recipe.DisplayRecipe();
                    break;
                case "4":
                    ScaleRecipe(recipe);
                    break;
                case "5":
                    ResetRecipe(recipe);
                    break;
                case "6":
                    ClearRecipe(recipe);
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red; // Set text color to red for error message
                    Console.WriteLine("Invalid input. Please try again.\n");
                    Console.ForegroundColor = ConsoleColor.White; // Reset text color
                    break;
            }
        }

        Console.WriteLine("Thank you for using the Recipe App!");
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Menu:");
        Console.ForegroundColor = ConsoleColor.Green; // Set text color to green for menu options
        Console.WriteLine("  \u001b[32m1. Add Ingredient");
        Console.WriteLine("  \u001b[32m2. Add Step");
        Console.WriteLine("  \u001b[32m3. Display Recipe");
        Console.WriteLine("  \u001b[32m4. Scale Recipe");
        Console.WriteLine("  \u001b[32m5. Reset Recipe");
        Console.WriteLine("  \u001b[32m6. Clear Recipe");
        Console.WriteLine("  \u001b[32m7. Exit\n");
        Console.ForegroundColor = ConsoleColor.White; // Reset text color
        Console.Write("Enter your choice: ");
    }

    static void AddIngredient(Recipe recipe)
    {
        string userInput;
        Console.WriteLine("\nAdding Ingredient:");

        do
        {
            Ingredient ingredient = new Ingredient();
            Console.ForegroundColor = ConsoleColor.Green; // Set text color to green for user input
            Console.Write("\nEnter ingredient name: ");
            Console.ForegroundColor = ConsoleColor.White; // Reset text color
            string name = Console.ReadLine();

            // Validate ingredient name
            if (IsString(name))
            {
                ingredient.Name = name;

                double quantity;
                bool validQuantity = false;
                do
                {
                    Console.ForegroundColor = ConsoleColor.Green; /
                    Console.Write("Enter quantity: ");
                    Console.ForegroundColor = ConsoleColor.White; // Reset text color
                    if (double.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                    {
                        validQuantity = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid quantity. Please enter a valid positive number.");
                        Console.ForegroundColor = ConsoleColor.White; // Reset text color
                    }
                } while (!validQuantity);
                ingredient.Quantity = quantity;

                Console.ForegroundColor = ConsoleColor.Green; // Set text color to green for user input
                Console.Write("Enter unit: ");
                Console.ForegroundColor = ConsoleColor.White; // Reset text color
                ingredient.Unit = Console.ReadLine();

                recipe.AddIngredient(ingredient);
                Console.WriteLine("Ingredient added successfully!");

                Console.ForegroundColor = ConsoleColor.Green; // Set text color to green for "yes" option
                Console.Write("\nDo you want to add another ingredient? (yes/no): ");
                Console.ForegroundColor = ConsoleColor.White; // Reset text color
                userInput = Console.ReadLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ingredient name. Please enter a valid string.");
                Console.ForegroundColor = ConsoleColor.White; // Reset text color
                userInput = "yes"; // Continue loop until valid input is provided
            }
        } while (userInput.ToLower() == "yes");
    }

    // Method to check if a string contains only letters and spaces
    static bool IsString(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
                return false;
            }
        }
        return true;
    }

    static void AddStep(Recipe recipe)
    {
        string userInput;
        Console.WriteLine("\nAdding Step:");

        do
        {
            Step step = new Step();
            Console.ForegroundColor = ConsoleColor.Green; // Set text color to green for user input
            Console.Write("\nEnter step description: ");
            Console.ForegroundColor = ConsoleColor.White; // Reset text color
            step.Description = Console.ReadLine();

            recipe.AddStep(step);
            Console.WriteLine("Step added successfully!");

            Console.ForegroundColor = ConsoleColor.Green; // Set text color to green for "yes" option
            Console.Write("\nDo you want to add another step? (yes/no): ");
            Console.ForegroundColor = ConsoleColor.White; // Reset text color
            userInput = Console.ReadLine();
        } while (userInput.ToLower() == "yes");
    }

    static void ScaleRecipe(Recipe recipe)
    {
        double factor;
        bool validInput = false;

        Console.WriteLine("\nScaling Recipe:");

        do
        {
            Console.ForegroundColor = ConsoleColor.Green; // Set text color to green for user input
            Console.Write("\nEnter scaling factor: ");
            Console.ForegroundColor = ConsoleColor.White; // Reset text color
            validInput = double.TryParse(Console.ReadLine(), out factor) && factor > 0;

            if (!validInput)
            {
                Console.ForegroundColor = ConsoleColor.Red; // Set text color to red for error message
                Console.WriteLine("Invalid scaling factor. Please enter a positive number.\n");
                Console.ForegroundColor = ConsoleColor.White; // Reset text color
            }
        } while (!validInput);

        recipe.ScaleRecipe(factor);
        Console.WriteLine("Recipe scaled successfully!");
    }

    static void ResetRecipe(Recipe recipe)
    {
        recipe.ResetRecipe();
        Console.WriteLine("\nRecipe reset successfully!");
    }

    static void ClearRecipe(Recipe recipe)
    {
        recipe.ClearRecipe();
        Console.WriteLine("\nRecipe cleared.");
    }
}




