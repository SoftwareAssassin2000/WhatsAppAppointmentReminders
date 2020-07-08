using System;

using ef = Microsoft.EntityFrameworkCore;

using AppointmentReminders.DataAccess.TightlyCoupledModel;

namespace AppointmentReminders.DataAccess
{
    internal class DbContext : ef.DbContext, IDisposable
    {
        internal ef.DbSet<User> Users { get; set; }
        internal ef.DbSet<Appointment> Appointments { get; set; }

        #region Construction/Destruction

        internal DbContext()
            : this("Server=localhost;Database=AppointmentReminders;Trusted_Connection=True;")
        { }
        internal DbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

		private static ef.DbContextOptions GetOptions(string connectionString)
        {
            return ef.SqlServerDbContextOptionsExtensions.UseSqlServer(new ef.DbContextOptionsBuilder(), connectionString).Options;
        }

        #endregion

        protected override void OnModelCreating(ef.ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Appointment>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
