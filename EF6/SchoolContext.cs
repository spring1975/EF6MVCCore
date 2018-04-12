using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using EF6.Models;

namespace EF6
{
    #region snippet_Constructor
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolContext")
        {
            FixEntityFrameworkDllNotDeploying();
            EnableTraceIfDebug(this);
        }
        public SchoolContext(string connectionString) : base(connectionString)
        {
            FixEntityFrameworkDllNotDeploying();
        }

        /*
         * DO NOT REMOVE! Work around known defect in entity framework described here: 
         * https://social.msdn.microsoft.com/Forums/en-US/b348a0c2-94d9-4db5-a041-b81a97e76b3f/entityframeworksqlserver-not-deploying?forum=adodotnetentityframework 
         */
        private void FixEntityFrameworkDllNotDeploying()
        {
            //By removing EF from the web project, the dll no longer gets copied
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            if (type == null)
            {
                throw new Exception("Do not remove, ensures static reference to System.Data.Entity.SqlServer");
            }
        }

        [Conditional("DEBUG")]
        private static void EnableTraceIfDebug(SchoolContext db)
        {
            db.Database.Log = s => Debug.WriteLine(s);
        }
        
        #endregion

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}