using Swift.Db;
using System;

namespace SwiftInitializator
{
    public class DbInitializer
    {
        public static void ResetDatabase(SwiftContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Console.WriteLine("DataBase is reset");
        }
    }
}