namespace FoodSystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FoodSystem.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public Model1()
            : base("name=Model1")
        {
        }
        public DbSet<FoodSystem.Models.customer> Customer { get; set; }
        public DbSet<FoodSystem.Models.category> Category { get; set; }
        public DbSet<FoodSystem.Models.detail> Detail { get; set; }
        public DbSet<FoodSystem.Models.bill> Bill { get; set; }
        public DbSet<FoodSystem.Models.manager> Manager { get; set; }
        public DbSet<FoodSystem.Models.menu> Menu { get; set; }
        public DbSet<FoodSystem.Models.order> Order { get; set; }
        public DbSet<FoodSystem.Models.restaurant> Restaurant { get; set; }
        public DbSet<FoodSystem.Models.restaurant_category> Restaurant_Category { get; set; }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}