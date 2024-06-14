using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace RecipeApp
{
    public class RecipeManager
    {
        private List<Recipe> recipes;

        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public List<Recipe> GetRecipes()
        {
            return recipes;
        }

        public string GetRecipeDetails(string recipeName)
        {
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Recipe: {recipe.Name}");
                sb.AppendLine("Ingredients:");
                foreach (var ingredient in recipe.Ingredients)
                {
                    sb.AppendLine($"{ingredient.Name}: {ingredient.Quantity} {GetUnit(ingredient.Name)} - {ingredient.Calories} calories - Food Group: {ingredient.FoodGroup ?? "N/A"}");
                }
                sb.AppendLine("Steps:");
                foreach (var step in recipe.Steps)
                {
                    sb.AppendLine(step);
                }
                sb.AppendLine($"Total Calories: {recipe.Ingredients.Sum(i => i.Calories)}");
                if (recipe.Ingredients.Sum(i => i.Calories) > 300)
                {
                    sb.AppendLine("Warning: This recipe exceeds 300 calories.");
                }
                return sb.ToString();
            }
            else
            {
                return "Recipe not found.";
            }
        }

        public void ScaleRecipe(string recipeName, double scaleFactor)
        {
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    ingredient.Quantity *= scaleFactor;
                }
            }
            else
            {
                MessageBox.Show("Recipe not found.");
            }
        }

        public void ClearRecipes()
        {
            recipes.Clear();
            Console.WriteLine("All recipes cleared.");
        }

        private string GetUnit(string ingredientName)
        {
            return "grams"; // Example implementation; adjust as needed
        }
    }
}


