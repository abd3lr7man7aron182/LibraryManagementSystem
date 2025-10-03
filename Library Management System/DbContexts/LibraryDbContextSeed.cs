using Library_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library_Management_System.DbContexts
{
    internal static class LibraryDbContextSeed
    {
        public static bool SeedData(LibraryDbContext dbContext)
        {
            //to make both two savechange as a one transaction 
            var transaction=dbContext.Database.BeginTransaction();
            try
            {
                dbContext.Database.Migrate();

                bool HasAuthors = dbContext.Authors.Any();
                bool HasCategories = dbContext.Categories.Any();
                bool HasBooks = dbContext.Books.Any();
                bool HasMembers = dbContext.Members.Any();


                if (HasAuthors && HasCategories && HasBooks && HasMembers)
                    return false;

                //order of seeding is important here -> fk ,pk
                if (!HasAuthors)
                {
                    var Authers = LoadData<Author>("Files/Authors.json");
                    dbContext.Authors.AddRange(Authers);
                }

                if (!HasCategories)
                {
                    var Categories = LoadData<Category>("Files/Categories.json");
                    dbContext.Categories.AddRange(Categories);
                }

                //must savechanges becouse of order of seeding 
                dbContext.SaveChanges();

                if (!HasBooks)
                {
                    var Books = LoadData<Book>("Files/Books.json");
                    dbContext.Books.AddRange(Books);
                }

                if (!HasMembers)
                {
                    var Memebers = LoadData<Member>("Files/Members.json");
                    dbContext.Members.AddRange(Memebers);
                }
                dbContext.SaveChanges();
                transaction.Commit();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                transaction.Rollback();
                return false;
            }
        }


        private static List<T> LoadData<T>(string filepath)
        {
            if (!File.Exists(filepath)) throw new FileNotFoundException("Not Found || Wrong Path");

            string data = File.ReadAllText(filepath);


            //becouse of names  of properties is  may be different
            var option = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            //becouse of Deserialize can't convert enums to string
            option.Converters.Add(new JsonStringEnumConverter());


            return JsonSerializer.Deserialize<List<T>>(data, option) ?? new List<T>();
        }
    }
}
