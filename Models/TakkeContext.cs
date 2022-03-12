using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Takke.Models
{
    public partial class TakkeContext : DbContext
    {
        public TakkeContext()
        {
        }

        public TakkeContext(DbContextOptions<TakkeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActivationCode> ActivationCodes { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Cardrift> Cardrifts { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientPayment> ClientPayments { get; set; }
        public virtual DbSet<Cobon> Cobons { get; set; }
        public virtual DbSet<Detaile> Detailes { get; set; }
        public virtual DbSet<Driftpassenger> Driftpassengers { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<DriverPayment> DriverPayments { get; set; }
        public virtual DbSet<DriverSalary> DriverSalaries { get; set; }
        public virtual DbSet<FavouriteAddress> FavouriteAddresses { get; set; }
        public virtual DbSet<FavouriteType> FavouriteTypes { get; set; }
        public virtual DbSet<Massage> Massages { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderType> OrderTypes { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Smsconfig> Smsconfigs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Takke;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<ActivationCode>(entity =>
            {
                entity.ToTable("Activation_code");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("Client_id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.CreatingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Creating_date");

                entity.Property(e => e.RegisterationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registeration_date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ActivationCodes)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activation_code_Client");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car_");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CarModel)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Car_Model")
                    .IsFixedLength(true);

                entity.Property(e => e.CarNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Car_number")
                    .IsFixedLength(true);

                entity.Property(e => e.DriverId).HasColumnName("Driver_id");

                entity.Property(e => e.Madeyear).HasColumnName("madeyear");

                entity.Property(e => e.Manufacture)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("manufacture");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.TarvelDistance)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("tarvel_distance")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Car__Driver");
            });

            modelBuilder.Entity<Cardrift>(entity =>
            {
                entity.ToTable("cardrift");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnnData)
                    .HasColumnType("date")
                    .HasColumnName("annData");

                entity.Property(e => e.Arriveaddress)
                    .HasMaxLength(300)
                    .HasColumnName("arriveaddress");

                entity.Property(e => e.Arrivelocation)
                    .HasMaxLength(100)
                    .HasColumnName("arrivelocation");

                entity.Property(e => e.Cartype)
                    .HasMaxLength(50)
                    .HasColumnName("cartype");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Departaddress)
                    .HasMaxLength(300)
                    .HasColumnName("departaddress");

                entity.Property(e => e.Departdate)
                    .HasColumnType("date")
                    .HasColumnName("departdate");

                entity.Property(e => e.Departlocation)
                    .HasMaxLength(100)
                    .HasColumnName("departlocation");

                entity.Property(e => e.Departtime).HasColumnName("departtime");

                entity.Property(e => e.Numofclients).HasColumnName("numofclients");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Cardrifts)
                    .HasForeignKey(d => d.Clientid)
                    .HasConstraintName("FK_cardrift_Client");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.ClientId).HasColumnName("Client_id");

                entity.Property(e => e.ClientBirthday)
                    .HasColumnType("datetime")
                    .HasColumnName("Client_Birthday");

                entity.Property(e => e.ClientGender).HasColumnName("Client_gender");

                entity.Property(e => e.ClientMobile)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Client_Mobile")
                    .IsFixedLength(true);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Client_name")
                    .IsFixedLength(true);

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(50)
                    .HasColumnName("Client_number")
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Mainphoto)
                    .HasMaxLength(200)
                    .HasColumnName("mainphoto");

                entity.Property(e => e.Notes)
                    .HasMaxLength(100)
                    .HasColumnName("notes")
                    .IsFixedLength(true);

                entity.Property(e => e.RegisterationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registeration_date");

                entity.Property(e => e.Token)
                    .HasMaxLength(300)
                    .HasColumnName("token");
            });

            modelBuilder.Entity<ClientPayment>(entity =>
            {
                entity.ToTable("Client_payment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("Client_id");

                entity.Property(e => e.Isfromorder).HasColumnName("isfromorder");

                entity.Property(e => e.Paymentdate)
                    .HasColumnType("datetime")
                    .HasColumnName("paymentdate");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientPayments)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_payment_Client");
            });

            modelBuilder.Entity<Cobon>(entity =>
            {
                entity.ToTable("Cobon");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActivationCode)
                    .HasColumnType("datetime")
                    .HasColumnName("Activation_code");

                entity.Property(e => e.ClientId).HasColumnName("Client_id");

                entity.Property(e => e.CobonValue).HasColumnName("Cobon_value");

                entity.Property(e => e.Cobontype).HasColumnName("cobontype");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Creation_date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Cobons)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cobon_Client");
            });

            modelBuilder.Entity<Detaile>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Detailname)
                    .HasMaxLength(100)
                    .HasColumnName("detailname");

                entity.Property(e => e.Detailvalue)
                    .HasMaxLength(100)
                    .HasColumnName("detailvalue");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Detailes)
                    .HasForeignKey(d => d.Clientid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detailes_Client");
            });

            modelBuilder.Entity<Driftpassenger>(entity =>
            {
                entity.ToTable("driftpassenger");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Driftid).HasColumnName("driftid");

                entity.Property(e => e.Isapproved).HasColumnName("isapproved");

                entity.Property(e => e.Ispayed).HasColumnName("ispayed");

                entity.Property(e => e.Requestdate)
                    .HasColumnType("date")
                    .HasColumnName("requestdate");

                entity.Property(e => e.Requesttime).HasColumnName("requesttime");

                entity.HasOne(d => d.Drift)
                    .WithMany(p => p.Driftpassengers)
                    .HasForeignKey(d => d.Driftid)
                    .HasConstraintName("FK_driftpassenger_cardrift");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("Driver");

                entity.Property(e => e.DriverId).HasColumnName("Driver_id");

                entity.Property(e => e.Certificate)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("certificate");

                entity.Property(e => e.DriverBirthday)
                    .HasColumnType("date")
                    .HasColumnName("Driver_birthday");

                entity.Property(e => e.DriverGender)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Driver_gender");

                entity.Property(e => e.DriverName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Driver_name");

                entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("mobile");

                entity.Property(e => e.Registerationdate)
                    .HasColumnType("date")
                    .HasColumnName("registerationdate");
            });

            modelBuilder.Entity<DriverPayment>(entity =>
            {
                entity.ToTable("Driver_payment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DriverId).HasColumnName("Driver_id");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Payment_date");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.DriverPayments)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Driver_payment_Driver");
            });

            modelBuilder.Entity<DriverSalary>(entity =>
            {
                entity.ToTable("Driver_salary");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.DriverId).HasColumnName("Driver_id");

                entity.Property(e => e.ReceiptNumber).HasColumnName("receipt_number");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.DriverSalaries)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Driver_salary_Driver");
            });

            modelBuilder.Entity<FavouriteAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK_Favorit_address");

                entity.ToTable("Favourite_address");

                entity.Property(e => e.AddressId)
                    .ValueGeneratedNever()
                    .HasColumnName("Address_id");

                entity.Property(e => e.ClientId).HasColumnName("Client_id");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Typeid).HasColumnName("typeid");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.FavouriteAddresses)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Favourite_address_Client");
            });

            modelBuilder.Entity<FavouriteType>(entity =>
            {
                entity.ToTable("Favourite_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Typename).HasColumnName("typename");

                entity.HasOne(d => d.TypenameNavigation)
                    .WithMany(p => p.FavouriteTypes)
                    .HasForeignKey(d => d.Typename)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Favorit_type_Order_Type");
            });

            modelBuilder.Entity<Massage>(entity =>
            {
                entity.ToTable("Massage");

                entity.Property(e => e.MassageId).HasColumnName("Massage_ID");

                entity.Property(e => e.ClientId).HasColumnName("Client_id");

                entity.Property(e => e.Isread).HasColumnName("isread");

                entity.Property(e => e.MassageType).HasColumnName("Massage_type");

                entity.Property(e => e.MessageContent)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("Message_content");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Phone_Number");

                entity.Property(e => e.ReadDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Read_date");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Massages)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Massage_Client");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification_");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("Client_id");

                entity.Property(e => e.IsRead).HasColumnName("Is_read");

                entity.Property(e => e.NotificationId).HasColumnName("Notification_id");

                entity.Property(e => e.NotificationText)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("Notification_text");

                entity.Property(e => e.Notificationdate)
                    .HasColumnType("date")
                    .HasColumnName("notificationdate");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification__Client");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.Property(e => e.ApproximateCost).HasColumnName("Approximate_cost");

                entity.Property(e => e.Arrivingtime)
                    .HasColumnType("datetime")
                    .HasColumnName("arrivingtime");

                entity.Property(e => e.ClientId).HasColumnName("Client_id");

                entity.Property(e => e.Clientarrivingtime)
                    .HasColumnType("datetime")
                    .HasColumnName("clientarrivingtime");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.DestenationDetails)
                    .HasMaxLength(100)
                    .HasColumnName("Destenation_details");

                entity.Property(e => e.DestenationLocation)
                    .HasMaxLength(100)
                    .HasColumnName("destenation_location")
                    .IsFixedLength(true);

                entity.Property(e => e.DriverId).HasColumnName("Driver_id");

                entity.Property(e => e.Driverarrivingtime)
                    .HasColumnType("datetime")
                    .HasColumnName("driverarrivingtime");

                entity.Property(e => e.Estimatedarrivingtime)
                    .HasColumnType("datetime")
                    .HasColumnName("estimatedarrivingtime");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Order_date");

                entity.Property(e => e.OrderType).HasColumnName("order_type");

                entity.Property(e => e.Orderstarttime)
                    .HasColumnType("datetime")
                    .HasColumnName("orderstarttime");

                entity.Property(e => e.SourceDetails)
                    .HasMaxLength(100)
                    .HasColumnName("Source_details");

                entity.Property(e => e.SourceLocation)
                    .HasMaxLength(100)
                    .HasColumnName("source_location")
                    .IsFixedLength(true);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.Waitingtime)
                    .HasColumnType("datetime")
                    .HasColumnName("waitingtime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Client");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Driver");
            });

            modelBuilder.Entity<OrderType>(entity =>
            {
                entity.ToTable("Order_Type");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.Typename)
                    .HasMaxLength(100)
                    .HasColumnName("typename");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.OrderTypeNavigation)
                    .HasForeignKey<OrderType>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Type_Order");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("Price");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientWaitingPrice).HasColumnName("client_waiting_price");

                entity.Property(e => e.DriverWaitingPrice).HasColumnName("driver_waiting_price");

                entity.Property(e => e.HourPrice).HasColumnName("Hour_price");

                entity.Property(e => e.KmPrice).HasColumnName("KM_price");

                entity.Property(e => e.LatencyPrice).HasColumnName("latency_price");

                entity.Property(e => e.LowestDistance).HasColumnName("lowest_distance");

                entity.Property(e => e.LowestPrice).HasColumnName("Lowest_Price");

                entity.Property(e => e._10000Cobon).HasColumnName("10000_Cobon");

                entity.Property(e => e._25000Cobon).HasColumnName("25000_Cobon");

                entity.Property(e => e._5000Cobon).HasColumnName("5000_Cobon");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("settings");

                entity.Property(e => e.Entryname)
                    .HasMaxLength(100)
                    .HasColumnName("entryname");

                entity.Property(e => e.Entrytype)
                    .HasMaxLength(100)
                    .HasColumnName("entrytype");

                entity.Property(e => e.Entryvalue)
                    .HasMaxLength(100)
                    .HasColumnName("entryvalue");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<Smsconfig>(entity =>
            {
                entity.ToTable("smsconfigs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
