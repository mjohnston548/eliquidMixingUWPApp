using System;
using System.Collections.Generic;


namespace mixingDeskFinal.VapeClasses
{
    /// <summary>
    /// Represents a Recipe.
    /// </summary>
    public class Recipe
    {
        public string Name { set; get; }

        public string CreatorName { set; get; }

        public string Notes { set; get; }

        public double Rating { set; get; }

        public DateTime DateOfCreation { set; get; }

        public List<Ingredient> Ingredients { set; get; }

        public static int ingredientsMaxSize = 7; 

        public Recipe() { }

        public Recipe( DateTime DateOfCreation, List<Ingredient> Ingredients, string Name = "Untitled", string CreatorName="Unknown")
        {
            this.Name = Name;
            this.CreatorName = CreatorName;
            this.DateOfCreation = DateOfCreation;
            this.Ingredients = Ingredients;
        }

        
    }
}
