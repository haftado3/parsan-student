using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace com_parsan_student.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Ali", Family = "Alavi" },
                new Student { Id = 2, Name = "Mohammad", Family = "Mohammadi" },
                new Student { Id = 3, Name = "Hadi", Family = "Mahmoodi" },
                new Student { Id = 4, Name = "Mahdi", Family = "khalili" }
            );
        }

    }

    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
    }
}