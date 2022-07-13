using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per Init_Admin
/// </summary>
public class Init_Admin
{
    public Init_Admin()
    {
        //
        // TODO: aggiungere qui la logica del costruttore
        //



        using (AdminContext db = new AdminContext())
        {
            // Create standard pages
            db.Pages.Add(new Page() { Code="1", Name= "Home page" });
            db.Pages.Add(new Page() { Code="2", Name= "About" });
            db.Pages.Add(new Page() { Code="3", Name= "Contacts"});
            db.Pages.Add(new Page() { Code="4", Name= "Services" });

            // add standard functions

            db.SaveChanges();
        }


        /*
           string sqlConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ccwebgrity;Data Source=SURAJIT\SQLEXPRESS";
        string script = File.ReadAllText(@"E:\Project Docs\MX462-PD\MX756_ModMappings1.sql");
        SqlConnection conn = new SqlConnection(sqlConnectionString);
        Server server = new Server(new ServerConnection(conn));
        server.ConnectionContext.ExecuteNonQuery(script);*/
    }

    public class Page
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid PageID { get; set; }
        public string Code { get; set; }
        [Required, StringLength(250)] public string Name { get; set; }
        [StringLength(250)] public string Title { get; set; }
        [StringLength(250)] public string URL { get; set; }
        [Column(TypeName = "text")] public string Content { get; set; }
        [StringLength(250)] public string HeaderImage { get; set; }
        [StringLength(250)] public string MetaTag { get; set; }
        [StringLength(250)] public string MetaDescription { get; set; }
        [StringLength(250)] public string SocialTitle { get; set; }
        [StringLength(250)] public string SocialDesc { get; set; }
        [StringLength(250)] public string SocialImage { get; set; }
        public DateTime DateIns {
            get
            {
                return dateCreated.HasValue
                   ? dateCreated.Value
                   : DateTime.Now;
            }

            set { dateCreated = value; }
        }
        private DateTime? dateCreated = null;

