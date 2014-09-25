namespace _07.TwoContextsProblem
{
    using System;
    using System.Linq;
    using NorthwindDB;

    /// <summary>
    /// Try to open two different data contexts and perform concurrent changes on the same records. 
    /// What will happen at SaveChanges()? How to deal with it?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities db1 = new NorthwindEntities();
            NorthwindEntities db2 = new NorthwindEntities();

            //Categories can be added simultaneously
            for (int i = 0; i < 10; i++)
            {
                db1.Categories.Add(new Category()
                {
                    CategoryName = "NewCategory" + i
                });
                db2.Categories.Add(new Category()
                {
                    CategoryName = "NewCategory" + i
                });
                db1.SaveChanges();
                db2.SaveChanges();
            }

            //Editin same entry
            var firstEntry = db1.Categories.Where((x) => x.CategoryName == "NewCategory0").First();
            firstEntry.CategoryName = "Lol";

            var sameEntry = db2.Categories.Where(x => x.CategoryName == "NewCategory0").First();

            db2.Categories.Remove(sameEntry);

            //Removing an entry before editing it throws an exception
            //db2.SaveChanges();
            db1.SaveChanges();
        }
    }
}
