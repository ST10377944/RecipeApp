using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace RecipeApp
{
    public partial class ViewRecipesWindow : Window
    {
        private RecipeManager recipeManager;

        public ViewRecipesWindow(RecipeManager recipeManager)
        {
            InitializeComponent();
            this.recipeManager = recipeManager;

            // Bind recipes to the ListBox
            RecipesListBox.ItemsSource = recipeManager.GetRecipes().Select(r => r.Name).ToList();
        }

        private void RecipesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Ensure SelectedItem is not null and is a string
            if (RecipesListBox.SelectedItem is string selectedRecipeName && !string.IsNullOrEmpty(selectedRecipeName))
            {
                // Find the selected recipe by name
                Recipe selectedRecipe = recipeManager.GetRecipes().FirstOrDefault(r => r.Name == selectedRecipeName);

                if (selectedRecipe != null)
                {
                    // Build the recipe details string
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"Recipe Name: {selectedRecipe.Name}");
                    sb.AppendLine();
                    sb.AppendLine("Ingredients:");

                    foreach (var ingredient in selectedRecipe.Ingredients)
                    {
                        sb.AppendLine($"{ingredient.Name}: {ingredient.Quantity} {GetUnit(ingredient.Name)} - {ingredient.Calories} calories - Food Group: {ingredient.FoodGroup ?? "N/A"}");
                    }

                    sb.AppendLine();
                    sb.AppendLine("Steps:");

                    foreach (var step in selectedRecipe.Steps)
                    {
                        sb.AppendLine(step);
                    }

                    sb.AppendLine();
                    sb.AppendLine($"Total Calories: {selectedRecipe.Ingredients.Sum(i => i.Calories)}");

                    if (selectedRecipe.Ingredients.Sum(i => i.Calories) > 300)
                    {
                        sb.AppendLine("Warning: This recipe exceeds 300 calories.");
                    }

                    RecipeDetailsTextBlock.Text = sb.ToString();
                }
                else
                {
                    RecipeDetailsTextBlock.Text = "Recipe details not found.";
                }
            }
            else
            {
                RecipeDetailsTextBlock.Text = string.Empty; // Clear the text if no recipe is selected
            }
        }

        // Helper method to get the unit based on ingredient name (dummy implementation)
        private string GetUnit(string ingredientName)
        {
            // Replace with actual logic to determine unit based on ingredient name
            return "units"; // Dummy implementation
        }
    }
}