        //public virtual List<Post> Posts { get; set; }
    }
    [Table("Blog-Categories")] public class BlogCategory
    {
        public BlogCategory()
        {
            Visible = true;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid CategoryID { get; set; }
        [Required, StringLength(250)] public string CategoryName { get; set; }
        [Required, StringLength(250)] public string CategoryImage { get; set; }
        public bool Visible { get; set; }
        public DateTime DateIns
        {
            get
            {
                return dateCreated.HasValue
                   ? dateCreated.Value
                   : DateTime.Now;
            }

            set { dateCreated = value; }
        }
        private DateTime? dateCreated = null;
        [Column(TypeName = "text")] public string Content { get; set; }
        //public virtual List<Post> Posts { get; set; }
    }
    [Table("Blog-Post_Gallery")] public class BlogPostPhoto
    {
        public BlogPostPhoto()
        {
            Visible = true;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid PhotoID { get; set; }
        [Required] public Guid PostID { get; set; }
        [Required, StringLength(250)] public string PhotoName { get; set; }
        [Required, StringLength(250)] public string PhotoPath { get; set; }
        [Required, StringLength(250)] public string PhotoDescription { get; set; }
        public bool Visible { get; set; }
        public DateTime DateIns
        {
            get
            {
                return dateCreated.HasValue
                   ? dateCreated.Value
                   : DateTime.Now;
            }

            set { dateCreated = value; }
        }
        private DateTime? dateCreated = null;
        [Column(TypeName = "text")] public string Content { get; set; }
        //public virtual List<Post> Posts { get; set; }
    }
    [Table("Blog-Posts")] public class BlogPost
    {
        public BlogPost()
        {
            Visible = true;
            Views = 0;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid PostID { get; set; }
        [Required, StringLength(250)] public string Name { get; set; }
        [StringLength(250)] public string Image { get; set; }
        [StringLength(250)] public string VideoUrl { get; set; }
        [Column(TypeName = "text")] public string Content { get; set; }
        [Column(TypeName = "text")] public string Description { get; set; }
        [Column(TypeName = "text")] public string Tags { get; set; }
        public Guid CategoryID { get; set; }
        public Guid PublisherID { get; set; }
        [StringLength(250)] public string MetaTag { get; set; }
        [StringLength(250)] public string MetaDescription { get; set; }
        [StringLength(250)] public string SocialTitle { get; set; }
        [StringLength(250)] public string SocialDesc { get; set; }
        [StringLength(250)] public string SocialImage { get; set; }
        public bool Visible { get; set; }
        public int Views { get; set; }

        public DateTime DateIns
        {
            get
            {
                return dateCreated.HasValue
                   ? dateCreated.Value
                   : DateTime.Now;
            }

            set { dateCreated = value; }
        }
        private DateTime? dateCreated = null;

        //public virtual List<Post> Posts { get; set; }
    }
    [Table("Blog-Publishers")] public class BlogPublisher
    {
        public BlogPublisher()
        {
            Visible = true;
            Views = 0;
        }
        [Key] public Guid PublisherID { get; set; }
        [Required, StringLength(250)] public string Name { get; set; }
        [StringLength(250)] public string Middlename { get; set; }
        [Required, StringLength(250)] public string Surname { get; set; }
        [StringLength(250)] public string Image { get; set; }
        [StringLength(250)] public string Email { get; set; }
        [StringLength(50)] public string Gender { get; set; }
        [StringLength(50)] public string Phone { get; set; }
        [StringLength(250)] public string Mobile { get; set; }
        [StringLength(50)] public string Facebook { get; set; }
        [StringLength(50)] public string Instagram { get; set; }
        [StringLength(50)] public string TikTok { get; set; }
        [StringLength(50)] public string Linkedin { get; set; }
        [StringLength(50)] public string Dribble { get; set; }
        [Column(TypeName = "text")] public string Bio { get; set; }
        [Column(TypeName = "text")] public string Tags { get; set; }
        [StringLength(250)] public string MetaTag { get; set; }
        [StringLength(250)] public string MetaDescription { get; set; }
        [StringLength(250)] public string SocialTitle { get; set; }
        [StringLength(250)] public string SocialDesc { get; set; }
        [StringLength(250)] public string SocialImage { get; set; }
        public bool Visible { get; set; }
        public int Views { get; set; }

        public DateTime DateIns
        {
            get
            {
                return dateCreated.HasValue
                   ? dateCreated.Value
                   : DateTime.Now;
            }

            set { dateCreated = value; }
        }
        private DateTime? dateCreated = null;

        //public virtual List<Post> Posts { get; set; }
    }
    public class Gallery
    {
        public Gallery()
        {
            Visible = true;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid ID { get; set; }
        [Required, StringLength(250)] public string Title { get; set; }
        [StringLength(250)] public string TextContent { get; set; }
        [Required, StringLength(250)] public string ImageUrl { get; set; }
        public Guid CategoryID { get; set; }
        [StringLength(250)] public string CustomUrl { get; set; }
        [StringLength(50)] public string PositionNo { get; set; }
        [Column(TypeName = "text")] public string Tags { get; set; }
        [StringLength(250)] public string MetaTag { get; set; }
        [StringLength(250)] public string MetaDescription { get; set; }
        [StringLength(250)] public string SocialTitle { get; set; }
        [StringLength(250)] public string SocialDesc { get; set; }
        [StringLength(250)] public string SocialImage { get; set; }
        public bool Visible { get; set; }
        public int Views { get; set; }

        public DateTime DateIns
        {
            get
            {
                return dateCreated.HasValue
                   ? dateCreated.Value
                   : DateTime.Now;
            }

            set { dateCreated = value; }
        }
        private DateTime? dateCreated = null;

        //public virtual List<Post> Posts { get; set; }
    }
    public class News
    {
        public News()
        {
            Visible = true;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid NewsID { get; set; }
        [Required, StringLength(250)] public string Title { get; set; }
        [StringLength(250)] public string TextContent { get; set; }
        [Required, StringLength(250)] public string ImageUrl { get; set; }
        public Guid CategoryID { get; set; }
        [StringLength(250)] public string CustomUrl { get; set; }
        [StringLength(50)] public string PositionNo { get; set; }
        [Column(TypeName = "text")] public string Tags { get; set; }
        [StringLength(250)] public string MetaTag { get; set; }
        [StringLength(250)] public string MetaDescription { get; set; }
        [StringLength(250)] public string SocialTitle { get; set; }
        [StringLength(250)] public string SocialDesc { get; set; }
        [StringLength(250)] public string SocialImage { get; set; }
        public bool Visible { get; set; }
        public int Views { get; set; }

        public DateTime DateIns
        {
            get
            {
                return dateCreated.HasValue
                   ? dateCreated.Value
                   : DateTime.Now;
            }

            set { dateCreated = value; }
        }
        private DateTime? dateCreated = null;

        //public virtual List<Post> Posts { get; set; }
    }
    public class Service
    {
        public Service()
        {
            Visible = true;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid ServiceID { get; set; }
        [StringLength(250)] public string Code { get; set; }
        [StringLength(250)] public string HeaderImage { get; set; }
        [Required, StringLength(250)] public string Title { get; set; }
        public Guid CategoryID { get; set; }
        [Column(TypeName = "text")] public string Content { get; set; }
        [Column(TypeName = "text")] public string Tags { get; set; }
        [StringLength(250)] public string MetaTag { get; set; }
        [StringLength(250)] public string MetaDescription { get; set; }
        [StringLength(250)] public string SocialTitle { get; set; }
        [StringLength(250)] public string SocialDesc { get; set; }
        [StringLength(250)] public string SocialImage { get; set; }
        public bool Visible { get; set; }
        public int Views { get; set; }

        public DateTime DateIns
        {
            get
            {
                return dateCreated.HasValue
                   ? dateCreated.Value
                   : DateTime.Now;
            }

            set { dateCreated = value; }
        }
        private DateTime? dateCreated = null;

        //public virtual List<Post> Posts { get; set; }
    }


    [Table("CORE_Functions")] public class CORE_Function
    {
        public CORE_Function()
        {
            Visible = true;
        }
        [Key, StringLength(100)] public string FunctionID { get; set; }
        [Required, StringLength(256)] public string Name { get; set; }
        [StringLength(256)] public string Description { get; set; }
        [StringLength(50)] public string Version { get; set; }
        [StringLength(256)] public string Icon { get; set; }
        public bool Visible { get; set; }
        [StringLength(256)] public string URL { get; set; }
        public int Priority { get; set; }
        public DateTime DateIns
        {
            get
            {
                return dateCreated.HasValue
                   ? dateCreated.Value
                   : DateTime.Now;
            }

            set { dateCreated = value; }
        }
        private DateTime? dateCreated = null;

        //public virtual List<Post> Posts { get; set; }
    }
    [Table("CORE_SubFunctions")] public class CORE_SubFunction
    {
        public CORE_SubFunction()
        {
            Visible = true;
        }
        [Key, StringLength(100)] public string SubFunctionID { get; set; }
        [Required, StringLength(100)] public string FunctionID { get; set; }
        [Required, StringLength(256)] public string Name { get; set; }
        [StringLength(256)] public string Description { get; set; }
        [StringLength(50)] public string Version { get; set; }
        [StringLength(256)] public string Icon { get; set; }
        public bool Visible { get; set; }
        public int Priority { get; set; }
        public DateTime DateIns
        {
            get
            {
                return dateCreated.HasValue
                   ? dateCreated.Value
                   : DateTime.Now;
            }

            set { dateCreated = value; }
        }
        private DateTime? dateCreated = null;

        //public virtual List<Post> Posts { get; set; }
    }

    public class AdminContext : DbContext
    {
        public AdminContext() : base("DefaultConnectionString") {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AdminContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AdminContext>());
        }
        public DbSet<Page> Pages { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogPostPhoto> BlogPostPhotos { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogPublisher> BlogPublishers { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Service> Services { get; set; }

        public DbSet<CORE_Function> CORE_Functions { get; set; }
        public DbSet<CORE_SubFunction> CORE_SubFunctions { get; set; }
    }
}