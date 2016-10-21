namespace WebApiEF {
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EducationContext : DbContext {
        // Your context has been configured to use a 'EducationContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebApiEF.EducationContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EducationContext' 
        // connection string in the application configuration file.
        public EducationContext()
            : base("name=EducationContext") {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Major> Majors { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}