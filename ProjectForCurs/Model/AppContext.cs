using Microsoft.EntityFrameworkCore;

namespace ProjectForCurs.Model;

internal sealed class AppContext : DbContext
{
    private const string _connectionString 
        = @"Data source=C:\sqlite\course.db";
    
    public DbSet<Profile> Profiles { set; get; }
    public DbSet<Movie> Movies { set; get; }
    public DbSet<PaymentMethod> PaymentMethods { set; get; }
    public DbSet<Subscribe> Subscribes { set; get; }
    public DbSet<User> Users { set; get; }
    public DbSet<History> Histories { set; get; }

    public AppContext() =>
        Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite(_connectionString);
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SetKeyOption(modelBuilder);
        SetUniqueOptions(modelBuilder);
        
        SetProfileOption(modelBuilder);
        SetMovieOption(modelBuilder);
        SetPaymentMethodsOption(modelBuilder);
        
            
        SetForeignKeys(modelBuilder);

        modelBuilder.Entity<Subscribe>()
            .HasKey(s => s.Id);
        
    }

    private void SetProfileOption(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Profile>()
            .Property(p => p.Nickname)
            .IsRequired()
            .HasMaxLength(50);
        
        modelBuilder.Entity<Profile>()
            .Property(p => p.Nickname)
            .IsRequired()
            .HasMaxLength(50);
        
        modelBuilder.Entity<Profile>()
            .Property(p => p.Name)
            .IsUnicode()
            .IsRequired()
            .HasMaxLength(50);
        
        modelBuilder.Entity<Profile>()
            .Property(p => p.Surname)
            .IsUnicode()
            .IsRequired()
            .HasMaxLength(50);
        
        modelBuilder.Entity<Profile>()
            .Property(p => p.LastName)
            .IsUnicode()
            .IsRequired()
            .HasMaxLength(50);
        
        modelBuilder.Entity<Profile>()
            .Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<Profile>()
            .Property(p => p.IsAdmin)
            .IsRequired();
    }

    private void SetMovieOption(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .Property(m => m.Name)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(50);
        
        modelBuilder.Entity<Movie>()
            .Property(m => m.OriginName)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(50);
        
        modelBuilder.Entity<Movie>()
            .Property(m => m.Description)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(100);
    }

    private void SetPaymentMethodsOption(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PaymentMethod>()
            .Property(p => p.NumberOfCard)
            .IsRequired()
            .HasMaxLength(19);
        
        modelBuilder.Entity<PaymentMethod>()
            .Property(p => p.TheHoldersName)
            .IsRequired()
            .HasMaxLength(50);
        
        modelBuilder.Entity<PaymentMethod>()
            .Property(p => p.Cvc)
            .IsRequired()
            .HasMaxLength(3);

        modelBuilder.Entity<PaymentMethod>()
            .Property(p => p.DeadLine)
            .IsRequired()
            .HasColumnType("DATE");
    }

    private void SetSubscribeOption(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Subscribe>()
            .Property(p => p.Name)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(50);
        
        modelBuilder.Entity<Subscribe>()
            .Property(p => p.Name)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(50);
        
        modelBuilder.Entity<Subscribe>()
            .Property(p => p.Price)
            .IsRequired();
    }
    
    private void SetKeyOption(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);
        
        modelBuilder.Entity<Profile>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<PaymentMethod>()
            .HasKey(p => p.Id);
        
        modelBuilder.Entity<Movie>()
            .HasKey(m => m.Id);
        
        modelBuilder.Entity<History>()
            .HasKey(h => h.Id);
    }

    private void SetUniqueOptions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Subscribe>()
            .HasIndex(s => s.Name)
            .IsUnique();

        modelBuilder.Entity<Profile>()
            .HasIndex(p => p.Nickname)
            .IsUnique();

        modelBuilder.Entity<Profile>()
            .HasIndex(p => p.Email)
            .IsUnique();
        
        modelBuilder.Entity<Subscribe>()
            .HasIndex(s => s.Name)
            .IsUnique();
    }

    private void SetForeignKeys(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Profile>()
            .HasOne(p => p.User)
            .WithOne(u => u.Profile)
            .HasForeignKey<User>(u => u.Id)
            .HasPrincipalKey<Profile>(p => p.Id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Subscribe>()
            .HasMany(s => s.Users)
            .WithOne(u => u.Subscribe)
            .HasForeignKey(u => u.SubscribeId)
            .HasPrincipalKey(s => s.Id)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<User>()
            .HasMany(u => u.PaymentMethods)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .HasPrincipalKey(u => u.Id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Histories)
            .WithOne(h => h.User)
            .HasForeignKey(h => h.UserId)
            .HasPrincipalKey(u => u.Id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Movie>()
            .HasMany(m => m.Histories)
            .WithOne(h => h.Movie)
            .HasForeignKey(h => h.MovieId)
            .HasPrincipalKey(m => m.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}