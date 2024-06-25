namespace TechnicalServicesAPI.DataBase
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<RatingType> RatingTypes { get; set; } //C
        public DbSet<PaymentType> PaymentTypes { get; set; } //C

        public DbSet<MainService> MainServices { get; set; } //C
        public DbSet<ExtendService> ExtendServices { get; set; } //C
        public DbSet<User> Users { get; set; } //C
        public DbSet<UserFeedBack> UsersFeedBack { get; set; } //C
        public DbSet<UserFeedBackRating> UsersFeedBackRatings { get; set; } //C
        public DbSet<UserFeedBackResponse> UserFeedBackResponses { get; set; } //C
        public DbSet<UserIncom> UsersIncoms { get; set; } //C
        public DbSet<UserNotifcation> UsersNotifcations { get; set; } //C
        public DbSet<UserPayment> UsersPayments { get; set; } //C

        public DbSet<Admin> Admins { get; set; } //C

        public DbSet<Technician> Technicians { get; set; } //C
        public DbSet<TechnicianStatus> TechnicianStatus { get; set; } //C
        public DbSet<TechniciansServices> TechniciansServices { get; set; } //C
        public DbSet<TechniciansRating> TechniciansRatings { get; set; } //C
        public DbSet<TechnicianFeedBack> TechniciansFeedBack { get; set; } //C
        public DbSet<TechnicianFeedBackResponse> TechnicianFeedBackResponses { get; set; } //C

        public DbSet<Response> Responses { get; set; } //C
        public DbSet<OrderStatus> OrderStatus { get; set; } //C
        public DbSet<Order> Orders { get; set; } //C

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(p => p.SignUpDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<UserNotifcation>().Property(p => p.DateTime).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Order>()
                   .HasOne(o => o.ChosenResponse)
                   .WithMany()
                   .HasForeignKey(o => o.ChosenResponseId)
                   .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>().HasIndex(p => p.ChosenResponseId).IsUnique();
            modelBuilder.Entity<Order>().HasIndex(p => p.OrderNumber).IsUnique();

            modelBuilder.Entity<User>().HasIndex(p => p.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(p => p.PhoneNumber).IsUnique();

            modelBuilder.Entity<Technician>().HasIndex(p => p.UserId).IsUnique();
            modelBuilder.Entity<Technician>().HasIndex(p => p.UserName).IsUnique();
            modelBuilder.Entity<Technician>().HasIndex(p => p.SocialSecurityNumber).IsUnique();

            modelBuilder.Entity<Admin>().HasIndex(p => p.UserName).IsUnique();
            modelBuilder.Entity<Admin>().HasIndex(p => p.SocialSecurityNumber).IsUnique();
            modelBuilder.Entity<Admin>().HasIndex(p => p.Email).IsUnique();
            modelBuilder.Entity<Admin>().HasIndex(p => p.PhoneNumber).IsUnique();

            modelBuilder.Entity<TechniciansRating>().HasIndex(p => new { p.TechnicianId, p.RatingTypeId }).IsUnique();

            modelBuilder.Entity<TechniciansServices>().HasIndex(p => new { p.TechnicianId, p.ExtendServiceId }).IsUnique();

            modelBuilder.Entity<UserFeedBackRating>().HasIndex(p => new { p.UserFeedBackId, p.RatingTypeId }).IsUnique();

            modelBuilder.Entity<Response>().HasIndex(p => new { p.TechnicianId, p.OrderId }).IsUnique();

            modelBuilder.HasSequence<long>("OrderNumberSequence");

            modelBuilder.Entity<Order>().Property(P => P.OrderNumber).HasDefaultValueSql("NEXT VALUE FOR OrderNumberSequence");
        }
    }
}