using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Windows.Storage;
using System.IO;
using mixingDeskFinal.VapeClasses;
using System.Collections.ObjectModel;

namespace mixingDeskFinal.DatabaseClasses
{
    public static class DataAccess
    {
        /// <summary>
        /// This method deals with all database related interaction.
        /// </summary>
        public async static void InitializeDatabase()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("sqliteSample.db", CreationCollisionOption.OpenIfExists);
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample.db");


            //Create the database tables.
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                
                db.Open();

                SqliteCommand createTable = new SqliteCommand(System.IO.File.ReadAllText(@"Assets/createTables.sql"), db);

                createTable.ExecuteReader();

                       
            }
            //insert companies data
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand(System.IO.File.ReadAllText(@"Assets/insertCompanies.sql"), db);
                insertCommand.ExecuteReader();
            }
            //insert flavouring data
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                
                db.Open();
                
                SqliteCommand insertCommand = new SqliteCommand(System.IO.File.ReadAllText(@"Assets/insertFlavourings.sql"), db);

                insertCommand.ExecuteNonQuery();
            }
            //insert recipe data
            
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand(System.IO.File.ReadAllText(@"Assets/insertRecipes.sql"), db);

                insertCommand.ExecuteNonQuery();
            }
        }
        
        
       

        /// <summary>
        /// Returns a list of flavouring objects. the data comes from rows in the flavourings table where inPersonalStash=1. This method might be made more general later.
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Flavouring> GetFlavouringData()
        {
            ObservableCollection<Flavouring> flavourings = new ObservableCollection<Flavouring>();

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT name, (SELECT name FROM companies WHERE companies.idNumbC=flavourings.companyName_FK)," +
                    "versionNumber FROM flavourings WHERE inPersonalStash=1", db);

                //SqliteCommand selectCommand = new SqliteCommand(selectCommand, db);
                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    Flavouring tempFlavour = new Flavouring();
                    tempFlavour.Name = query.GetString(0);
                    tempFlavour.CompanyManufacturer = query.GetString(1);
                    tempFlavour.VersionNumber = query.GetInt32(2);



                    flavourings.Add(tempFlavour);
                }


            }

            return flavourings;
        }

        /// <summary>
        /// Returns a list of recipe data from the database table from a given time frame of either week, month or year.
        /// </summary>
        /// <param name="timeFrame"></param>
        /// <returns></returns>
        public static List<Recipe> GetRecipeData(string timeFrame)
        {
            List<Recipe> recipes = new List<Recipe>();

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                string commandString;

                /*These queries may look excessive but full information for each recipe must be loaded on the relevant recipe pages so that the Specific Recipe Page 
                 has information to load*/
                switch (timeFrame)
                {
                    case "week":
                        commandString = "SELECT name, creatorName, notes, postDate, rating,(SELECT name FROM flavourings WHERE flavourings.idNumbF=recipes.flav_1_FK), flav_1Percent," +
                            "(SELECT name FROM flavourings WHERE flavourings.idNumbF = recipes.flav_2_FK), flav_2Percent," +
                            "(SELECT name FROM flavourings WHERE flavourings.idNumbF = recipes.flav_3_FK), flav_3Percent," +
                            "(SELECT name FROM flavourings WHERE flavourings.idNumbF = recipes.flav_4_FK), flav_4Percent," +
                            "(SELECT name FROM flavourings WHERE flavourings.idNumbF = recipes.flav_5_FK), flav_5Percent," +
                            "(SELECT name FROM flavourings WHERE flavourings.idNumbF = recipes.flav_6_FK), flav_6Percent," +
                            "(SELECT name FROM flavourings WHERE flavourings.idNumbF = recipes.flav_7_FK), flav_7Percent   " +
                            "FROM recipes WHERE postDate > datetime('now', '-7 day')";
 
                        break;
                    case "month":
                        commandString = "SELECT name, creatorName, notes, postDate, rating,(SELECT name FROM flavourings WHERE flavourings.idNumbF=recipes.flav_1_FK), flav_1Percent, " +
                            "(SELECT name FROM flavourings WHERE flavourings.idNumbF=recipes.flav_2_FK), flav_2Percent, " +
                            "(SELECT name FROM flavourings WHERE flavourings.idNumbF=recipes.flav_3_FK), flav_3Percent, " +
                            "(SELECT name FROM flavourings WHERE flavourings.idNumbF=recipes.flav_4_FK), flav_4Percent, " +
                            "(SELECT name FROM flavourings WHERE flavourings.idNumbF=recipes.flav_5_FK), flav_5Percent, " +
                            "(SELECT name FROM flavourings WHERE flavourings.idNumbF=recipes.flav_6_FK), flav_6Percent," +
                            "(SELECT name FROM flavourings WHERE flavourings.idNumbF=recipes.flav_7_FK), flav_7Percent " +
                            " FROM recipes WHERE postDate > datetime('now','-1 month')";
                        break;
                    case "year":
                        //problems are probably here
                        commandString = "SELECT name, creatorName, notes, postDate, rating,(SELECT name FROM flavourings WHERE flavourings.idNumbF=recipes.flav_1_FK), flav_1Percent, " +
                            "(SELECT name FROM flavourings WHERE flavourings.idNumbF=recipes.flav_2_FK), flav_2Percent, " +
                            "(SELECT name FROM flavourings WHERE flavourings.idNumbF=recipes.flav_3_FK), flav_3Percent, " +
                            "(SELECT name FROM flavourings WHERE flavourings.idNumbF=recipes.flav_4_FK), flav_4Percent, " +
                            "(SELECT name FROM flavourings WHERE flavourings.idNumbF=recipes.flav_5_FK), flav_5Percent, " +
                            "(SELECT name FROM flavourings WHERE flavourings.idNumbF=recipes.flav_6_FK), flav_6Percent," +
                            "(SELECT name FROM flavourings WHERE flavourings.idNumbF=recipes.flav_7_FK), flav_7Percent " +
                            
                            " FROM recipes WHERE postDate > datetime('now','-1 year')";
                        break;

                    default:
                        commandString = "";
                        break;
                }

                SqliteCommand selectCommand = new SqliteCommand(commandString, db);

                SqliteDataReader query = selectCommand.ExecuteReader();
                
                while (query.Read())
                {
                    //recipes.Add(MakeRecipeFromData(query));
                    Recipe tempRecipe = new Recipe();
                    tempRecipe.Name = query.GetString(0);
                    
                    tempRecipe.CreatorName = SafeGetString(query, 1);
                    
                    tempRecipe.Notes = SafeGetString(query,2);

                    tempRecipe.DateOfCreation = query.GetDateTime(3);
                    tempRecipe.Rating = query.GetDouble(4);
                    List<Ingredient> tempIngredients = new List<Ingredient>();

                    
                    
                    for (int i = 0; i < Recipe.ingredientsMaxSize*2; i=i+2)
                    {
                        try
                        {
                            tempIngredients.Add(new Ingredient(query.GetString(i + 5), query.GetDouble(i + 6)));
                            
                        }
                        catch (Exception)
                        {
                            //catch errors and do nothing

                        }
                    }
                                                                             
                    tempRecipe.Ingredients = tempIngredients;
                    recipes.Add(tempRecipe);
                }


            }
            return recipes;

        }
        /// <summary>
        /// Returns a string from the database query where the data may be null.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        public static string SafeGetString(SqliteDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }
        /// <summary>
        /// Returns a double from the database query where the data may be null.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        public static double SafeGetDouble(SqliteDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetDouble(colIndex);
            return double.NaN;
        }
        

                
        /// <summary>
        /// Removes items from the personal stash.
        /// </summary>
        public static void removeFromPersonalStash(string flavourName)
        {
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand deleteCommand = new SqliteCommand();
                deleteCommand.Connection = db;

                deleteCommand.CommandText = $"UPDATE flavourings SET inPersonalStash=0 WHERE name='{flavourName}'";
                deleteCommand.ExecuteNonQuery();

                db.Close();

            }
        }
    }
}
