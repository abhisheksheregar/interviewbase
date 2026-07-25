using interviewbase.Models;
using Microsoft.EntityFrameworkCore;

namespace interviewbase
{
  public class AppDbContext:DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
          
    }

  public DbSet<Topics> Topics { get; set; }
  public DbSet<QuestionList> QuestionList   { get; set; }
  }
}
