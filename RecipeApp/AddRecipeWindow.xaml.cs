using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RecipeApp
{
    public partial class AddRecipeWindow : Window
    {
        private RecipeManager recipeManager;

        public AddRecipeWindow(RecipeManager recipeManager)
        {
            InitializeComponent();
            this.recipeManager = recipeManager;

            // Add event handlers to dynamically add ingredient and step fields
            NumIngredientsTextBox.LostFocus += NumIngredientsTextBox_LostFocus;
            NumStepsTextBox.LostFocus += NumStepsTextBox_LostFocus;
        }

        private void NumIngredientsTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumIngredientsTextBox.Text, out int numIngredients))
            {
                IngredientsPanel.Children.Clear();
                for (int i = 0; i < numIngredients; i++)
                {
                    StackPanel panel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(5) };

                    TextBox nameBox = new TextBox { Width = 100, Margin = new Thickness(5) };
                    TextBlock namePlaceholder = new TextBlock { Text = "Name", Foreground = Brushes.Black, IsHitTestVisible = false };
                    nameBox.GotFocus += (s, e) => namePlaceholder.Visibility = Visibility.Collapsed;
                    nameBox.LostFocus += (s, e) => namePlaceholder.Visibility = string.IsNullOrWhiteSpace(nameBox.Text) ? Visibility.Visible : Visibility.Collapsed;
                    panel.Children.Add(nameBox);
                    panel.Children.Add(namePlaceholder);

                    TextBox quantityBox = new TextBox { Width = 100, Margin = new Thickness(5) };
                    TextBlock quantityPlaceholder = new TextBlock { Text = "Quantity", Foreground = Brushes.Black, IsHitTestVisible = false };
                    quantityBox.GotFocus += (s, e) => quantityPlaceholder.Visibility = Visibility.Collapsed;
                    quantityBox.LostFocus += (s, e) => quantityPlaceholder.Visibility = string.IsNullOrWhiteSpace(quantityBox.Text) ? Visibility.Visible : Visibility.Collapsed;
                    panel.Children.Add(quantityBox);
                    panel.Children.Add(quantityPlaceholder);

                    TextBox caloriesBox = new TextBox { Width = 100, Margin = new Thickness(5) };
                    TextBlock caloriesPlaceholder = new TextBlock { Text = "Calories", Foreground = Brushes.Black, IsHitTestVisible = false };
                    caloriesBox.GotFocus += (s, e) => caloriesPlaceholder.Visibility = Visibility.Collapsed;
                    caloriesBox.LostFocus += (s, e) => caloriesPlaceholder.Visibility = string.IsNullOrWhiteSpace(caloriesBox.Text) ? Visibility.Visible : Visibility.Collapsed;
                    panel.Children.Add(caloriesBox);
                    panel.Children.Add(caloriesPlaceholder);

                    TextBox foodGroupBox = new TextBox { Width = 100, Margin = new Thickness(5) };
                    TextBlock foodGroupPlaceholder = new TextBlock { Text = "Food Group", Foreground = Brushes.Black, IsHitTestVisible = false };
                    foodGroupBox.GotFocus += (s, e) => foodGroupPlaceholder.Visibility = Visibility.Collapsed;
                    foodGroupBox.LostFocus += (s, e) => foodGroupPlaceholder.Visibility = string.IsNullOrWhiteSpace(foodGroupBox.Text) ? Visibility.Visible : Visibility.Collapsed;
                    panel.Children.Add(foodGroupBox);
                    panel.Children.Add(foodGroupPlaceholder);

                    IngredientsPanel.Children.Add(panel);
                }
            }
        }

        private void NumStepsTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumStepsTextBox.Text, out int numSteps))
            {
                StepsPanel.Children.Clear();
                for (int i = 0; i < numSteps; i++)
                {
                    TextBox stepBox = new TextBox { Width = 200, Margin = new Thickness(5) };
                    TextBlock stepPlaceholder = new TextBlock { Text = $"Step {i + 1}", Foreground = Brushes.Black, IsHitTestVisible = false };
                    stepBox.GotFocus += (s, e) => stepPlaceholder.Visibility = Visibility.Collapsed;
                    stepBox.LostFocus += (s, e) => stepPlaceholder.Visibility = string.IsNullOrWhiteSpace(stepBox.Text) ? Visibility.Visible : Visibility.Collapsed;
                    StepsPanel.Children.Add(stepBox);
                    StepsPanel.Children.Add(stepPlaceholder);
                }
            }
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            Recipe recipe = new Recipe
            {
                Name = RecipeNameTextBox.Text
            };

            foreach (StackPanel panel in IngredientsPanel.Children)
            {
                TextBox nameBox = (// continued from previous snippet

                TextBox)panel.Children[0];
                TextBox quantityBox = (TextBox)panel.Children[2];
                TextBox caloriesBox = (TextBox)panel.Children[4];
                TextBox foodGroupBox = (TextBox)panel.Children[6];

                Ingredient ingredient = new Ingredient
                {
                    Name = nameBox.Text,
                    Quantity = double.Parse(quantityBox.Text),
                    Calories = double.Parse(caloriesBox.Text),
                    FoodGroup = foodGroupBox.Text
                };
                recipe.Ingredients.Add(ingredient);
            }

            foreach (TextBox stepBox in StepsPanel.Children.OfType<TextBox>())
            {
                recipe.Steps.Add(stepBox.Text);
            }

            recipeManager.AddRecipe(recipe);
            MessageBox.Show("Recipe added successfully!");
            Close();
        }
    }
}





