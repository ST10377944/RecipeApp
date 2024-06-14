using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Recipe
{
    public string Name { get; set; } = "";
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public List<string> Steps { get; set; } = new List<string>();
}