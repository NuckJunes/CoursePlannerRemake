using CoursePlanner_Backend.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoursePlanner_Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public IConfiguration _config { get; set; }

        public ApplicationDbContext(IConfiguration config)
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Major> Majors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.schedules)
                .WithOne(e => e.user);

            modelBuilder.Entity<Class>()
                .HasOne(e => e.schedule)
                .WithMany(e => e.classes);

            modelBuilder.Entity<Class>()
                .HasOne(e => e.course)
                .WithMany(e => e.Classes);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Features)
                .WithMany(e => e.Courses);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Campuses)
                .WithMany(e => e.Courses);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Sections)
                .WithMany(e => e.Courses);

            modelBuilder.Entity<Section>()
                .HasOne(e => e.Major)
                .WithMany(e => e.Sections);

            // Seed All Data From Below Here //



            Campus hamilton = new Campus { Id = 1, Name = "Hamilton"};
            Campus luxembourg = new Campus { Id = 2, Name = "Luxembourg"};
            Campus middletown = new Campus { Id = 3, Name = "Middletown"};
            Campus oxford = new Campus { Id = 4, Name = "Oxford"};
            Campus westChester = new Campus { Id = 5, Name = "West Chester"};

            Feature advancedWriting = new Feature { Id = 1, Name = "Advanced Writing", Short_Name = "PA"};
            Feature creativeArts = new Feature { Id = 2, Name = "Creative Arts", Short_Name = "PA" };

            modelBuilder.Entity<Campus>().HasData(hamilton);
            modelBuilder.Entity<Campus>().HasData(luxembourg);
            modelBuilder.Entity<Campus>().HasData(middletown);
            modelBuilder.Entity<Campus>().HasData(oxford);
            modelBuilder.Entity<Campus>().HasData(westChester);
            modelBuilder.Entity<Feature>().HasData(advancedWriting);
            modelBuilder.Entity<Feature>().HasData(creativeArts);

            Course STC135 = new Course { Id = 1, Name = "Principles of Public Speaking"
                ,Description = "Develops fundamentals of analyzing, organizing, adapting, and delivering ideas effectively in public contexts. Special emphasis placed upon informative and persuasive discourse."
                ,Credit_Hours = 3.0
                ,Subject = "STC"
                ,Course_Number = 135
                ,PreRequisites = ""};

            modelBuilder.Entity<Course>().HasData(STC135);
            modelBuilder.Entity("CampusCourse").HasData(new {CampusesId = 4, CoursesId = 1 });

            Course APC231 = new Course { Id = 2, Name = "Small Group Communication"
                ,Description = "Theoretical issues that affect communication between members of work teams, discussion groups, and decision-making bodies. Students study these theories and related research studies and work as members of student teams to analyze critically both the theoretical and practical implications of the theories and research studies."
                ,Credit_Hours = 3.0
                ,Subject = "APC"
                ,Course_Number = 231
                ,PreRequisites = ""};

            modelBuilder.Entity<Course>().HasData(APC231);
            modelBuilder.Entity("CampusCourse").HasData(new { CampusesId = 4, CoursesId = 2 });

            Course MTH151 = new Course { Id = 3, Name = "Calculus I"
                ,Description = "Topics include limits and continuity, derivatives and their applications, and early integration techniques of polynomial, rational, radical, trigonometric, inverse trigonometric, exponential, and logarithmic functions. It is expected that students have completed a trigonometry or pre-calculus course and possess the following pre-requisite knowledge: factoring polynomials, working with fractional exponents, finding the domain of functions, properties of common functions such as polynomial, absolute value, exponential, logarithmic, trigonometric, and rational functions, solving a variety of types of equations, inverse functions, graphing, and other related topics"
                ,Credit_Hours = 4.0
                ,Subject = "MTH"
                ,Course_Number = 151
                ,PreRequisites = ""};

            modelBuilder.Entity<Course>().HasData(MTH151);
            modelBuilder.Entity("CampusCourse").HasData(new { CampusesId = 4, CoursesId = 3 });

            Course MTH231 = new Course { Id = 4, Name = "Elements of Discrete Mathematics"
                ,Description = "Service course. Topics, techniques and terminology in discrete mathematics: logic, sets, proof by mathematical induction, relations, counting. Credit does not count toward a major in the department of Mathematics or Statistics."
                ,Credit_Hours = 3.0
                ,Subject = "MTH"
                ,Course_Number = 231
                ,PreRequisites = ""};

            modelBuilder.Entity<Course>().HasData(MTH231);
            modelBuilder.Entity("CampusCourse").HasData(
                new { CampusesId = 4, CoursesId = 4 },
                new { CampusesId = 1, CoursesId = 4});

            //Has prereq of MTH222, MTH249/MTH251
            Course MTH331 = new Course { Id = 5, Name = "Proof: Introduction to Higher Mathematics"
                ,Description = "Designed to ease the transition to 400-level courses in mathematics and statistics. The emphasis of the course is on writing and analyzing mathematical proofs. Topics covered will be foundational for higher level courses and will include propositional and predicate logic, methods of proof, induction, sets, relations, and functions."
                ,Credit_Hours = 3.0
                ,Subject = "MTH"
                ,Course_Number = 331
                ,PreRequisites = ""};

            modelBuilder.Entity<Course>().HasData(MTH331);
            modelBuilder.Entity("CampusCourse").HasData(new { CampusesId = 4, CoursesId = 5 });

            Major software = new Major { Id = 1, Name = "Software Engineering", Graduate = false, College = "College of Computer Science", Credit_Min = 92.0, Credit_Max = 98.0};
            modelBuilder.Entity<Major>().HasData(software);

            Section core = new Section { Id = 1, Name = "Core Requirements", Major = software, Credit_Min = 3, Credit_Max = 3, Courses = new List<Course>() {STC135, APC231} };
            Section math = new Section { Id = 2, Name = "Mathematics", Major = software, Credit_Min = 7, Credit_Max = 7, Courses = new List<Course>() {MTH151, MTH231, MTH331} };
            //modelBuilder.Entity<Section>().HasData(core);
            //modelBuilder.Entity<Section>().HasData(math);
            //modelBuilder.Entity("CourseSection").HasData(
              //  new {CoursesId = 1, SectionsId = 1},
                //new {CoursesId = 2, SectionsId = 1},
                //new {CoursesId = 3, SectionsId = 2},
                //new {CoursesId = 4, SectionsId = 2 },
                //new {CoursesId = 5, SectionsId = 2 });

            User user1 = new User { Id = 1, Admin = false, Email = "Email@Email.com", Password = "Password" , Username = "Username" };
            modelBuilder.Entity<User>().HasData(user1);

            //modelBuilder.Entity("Schedules").HasData(new { Id = 1, Name = "User1 schedule", userId = 1 });
            //modelBuilder.Entity("Classes").HasData(new {Id = 1, courseId = 1, scheduleId = 1, semester = "Spring", year = 2});

        }
    }
}
