string path = @"E:\Workspace\C#\CookieCookBookApp\availableRecipes.txt";

List<Recipe> recipesList = new List<Recipe>();

Console.WriteLine("Create a new cookie recipe !");

LoadAvailableRecipes();


foreach (Recipe recipe in recipesList)
{
    Console.WriteLine($"{recipe.ID}-{recipe.Name}.");
}

Console.WriteLine("#################");

AddNewRecipe();

Console.ReadKey();


void LoadAvailableRecipes()
{
    string line;
    try
    {
        var recipesFileReader = new StreamReader(path);
        line = recipesFileReader.ReadLine();

        while (line != null)
        {
            string[] recipe = line.Split(",");

            string ID = recipe[0].Split("-")[0];
            string Name = recipe[0].Split("-")[1];
            string Instructions = recipe[1].Trim();

            Recipe newRecipe = new Recipe() { ID = ID, Name = Name, Instructions = Instructions };

            recipesList.Add(newRecipe);

            line = recipesFileReader.ReadLine();
        }

        recipesFileReader.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}


void AddNewRecipe()
{
    Console.WriteLine("Do you want to add a new recipe ? [Y] / [n] ");
    string? userResponse = Console.ReadLine();

    switch (userResponse)
    {
        case "Y":
        case "y":

            bool shallExit = false;

            do
            {
                int ID = recipesList.Count + 1;

                Console.WriteLine("Please add recipe's name : ");
                string Name = Console.ReadLine();

                Console.WriteLine("Now add the recipe's instructions : ");
                string Instructions = Console.ReadLine();

                if (Name.Trim().Length == 0 || Instructions.Trim().Length == 0)
                {
                    Console.WriteLine("Please enter valid informations ...");
                }
                else
                {
                    Recipe newRecipe = new Recipe()
                    {
                        ID = ID.ToString(),
                        Name = Name,
                        Instructions = Instructions
                    };

                    recipesList.Add(newRecipe);
                    Console.WriteLine("Recipe added successfully!");

                    ListAllRecipes();
                    shallExit = true;
                }
            } while (!shallExit);
            break;
        default:
            Console.ReadKey();
            break;
    }

    Console.WriteLine("Press any key to quit ...");

}

void ListAllRecipes()
{
    foreach (Recipe recipe in recipesList)
    {
        Console.WriteLine($"{recipe.ID} - {recipe.Name}");
        Console.WriteLine($"***Instructions : {recipe.Instructions}");
    }
}