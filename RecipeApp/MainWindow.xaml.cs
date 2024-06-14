using System;
using System.Windows;

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        private RecipeManager recipeManager;

        public MainWindow()
        {
            InitializeComponent();
            recipeManager = new RecipeManager();

            // Adding pre-existing recipes
            AddPreExistingRecipes();
        }

        private void AddPreExistingRecipes()
        {
            Recipe creamyMashedPotatoes = new Recipe
            {
                Name = "Creamy Mashed Potatoes"
            };
            creamyMashedPotatoes.Ingredients.Add(new Ingredient { Name = "Potatoes", Quantity = 500, Calories = 200, FoodGroup = "Vegetables" });
            creamyMashedPotatoes.Ingredients.Add(new Ingredient { Name = "Butter", Quantity = 50, Calories = 350, FoodGroup = "Dairy" });
            creamyMashedPotatoes.Steps.Add("Peel and boil the potatoes until soft.");
            creamyMashedPotatoes.Steps.Add("Mash the potatoes and mix with butter.");
            recipeManager.AddRecipe(creamyMashedPotatoes);

            Recipe grilledChickenWings = new Recipe
            {
                Name = "Grilled Chicken Wings"
            };
            grilledChickenWings.Ingredients.Add(new Ingredient { Name = "Chicken Wings", Quantity = 800, Calories = 1200, FoodGroup = "Meat" });
            grilledChickenWings.Ingredients.Add(new Ingredient { Name = "BBQ Sauce", Quantity = 100, Calories = 300, FoodGroup = "Condiments" });
            grilledChickenWings.Steps.Add("Marinate chicken wings in BBQ sauce for 1 hour.");
            grilledChickenWings.Steps.Add("Grill chicken wings until fully cooked.");
            recipeManager.AddRecipe(grilledChickenWings);
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow addRecipeWindow = new AddRecipeWindow(recipeManager);
            addRecipeWindow.ShowDialog();
        }

        private void ViewRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            ViewRecipesWindow viewRecipesWindow = new ViewRecipesWindow(recipeManager);
            viewRecipesWindow.ShowDialog();
        }

        private void ClearRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            recipeManager.ClearRecipes();
            MessageBox.Show("All recipes cleared.");
        }

        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the recipe you want to scale:", "Scale Recipe", "");
            if (!string.IsNullOrEmpty(recipeName))
            {
                double scaleFactor;
                if (double.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Enter the scaling factor (e.g., 1.5 for 150%):", "Scale Recipe", ""), out scaleFactor))
                {
                    recipeManager.ScaleRecipe(recipeName, scaleFactor);
                    MessageBox.Show("Recipe scaled successfully!");
                }
                else
                {
                    MessageBox.Show("Invalid scaling factor.");
                }
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
