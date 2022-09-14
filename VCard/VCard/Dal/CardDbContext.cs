
using Microsoft.EntityFrameworkCore;

public class CardDbContext:DbContext
    {
     public DbSet<Card> Cards { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-15FAUDE\\SQLEXPRESS; database=CardDb; Trusted_Connection=True;");
        }
    }
}
