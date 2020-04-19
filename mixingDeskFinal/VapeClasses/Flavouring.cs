namespace mixingDeskFinal.VapeClasses
{
    /// <summary>
    /// Represents a flavouring.
    /// </summary>
    public class Flavouring
    {
        public string Name { get; set; }
        public int VersionNumber { get; set; } 

        public bool InPersonalStash { set; get; }

        public string CompanyManufacturer { get; set; }

        public Flavouring()
        {

        }
        
        public Flavouring(string name, int versionNumber, bool inPersonalStash, string companyManufacturer)
        {
            Name = name;
            VersionNumber = versionNumber;
            InPersonalStash = inPersonalStash;
            CompanyManufacturer = companyManufacturer;
        }

    
    }
}
