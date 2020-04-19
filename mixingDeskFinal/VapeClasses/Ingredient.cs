namespace mixingDeskFinal.VapeClasses
{
    /// <summary>
    /// Represents an Ingredient(as a Flavouring and usagePercentage) in a recipe. 
    /// </summary>
    public class Ingredient
    {
        
        public string FlavouringName { get; set; }
        public double UsagePercentage { set; get; }

        public Ingredient(string FlavouringName, double UsagePercentage)
        {
            //this.FlavouringObject = FlavouringObject;
            this.FlavouringName = FlavouringName;
            this.UsagePercentage = UsagePercentage;
        }
    }
}
