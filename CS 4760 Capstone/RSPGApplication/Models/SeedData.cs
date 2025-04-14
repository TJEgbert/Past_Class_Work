using Microsoft.EntityFrameworkCore;
using RSPGApplication.Data;


namespace RSPGApplication.Models
{
    public class SeedData
    {
        /// <summary>
        /// Add colleges to the database
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddColleges(IServiceProvider serviceProvider)
        {
            using (var context = new RSPGApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RSPGApplicationContext>>()))
            {
                if (context == null || context.College == null)
                {
                    throw new ArgumentNullException("RSPGApplicationContext");
                }

                if (context.College.Any())
                {
                    return;
                }

                context.College.AddRange(

                    new College
                    {
                        Name = "College of E.A.S.T",
                        Address = "123 street",
                        DeanID = 1
                    },

                    new College
                    {
                        Name = "College of Science",
                        Address = "123 street",
                        DeanID = 1
                    }
                );
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Add departments to the database
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddDepartments(IServiceProvider serviceProvider)
        {
            using (var context = new RSPGApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RSPGApplicationContext>>()))
            {
                if (context == null || context.Department == null)
                {
                    throw new ArgumentNullException("RSPGApplicationContext");
                }

                if (context.Department.Any())
                {
                    return;
                }

                context.Department.AddRange(

                    new Department
                    {
                        Name = "Computer Science",
                        Address = "123 street",
                        CollegeID = 1,
                        ChairID = 1
                    },

                    new Department
                    {
                        Name = "Interior Design",
                        Address = "123 street",
                        CollegeID = 1,
                        ChairID = 1
                    },

                    new Department
                    {
                        Name = "Zoology",
                        Address = "123 street",
                        CollegeID = 2,
                        ChairID = 2
                    },

                    new Department
                    {
                        Name = "Botany and Plant Ecology",
                        Address = "123 street",
                        CollegeID = 2,
                        ChairID = 2
                    }
                );
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Add users to the database
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddUsers(IServiceProvider serviceProvider)
        {
            using (var context = new RSPGApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RSPGApplicationContext>>()))
            {
                if (context == null || context.User == null)
                {
                    throw new ArgumentNullException("RSPGApplicationContext");
                }

                if (context.User.Any())
                {
                    return;
                }
                context.User.AddRange(
                    new User
                    {
                        email = "admin@mail.com",
                        password = PasswordHelper.HashPassword("admin123"),
                        firstName = "Wade",
                        lastName = "Wilson",
                        CollegeId = 1,
                        DepartmentId = 1,
                        position = "Admin",
                        RSPGMember = true,
                        isAdmin = true,
                        isRSPGChair = false,
                        isDean = false,
                        isDepChair = false,
                    },
                    new User
                    {
                        email = "Dean1@mail.com",
                        password = PasswordHelper.HashPassword("dean123"),
                        firstName = "Mad",
                        lastName = "Max",
                        CollegeId = 1,
                        DepartmentId = 1,
                        position = "Dean",
                        RSPGMember = true,
                        isAdmin = false,
                        isRSPGChair = false,
                        isDean = true,
                        isDepChair = false,
                    },
                    new User
                    {
                        email = "Dean2@mail.com",
                        password = PasswordHelper.HashPassword("dean123"),
                        firstName = "Sad",
                        lastName = "Max",
                        CollegeId = 2,
                        DepartmentId = 3,
                        position = "Dean",
                        RSPGMember = true,
                        isAdmin = false,
                        isRSPGChair = false,
                        isDean = true,
                        isDepChair = false,
                    },
                    new User
                    {
                        email = "CSChair@mail.com",
                        password = PasswordHelper.HashPassword("CS123"),
                        firstName = "Joe",
                        lastName = "Rogen",
                        CollegeId = 1,
                        DepartmentId = 1,
                        position = "CSChair",
                        RSPGMember = true,
                        isAdmin = false,
                        isRSPGChair = false,
                        isDean = false,
                        isDepChair = true,
                    },
                    new User
                    {
                        email = "IDChair@mail.com",
                        password = PasswordHelper.HashPassword("ID123"),
                        firstName = "Fern",
                        lastName = "Honigal",
                        CollegeId = 1,
                        DepartmentId = 2,
                        position = "IDChair",
                        RSPGMember = true,
                        isAdmin = false,
                        isRSPGChair = false,
                        isDean = false,
                        isDepChair = true,
                    },
                    new User
                    {
                        email = "ZOOLChair@mail.com",
                        password = PasswordHelper.HashPassword("ZOOL123"),
                        firstName = "Finn",
                        lastName = "Human",
                        CollegeId = 2,
                        DepartmentId = 3,
                        position = "ZOOLChair",
                        RSPGMember = true,
                        isAdmin = false,
                        isRSPGChair = false,
                        isDean = false,
                        isDepChair = true,
                    },
                    new User
                    {
                        email = "BTNYChair@mail.com",
                        password = PasswordHelper.HashPassword("BTNY123"),
                        firstName = "Jake",
                        lastName = "Dog",
                        CollegeId = 2,
                        DepartmentId = 4,
                        position = "BTNYChair",
                        RSPGMember = true,
                        isAdmin = false,
                        isRSPGChair = false,
                        isDean = false,
                        isDepChair = true,
                    },
                    new User
                    {
                        email = "rspg@mail.com",
                        password = PasswordHelper.HashPassword("rspg"),
                        firstName = "Jean",
                        lastName = "Grey",
                        CollegeId = 1,
                        DepartmentId = 2,
                        position = "Professor",
                        RSPGMember = true,
                        isAdmin = false,
                        isRSPGChair = false,
                        isDean = false,
                        isDepChair = false,
                    },
                    new User
                    {
                        email = "prof@mail.com",
                        password = PasswordHelper.HashPassword("prof"),
                        firstName = "Charles",
                        lastName = "Xavier",
                        CollegeId = 2,
                        DepartmentId = 3,
                        position = "Professor",
                        RSPGMember = true,
                        isAdmin = false,
                        isRSPGChair = false,
                        isDean = false,
                        isDepChair = false,
                    },
                    new User
                    {
                        email = "prof2@mail.com",
                        password = PasswordHelper.HashPassword("prof2"),
                        firstName = "James",
                        lastName = "Sadler",
                        CollegeId = 2,
                        DepartmentId = 4,
                        position = "Professor",
                        RSPGMember = true,
                        isAdmin = false,
                        isRSPGChair = false,
                        isDean = false,
                        isDepChair = false,
                    },
                    new User
                    {
                        email = "rspgchair@mail.com",
                        password = PasswordHelper.HashPassword("chair"),
                        firstName = "John",
                        lastName = "Snow",
                        CollegeId = 2,
                        DepartmentId = 3,
                        position = "Professor",
                        RSPGMember = true,
                        isAdmin = false,
                        isRSPGChair = true,
                        isDean = false,
                        isDepChair = false,
                    },
                    new User
                    {
                        email = "gargar@mail.com",
                        password = PasswordHelper.HashPassword("gar"),
                        firstName = "Garland",
                        lastName = "Garner",
                        CollegeId = 1,
                        DepartmentId = 2,
                        position = "Professor",
                        RSPGMember = true,
                        isRSPGChair = false,
                        isAdmin = false,
                        isDean = false,
                        isDepChair = false,
                    },
                    new User
                    {
                        email = "moiodo@mail.com",
                        password = PasswordHelper.HashPassword("moi"),
                        firstName = "Moises",
                        lastName = "Odom",
                        CollegeId = 1,
                        DepartmentId = 2,
                        position = "Professor",
                        RSPGMember = true,
                        isRSPGChair = false,
                        isAdmin = false,
                        isDean = false,
                        isDepChair = false,
                    },

                    new User
                    {
                        email = "moigro@mail.com",
                        password = PasswordHelper.HashPassword("moi"),
                        firstName = "Moises",
                        lastName = "Gross",
                        CollegeId = 1,
                        DepartmentId = 1,
                        position = "Professor",
                        RSPGMember = true,
                        isRSPGChair = false,
                        isAdmin = false,
                        isDean = false,
                        isDepChair = false,
                    },

                    new User
                    {
                        email = "carsch@mail.com",
                        password = PasswordHelper.HashPassword("car"),
                        firstName = "Carroll",
                        lastName = "Schwartz",
                        CollegeId = 2,
                        DepartmentId = 4,
                        position = "Professor",
                        RSPGMember = true,
                        isRSPGChair = false,
                        isAdmin = false,
                        isDean = false,
                        isDepChair = false,
                    },

                    new User
                    {
                        email = "ernsch@mail.com",
                        password = PasswordHelper.HashPassword("ern"),
                        firstName = "Ernest",
                        lastName = "Schwartz",
                        CollegeId = 1,
                        DepartmentId = 1,
                        position = "Professor",
                        RSPGMember = true,
                        isRSPGChair = false,
                        isAdmin = false,
                        isDean = false,
                        isDepChair = false,
                    },

                    new User
                    {
                        email = "aiskir@mail.com",
                        password = PasswordHelper.HashPassword("ais"),
                        firstName = "Aisha",
                        lastName = "Kirk",
                        CollegeId = 2,
                        DepartmentId = 4,
                        position = "Professor",
                        RSPGMember = true,
                        isRSPGChair = false,
                        isAdmin = false,
                        isDean = false,
                        isDepChair = false,
                    },

                    new User
                    {
                        email = "denodo@mail.com",
                        password = PasswordHelper.HashPassword("den"),
                        firstName = "Dena",
                        lastName = "Odom",
                        CollegeId = 2,
                        DepartmentId = 4,
                        position = "Professor",
                        RSPGMember = true,
                        isRSPGChair = false,
                        isAdmin = false,
                        isDean = false,
                        isDepChair = false,
                    },

                    new User
                    {
                        email = "ronmat@mail.com",
                        password = PasswordHelper.HashPassword("ron"),
                        firstName = "Ronda",
                        lastName = "Mathews",
                        CollegeId = 2,
                        DepartmentId = 3,
                        position = "Professor",
                        RSPGMember = true,
                        isRSPGChair = false,
                        isAdmin = false,
                        isDean = false,
                        isDepChair = false,
                    },

                    new User
                    {
                        email = "aisrus@mail.com",
                        password = PasswordHelper.HashPassword("ais"),
                        firstName = "Aisha",
                        lastName = "Rush",
                        CollegeId = 1,
                        DepartmentId = 1,
                        position = "Professor",
                        RSPGMember = true,
                        isRSPGChair = false,
                        isAdmin = false,
                        isDean = false,
                        isDepChair = false,
                    },

                    new User
                    {
                        email = "moivan@mail.com",
                        password = PasswordHelper.HashPassword("moi"),
                        firstName = "Moises",
                        lastName = "Vang",
                        CollegeId = 1,
                        DepartmentId = 2,
                        position = "Professor",
                        RSPGMember = true,
                        isRSPGChair = false,
                        isAdmin = false,
                        isDean = false,
                        isDepChair = false,
                    }


                );

                context.SaveChanges();
            }
        }


        /// <summary>
        /// Add forms to the database
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddForms(IServiceProvider serviceProvider)
        {
            using (var context = new RSPGApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RSPGApplicationContext>>()))
            {
                if (context == null || context.RSPGForm == null)
                {
                    throw new ArgumentNullException("RSPGApplicationContext");
                }

                if (context.RSPGForm.Any())
                {
                    return;
                }

                context.RSPGForm.AddRange(

                    new RSPGFormModel
                    {
                        UserId = 1,
                        ProjectTitle = "Test Project 1",
                        ProjectDirector = "Wade Wilson",
                        CollegeId = 1,
                        DepartmentId = 1,
                        MailCode = "code 1234",
                        DepartmentChairName = "Mark Watney",
                        DeanName = "Arthur Dent",
                        ProgramDirectorName = "Jasmine Bashara",
                        OtherParticipants = "None",
                        UploadedFiles = [],
                        RequiresIRB = false,
                        IRBForm = null,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring", 
                        GrantType = "Research",
                        ChairApproved = true
                    },

                    new RSPGFormModel
                    {
                        UserId = 1,
                        ProjectTitle = "Test Project 2",
                        ProjectDirector = "Jean Grey",
                        CollegeId = 1,
                        DepartmentId = 2,
                        MailCode = "code 1234",
                        DepartmentChairName = "Jacques McKeown",
                        DeanName = "Peter Parker",
                        ProgramDirectorName = "Ryland Grace",
                        OtherParticipants = "None",
                        UploadedFiles = ["form1.txt", "form2.txt"],
                        RequiresIRB = true,
                        IRBForm = "requiredForm.txt",
                        IsSubmitted = false,
                        ApprovalStatus = true,
                        Semester = "Spring",
                        GrantType = "Research",
                        ChairApproved = true
                    },

                    new RSPGFormModel
                    {
                        UserId = 1,
                        ProjectTitle = "Test Project 3",
                        ProjectDirector = "Jean Grey",
                        CollegeId = 1,
                        DepartmentId = 2,
                        MailCode = "code 1234",
                        DepartmentChairName = "Jacques McKeown",
                        DeanName = "Peter Parker",
                        ProgramDirectorName = "Ryland Grace",
                        OtherParticipants = "None",
                        UploadedFiles = ["form1.txt", "form2.txt"],
                        RequiresIRB = true,
                        IRBForm = "requiredForm.txt",
                        IsSubmitted = false,
                        ApprovalStatus = false,
                        ChairApproved = false,
                        Semester = "Spring",
                        GrantType = "Research"
                    },

                    new RSPGFormModel
                    {
                        UserId = 4,
                        ProjectTitle = "Test Project Number: 0",
                        ProjectDirector = "James Sadler",
                        CollegeId = 2,
                        DepartmentId = 3,
                        MailCode = "12345",
                        DepartmentChairName = "Moises Vang",
                        DeanName = "Ernest Schwartz",
                        ProgramDirectorName = "Dena Odom",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research"
                    },

                    new RSPGFormModel
                    {
                        UserId = 8,
                        ProjectTitle = "Test Project Number: 1",
                        ProjectDirector = "Moises Gross",
                        CollegeId = 1,
                        DepartmentId = 2,
                        MailCode = "12345",
                        DepartmentChairName = "Aisha Kirk",
                        DeanName = "Moises Vang",
                        ProgramDirectorName = "Ronda Mathews",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = false,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research"
                    },

                    new RSPGFormModel
                    {
                        UserId = 8,
                        ProjectTitle = "Test Project Number: 2",
                        ProjectDirector = "Moises Gross",
                        CollegeId = 2,
                        DepartmentId = 3,
                        MailCode = "12345",
                        DepartmentChairName = "Dena Odom",
                        DeanName = "Dena Odom",
                        ProgramDirectorName = "Ernest Schwartz",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = false,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research"
                    },

                    new RSPGFormModel
                    {
                        UserId = 12,
                        ProjectTitle = "Test Project Number: 3",
                        ProjectDirector = "Dena Odom",
                        CollegeId = 2,
                        DepartmentId = 4,
                        MailCode = "12345",
                        DepartmentChairName = "James Sadler",
                        DeanName = "James Sadler",
                        ProgramDirectorName = "Moises Gross",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research",
                        ChairApproved = true
                    },

                    new RSPGFormModel
                    {
                        UserId = 2,
                        ProjectTitle = "Test Project Number: 4",
                        ProjectDirector = "Jean Grey",
                        CollegeId = 1,
                        DepartmentId = 1,
                        MailCode = "12345",
                        DepartmentChairName = "Garland Garner",
                        DeanName = "John Snow",
                        ProgramDirectorName = "Moises Gross",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        Semester = "Spring",
                        SubmissionDate = DateTime.Now,
                        GrantType = "Research",
                        ChairApproved = true
                    },

                    new RSPGFormModel
                    {
                        UserId = 11,
                        ProjectTitle = "Test Project Number: 5",
                        ProjectDirector = "Aisha Kirk",
                        CollegeId = 1,
                        DepartmentId = 1,
                        MailCode = "12345",
                        DepartmentChairName = "Garland Garner",
                        DeanName = "James Sadler",
                        ProgramDirectorName = "Moises Gross",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research",
                        ChairApproved = true
                    },

                    new RSPGFormModel
                    {
                        UserId = 13,
                        ProjectTitle = "Test Project Number: 6",
                        ProjectDirector = "Ronda Mathews",
                        CollegeId = 2,
                        DepartmentId = 3,
                        MailCode = "12345",
                        DepartmentChairName = "Carroll Schwartz",
                        DeanName = "Charles Xavier",
                        ProgramDirectorName = "Jean Grey",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research",
                        ChairApproved = true
                    },

                    new RSPGFormModel
                    {
                        UserId = 8,
                        ProjectTitle = "Test Project Number: 7",
                        ProjectDirector = "Moises Gross",
                        CollegeId = 2,
                        DepartmentId = 3,
                        MailCode = "12345",
                        DepartmentChairName = "Charles Xavier",
                        DeanName = "Aisha Kirk",
                        ProgramDirectorName = "Moises Vang",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research",
                        ChairApproved = true
                    },

                    new RSPGFormModel
                    {
                        UserId = 3,
                        ProjectTitle = "Test Project Number: 8",
                        ProjectDirector = "Charles Xavier",
                        CollegeId = 1,
                        DepartmentId = 1,
                        MailCode = "12345",
                        DepartmentChairName = "James Sadler",
                        DeanName = "Aisha Rush",
                        ProgramDirectorName = "Ernest Schwartz",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research",
                        ChairApproved = true
                    },

                    new RSPGFormModel
                    {
                        UserId = 1,
                        ProjectTitle = "Test Project Number: 9",
                        ProjectDirector = "Wade Wilson",
                        CollegeId = 2,
                        DepartmentId = 4,
                        MailCode = "12345",
                        DepartmentChairName = "Moises Gross",
                        DeanName = "Aisha Kirk",
                        ProgramDirectorName = "John Snow",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research",
                        ChairApproved = true
                    },

                    new RSPGFormModel
                    {
                        UserId = 3,
                        ProjectTitle = "Test Project Number: 10",
                        ProjectDirector = "Charles Xavier",
                        CollegeId = 2,
                        DepartmentId = 3,
                        MailCode = "12345",
                        DepartmentChairName = "Moises Vang",
                        DeanName = "Moises Vang",
                        ProgramDirectorName = "Dena Odom",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research",
                        ChairApproved = true
                    },

                    new RSPGFormModel
                    {
                        UserId = 15,
                        ProjectTitle = "Test Project Number: 11",
                        ProjectDirector = "Moises Vang",
                        CollegeId = 1,
                        DepartmentId = 1,
                        MailCode = "12345",
                        DepartmentChairName = "James Sadler",
                        DeanName = "Dena Odom",
                        ProgramDirectorName = "Dena Odom",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research",
                        ChairApproved = true
                    },

                    new RSPGFormModel
                    {
                        UserId = 3,
                        ProjectTitle = "Test Project Number: 12",
                        ProjectDirector = "Charles Xavier",
                        CollegeId = 2,
                        DepartmentId = 4,
                        MailCode = "12345",
                        DepartmentChairName = "John Snow",
                        DeanName = "Aisha Rush",
                        ProgramDirectorName = "Dena Odom",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research",
                        ChairApproved = true
                    },

                    new RSPGFormModel
                    {
                        UserId = 4,
                        ProjectTitle = "Test Project Number: 13",
                        ProjectDirector = "James Sadler",
                        CollegeId = 2,
                        DepartmentId = 4,
                        MailCode = "12345",
                        DepartmentChairName = "Charles Xavier",
                        DeanName = "Aisha Kirk",
                        ProgramDirectorName = "Moises Vang",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research",
                        ChairApproved = true
                    },

                    new RSPGFormModel
                    {
                        UserId = 2,
                        ProjectTitle = "Test Project Number: 14",
                        ProjectDirector = "Jean Grey",
                        CollegeId = 1,
                        DepartmentId = 1,
                        MailCode = "12345",
                        DepartmentChairName = "Ronda Mathews",
                        DeanName = "Charles Xavier",
                        ProgramDirectorName = "Charles Xavier",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research",
                        ChairApproved = true
                    },

                    new RSPGFormModel
                    {
                        UserId = 1,
                        ProjectTitle = "Needs approved by chair CS1",
                        ProjectDirector = "Jean Grey",
                        CollegeId = 1,
                        DepartmentId = 1,
                        MailCode = "12345",
                        DepartmentChairName = "Ronda Mathews",
                        DeanName = "Charles Xavier",
                        ProgramDirectorName = "Charles Xavier",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research"
                    },

                    new RSPGFormModel
                    {
                        UserId = 1,
                        ProjectTitle = "Needs approved by chair ID1",
                        ProjectDirector = "Jean Grey",
                        CollegeId = 1,
                        DepartmentId = 2,
                        MailCode = "12345",
                        DepartmentChairName = "Ronda Mathews",
                        DeanName = "Charles Xavier",
                        ProgramDirectorName = "Charles Xavier",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research"
                    },

                    new RSPGFormModel
                    {
                        UserId = 1,
                        ProjectTitle = "Needs approved by chair Zoo1",
                        ProjectDirector = "Jean Grey",
                        CollegeId = 2,
                        DepartmentId = 3,
                        MailCode = "12345",
                        DepartmentChairName = "Ronda Mathews",
                        DeanName = "Charles Xavier",
                        ProgramDirectorName = "Charles Xavier",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research"
                    },
                    new RSPGFormModel
                    {
                        UserId = 1,
                        ProjectTitle = "Needs approved by chair BTNY1",
                        ProjectDirector = "Jean Grey",
                        CollegeId = 2,
                        DepartmentId = 4,
                        MailCode = "12345",
                        DepartmentChairName = "Ronda Mathews",
                        DeanName = "Charles Xavier",
                        ProgramDirectorName = "Charles Xavier",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research"
                    },
                    new RSPGFormModel
                    {
                        UserId = 1,
                        ProjectTitle = "Needs approved by chair CS2",
                        ProjectDirector = "Jean Grey",
                        CollegeId = 1,
                        DepartmentId = 1,
                        MailCode = "12345",
                        DepartmentChairName = "Ronda Mathews",
                        DeanName = "Charles Xavier",
                        ProgramDirectorName = "Charles Xavier",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research"
                    },

                    new RSPGFormModel
                    {
                        UserId = 1,
                        ProjectTitle = "Needs approved by chair ID2",
                        ProjectDirector = "Jean Grey",
                        CollegeId = 1,
                        DepartmentId = 2,
                        MailCode = "12345",
                        DepartmentChairName = "Ronda Mathews",
                        DeanName = "Charles Xavier",
                        ProgramDirectorName = "Charles Xavier",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research"
                    },

                    new RSPGFormModel
                    {
                        UserId = 1,
                        ProjectTitle = "Needs approved by chair Zoo2",
                        ProjectDirector = "Jean Grey",
                        CollegeId = 2,
                        DepartmentId = 3,
                        MailCode = "12345",
                        DepartmentChairName = "Ronda Mathews",
                        DeanName = "Charles Xavier",
                        ProgramDirectorName = "Charles Xavier",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research"
                    },
                    new RSPGFormModel
                    {
                        UserId = 1,
                        ProjectTitle = "Needs approved by chair BTNY2",
                        ProjectDirector = "Jean Grey",
                        CollegeId = 2,
                        DepartmentId = 4,
                        MailCode = "12345",
                        DepartmentChairName = "Ronda Mathews",
                        DeanName = "Charles Xavier",
                        ProgramDirectorName = "Charles Xavier",
                        OtherParticipants = "None",
                        RequiresIRB = false,
                        IsSubmitted = true,
                        SubmissionDate = DateTime.Now,
                        Semester = "Spring",
                        GrantType = "Research"
                    }


                );
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Add criteria to the database
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddCriteria(IServiceProvider serviceProvider)
        {
            using (var context = new RSPGApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RSPGApplicationContext>>()))
            {
                if (context == null || context.Criteria == null)
                {
                    throw new ArgumentNullException("RSPGApplicationContext");
                }

                if (context.Criteria.Any())
                {
                    return;
                }

                context.Criteria.AddRange(

                    //Area One
                    new Criteria
                    {
                        CriteriaSection = "Area One",
                        CriteriaTitle = "Budget",
                        Weight = 3,
                        RatingTwo = "The project has demonstrated significant matching funds and/or" +
                                    " contributions in kind.",
                        RatingOne = "The project has some additional funding and/or contributions in " +
                                    "kind.",
                        RatingZero = "The project has no budgetary support."
                    },

                    new Criteria
                    {
                        CriteriaSection = "Area One",
                        CriteriaTitle = "Support",
                        Weight = 3,
                        RatingTwo = "The project has demonstrated significant support, in addition to " +
                                    "the department and college, through letters of collaboration with " +
                                    "other areas on campus or the community.",
                        RatingOne = "The project has demonstrated interest and commitment from the " +
                                    "department and college with additional letters/emails of support.",
                        RatingZero = "The project has the required general support from the department" +
                                    " and college."
                    },

                    //Area Two 
                    new Criteria
                    {
                        CriteriaSection = "Area Two",
                        CriteriaTitle = "University or Program Reputation",
                        Weight = 5,
                        RatingTwo = "Research / presentation will significantly improve the University or" +
                                    " Program reputation for example an international or national " +
                                    "conference, performance, exhibition of importance, or a peer-reviewed " +
                                    "publication in your field.",
                        RatingOne = "Research / presentation  will generally improve the University or " +
                                    "Program reputation for example a state or local conference, performance," +
                                    " exhibition of importance, or a non-peer reviewed publication in your " +
                                    "field.",
                        RatingZero = "Minimal to no impact on the University or Program reputation. "
                    },

                    new Criteria
                    {
                        CriteriaSection = "Area Two",
                        CriteriaTitle = "Innovative Teaching",
                        Weight = 5,
                        RatingTwo = "The project indicates innovative teaching strategies or the implementation" +
                                    " / creation of high impact educational experiences to a course, program or" +
                                    " curriculum not currently incorporating these innovations.",
                        RatingOne = "The project indicates updates to a course, program, curriculum, or " +
                                    "activities that will improve teaching or enhance student learning. ",
                        RatingZero = "The project does not adequately demonstrate instructional improvement or " +
                                    "innovative teaching."
                    },

                    new Criteria
                    {
                        CriteriaSection = "Area Two",
                        CriteriaTitle = "Community Educational Engagement",
                        Weight = 5,
                        RatingTwo = "The project provides real world learning opportunities for students with " +
                                    "well articulated learning outcomes and impacts individuals/organizations in " +
                                    "the community.",
                        RatingOne = "The project provides real world learning opportunities for students and " +
                                    "impacts individuals/organizations in the community.  Learning outcomes are " +
                                    "implied rather than clearly specified. ",
                        RatingZero = "The project has minimal to no student or community impact."
                    },

                    //Area Three
                    new Criteria
                    {
                        CriteriaSection = "Area Three",
                        CriteriaTitle = "Procedures & Methods",
                        Weight = 1,
                        RatingTwo = "The project indicates how the goals and objectives will be met including " +
                                    "steps involved in the design, development and implementation of the " +
                                    "project. The project seems feasible as outlined.",
                        RatingOne = "The project goals and objectives are at least partially indicated. Steps" +
                                    " involved in the design, development and implementation of the project " +
                                    "seem incomplete, unclear or not obtainable.",
                        RatingZero = "The project goals, objectives and steps involved in the design, " +
                                    "development and implementation are not addressed sufficiently."
                    },

                    new Criteria
                    {
                        CriteriaSection = "Area Three",
                        CriteriaTitle = "Timeline & Budgetary description",
                        Weight = 1,
                        RatingTwo = "Project timeline and budget is explained in detail, realistic, effective," +
                                    " and outcome oriented.",
                        RatingOne = "Project timeline or budgetary issues is addressed.",
                        RatingZero = "Timeline or budgetary issues not fully developed."
                    },

                    new Criteria
                    {
                        CriteriaSection = "Area Three",
                        CriteriaTitle = "Evaluation & Dissemination",
                        Weight = 3,
                        RatingTwo = "The project has the potential to be widely disseminated beyond the " +
                                    "University, for example at an international or national conference, " +
                                    "performance, exhibition of importance, or a peer-reviewed publication in " +
                                    "your field.",
                        RatingOne = "The project success will be documented and shared within the University " +
                                    "(e.g. Teaching and Learning Forum) or at a state or local conference, " +
                                    "performance, exhibition, or a  non-peer reviewed publication in your field.",
                        RatingZero = "The project will have minimal to no sharable or publishable results."
                    },

                    new Criteria
                    {
                        CriteriaSection = "Area Three",
                        CriteriaTitle = "Evidential Documentation",
                        Weight = 1,
                        RatingTwo = "The project has the required documentation, documentation of project " +
                                    "viability and dissemination, letters of support, and other items to " +
                                    "assist the committee in determining the importance of the project.",
                        RatingOne = "The project has the required documentation, and in addition has provided " +
                                    "additional information to assist the committee in determining project viability.",
                        RatingZero = "The project has the required documentation such as conference acceptance " +
                                    "and proof of project costs."
                    }

                );
                context.SaveChanges();
            }

        }

        /// <summary>
        /// Add forms to the database
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddBudgetForms(IServiceProvider serviceProvider)
        {
            using (var context = new RSPGApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RSPGApplicationContext>>()))
            {
                if (context == null || context.BudgetForm == null)
                {
                    throw new ArgumentNullException("RSPGApplicationContext");
                }

                if (context.BudgetForm.Any())
                {
                    return;
                }

                context.BudgetForm.AddRange(

                    new BudgetForm
                    {
                        RSPGFormID = 1
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 2
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 3
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 4
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 5
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 6
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 7
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 8
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 9
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 10
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 11
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 12
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 13
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 14
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 15
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 16
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 17
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 18
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 19
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 20
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 21
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 22
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 23
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 24
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 25
                    },
                    new BudgetForm
                    {
                        RSPGFormID = 26
                    }

                );
                context.SaveChanges();
            }
        }


        /// <summary>
        /// Add forms to the database
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddPersonalResources(IServiceProvider serviceProvider)
        {
            using (var context = new RSPGApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RSPGApplicationContext>>()))
            {
                if (context == null || context.PersonalResources == null)
                {
                    throw new ArgumentNullException("RSPGApplicationContext");
                }

                if (context.PersonalResources.Any())
                {
                    return;
                }

                context.PersonalResources.AddRange(

                    new PersonalResources
                    {
                        BudgetFormId = 1,
                        IsStudent = true,
                        Name = "James",
                        FundsFrom1 = "Computer Science Dept.",
                        Total1 = 2500,
                        RSPGTotal = 2500
                    },
                    new PersonalResources
                    {
                        BudgetFormId = 1,
                        IsStudent = false,
                        Name = "Jane",
                        FundsFrom1 = "Computer Science Dept.",
                        Total1 = 2500,
                        RSPGTotal = 2500
                    },
                    new PersonalResources
                    {
                        BudgetFormId = 2,
                        IsStudent = true,
                        Name = "Alice",
                        FundsFrom1 = "College of E.A.S.T",
                        Total1 = 2500,
                        FundsFrom2 = "Computer Science Dept.",
                        Total2 = 1000,
                        RSPGTotal = 2500
                    },
                    new PersonalResources
                    {
                        BudgetFormId = 2,
                        IsStudent = false,
                        Name = "Fred",
                        FundsFrom1 = "College of E.A.S.T",
                        Total1 = 2500,
                        FundsFrom2 = "Computer Science Dept.",
                        Total2 = 1000,
                        RSPGTotal = 2500
                    },
                    new PersonalResources
                    {
                        BudgetFormId = 3,
                        IsStudent = true,
                        Name = "Gwen",
                        FundsFrom1 = "College of E.A.S.T",
                        Total1 = 2500,
                        FundsFrom2 = "Computer Science Dept.",
                        Total2 = 1000,
                        FundsFrom3 = "Weber State University",
                        Total3 = 2000,
                        RSPGTotal = 2500
                    },
                    new PersonalResources
                    {
                        BudgetFormId = 3,
                        IsStudent = false,
                        Name = "Alex",
                        FundsFrom1 = "College of E.A.S.T",
                        Total1 = 2500,
                        FundsFrom2 = "Computer Science Dept.",
                        Total2 = 1000,
                        FundsFrom3 = "Weber State University",
                        Total3 = 2000,
                        RSPGTotal = 2500
                    },
                    new PersonalResources
                    {
                        BudgetFormId = 4,
                        IsStudent = true,
                        Name = "Student",
                        FundsFrom1 = "College",
                        Total1 = 533,
                        RSPGTotal = 1710,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 4,
                        IsStudent = false,
                        Name = "Self",
                        FundsFrom1 = "College",
                        Total1 = 738,
                        RSPGTotal = 1145,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 5,
                        IsStudent = true,
                        Name = "Student",
                        FundsFrom1 = "College",
                        Total1 = 697,
                        RSPGTotal = 1627,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 5,
                        IsStudent = false,
                        Name = "Self",
                        FundsFrom1 = "College",
                        Total1 = 799,
                        RSPGTotal = 1290,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 6,
                        IsStudent = true,
                        Name = "Student",
                        FundsFrom1 = "College",
                        Total1 = 876,
                        RSPGTotal = 1880,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 6,
                        IsStudent = false,
                        Name = "Self",
                        FundsFrom1 = "College",
                        Total1 = 996,
                        RSPGTotal = 1834,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 7,
                        IsStudent = true,
                        Name = "Student",
                        FundsFrom1 = "College",
                        Total1 = 985,
                        RSPGTotal = 1481,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 7,
                        IsStudent = false,
                        Name = "Self",
                        FundsFrom1 = "College",
                        Total1 = 817,
                        RSPGTotal = 1010,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 8,
                        IsStudent = true,
                        Name = "Student",
                        FundsFrom1 = "College",
                        Total1 = 771,
                        RSPGTotal = 1312,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 8,
                        IsStudent = false,
                        Name = "Self",
                        FundsFrom1 = "College",
                        Total1 = 812,
                        RSPGTotal = 1261,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 9,
                        IsStudent = true,
                        Name = "Student",
                        FundsFrom1 = "College",
                        Total1 = 840,
                        RSPGTotal = 1751,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 9,
                        IsStudent = false,
                        Name = "Self",
                        FundsFrom1 = "College",
                        Total1 = 854,
                        RSPGTotal = 1128,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 10,
                        IsStudent = true,
                        Name = "Student",
                        FundsFrom1 = "College",
                        Total1 = 776,
                        RSPGTotal = 1396,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 10,
                        IsStudent = false,
                        Name = "Self",
                        FundsFrom1 = "College",
                        Total1 = 929,
                        RSPGTotal = 1278,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 11,
                        IsStudent = true,
                        Name = "Student",
                        FundsFrom1 = "College",
                        Total1 = 721,
                        RSPGTotal = 1899,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 11,
                        IsStudent = false,
                        Name = "Self",
                        FundsFrom1 = "College",
                        Total1 = 521,
                        RSPGTotal = 1504,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 12,
                        IsStudent = true,
                        Name = "Student",
                        FundsFrom1 = "College",
                        Total1 = 766,
                        RSPGTotal = 1621,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 12,
                        IsStudent = false,
                        Name = "Self",
                        FundsFrom1 = "College",
                        Total1 = 694,
                        RSPGTotal = 1266,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 13,
                        IsStudent = true,
                        Name = "Student",
                        FundsFrom1 = "College",
                        Total1 = 871,
                        RSPGTotal = 1529,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 13,
                        IsStudent = false,
                        Name = "Self",
                        FundsFrom1 = "College",
                        Total1 = 791,
                        RSPGTotal = 1914,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 14,
                        IsStudent = true,
                        Name = "Student",
                        FundsFrom1 = "College",
                        Total1 = 787,
                        RSPGTotal = 1460,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 14,
                        IsStudent = false,
                        Name = "Self",
                        FundsFrom1 = "College",
                        Total1 = 920,
                        RSPGTotal = 1746,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 15,
                        IsStudent = true,
                        Name = "Student",
                        FundsFrom1 = "College",
                        Total1 = 632,
                        RSPGTotal = 1255,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 15,
                        IsStudent = false,
                        Name = "Self",
                        FundsFrom1 = "College",
                        Total1 = 908,
                        RSPGTotal = 1492,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 16,
                        IsStudent = true,
                        Name = "Student",
                        FundsFrom1 = "College",
                        Total1 = 982,
                        RSPGTotal = 1593,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 16,
                        IsStudent = false,
                        Name = "Self",
                        FundsFrom1 = "College",
                        Total1 = 893,
                        RSPGTotal = 1403,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 17,
                        IsStudent = true,
                        Name = "Student",
                        FundsFrom1 = "College",
                        Total1 = 602,
                        RSPGTotal = 1594,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 17,
                        IsStudent = false,
                        Name = "Self",
                        FundsFrom1 = "College",
                        Total1 = 773,
                        RSPGTotal = 1571,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 18,
                        IsStudent = true,
                        Name = "Student",
                        FundsFrom1 = "College",
                        Total1 = 725,
                        RSPGTotal = 1721,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 18,
                        IsStudent = false,
                        Name = "Self",
                        FundsFrom1 = "College",
                        Total1 = 548,
                        RSPGTotal = 1083,
                    },



                    new PersonalResources
                    {
                        BudgetFormId = 19,
                        IsStudent = true,
                        Name = "Student",
                        RSPGTotal = 1721,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 19,
                        IsStudent = false,
                        Name = "Self",
                        RSPGTotal = 1083,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 20,
                        IsStudent = true,
                        Name = "Student",
                        RSPGTotal = 1721,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 20,
                        IsStudent = false,
                        Name = "Self",
                        RSPGTotal = 1083,
                    },
                    new PersonalResources
                    {
                        BudgetFormId = 21,
                        IsStudent = true,
                        Name = "Student",
                        RSPGTotal = 1721,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 21,
                        IsStudent = false,
                        Name = "Self",
                        RSPGTotal = 1083,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 22,
                        IsStudent = true,
                        Name = "Student",
                        RSPGTotal = 1721,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 22,
                        IsStudent = false,
                        Name = "Self",
                        RSPGTotal = 1083,
                    },
                    new PersonalResources
                    {
                        BudgetFormId = 23,
                        IsStudent = true,
                        Name = "Student",
                        RSPGTotal = 1721,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 23,
                        IsStudent = false,
                        Name = "Self",
                        RSPGTotal = 1083,
                    },
                    new PersonalResources
                    {
                        BudgetFormId = 24,
                        IsStudent = true,
                        Name = "Student",
                        RSPGTotal = 1721,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 24,
                        IsStudent = false,
                        Name = "Self",
                        RSPGTotal = 1083,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 25,
                        IsStudent = true,
                        Name = "Student",
                        RSPGTotal = 1721,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 25,
                        IsStudent = false,
                        Name = "Self",
                        RSPGTotal = 1083,
                    },
                    new PersonalResources
                    {
                        BudgetFormId = 26,
                        IsStudent = true,
                        Name = "Student",
                        RSPGTotal = 1721,
                    },

                    new PersonalResources
                    {
                        BudgetFormId = 26,
                        IsStudent = false,
                        Name = "Self",
                        RSPGTotal = 1083,
                    }
                );
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Add forms to the database
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddEquipmentResources(IServiceProvider serviceProvider)
        {
            using (var context = new RSPGApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RSPGApplicationContext>>()))
            {
                if (context == null || context.EquipmentResource == null)
                {
                    throw new ArgumentNullException("RSPGApplicationContext");
                }

                if (context.EquipmentResource.Any())
                {
                    return;
                }

                context.EquipmentResource.AddRange(

                    new EquipmentResource
                    {
                        BudgetFormId = 1,
                        Name = "Computer Parts",
                        FundsFrom1 = "Computer Science Dept.",
                        Total1 = 1000,
                        RSPGTotal = 1000
                    },
                    new EquipmentResource
                    {
                        BudgetFormId = 2,
                        Name = "3D Printer",
                        FundsFrom1 = "College of E.A.S.T",
                        Total1 = 2500,
                        FundsFrom2 = "Computer Science Dept.",
                        Total2 = 1000,
                        RSPGTotal = 2500
                    },
                    new EquipmentResource
                    {
                        BudgetFormId = 2,
                        Name = "Office Supplies",
                        FundsFrom1 = "College of E.A.S.T",
                        Total1 = 1000,
                        FundsFrom2 = "Computer Science Dept.",
                        Total2 = 1000,
                        RSPGTotal = 2500
                    },
                    new EquipmentResource
                    {
                        BudgetFormId = 3,
                        Name = "Laser Cutter",
                        FundsFrom1 = "College of E.A.S.T",
                        Total1 = 2500,
                        FundsFrom2 = "Computer Science Dept.",
                        Total2 = 1000,
                        FundsFrom3 = "Weber State University",
                        Total3 = 2000,
                        RSPGTotal = 2500
                    },

                    new EquipmentResource
                    {
                        BudgetFormId = 3,
                        Name = "Office Supplies",
                        FundsFrom1 = "College",
                        Total1 = 650,
                        RSPGTotal = 1318,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 3,
                    Name = "Computer Parts",
                    FundsFrom1 = "College",
                    Total1 = 646,
                    RSPGTotal = 1828,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 4,
                    Name = "Office Supplies",
                    FundsFrom1 = "College",
                    Total1 = 801,
                    FundsFrom2 = "Private Donors",
                    Total2 = 911,
                    RSPGTotal = 1208,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 4,
                    Name = "Computer Parts",
                    FundsFrom1 = "College",
                    Total1 = 559,
                    FundsFrom2 = "Private Donors",
                    Total2 = 514,
                    RSPGTotal = 1147,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 5,
                    Name = "Office Supplies",
                    FundsFrom1 = "College",
                    Total1 = 812,
                    RSPGTotal = 1116,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 5,
                    Name = "Computer Parts",
                    FundsFrom1 = "College",
                    Total1 = 559,
                    RSPGTotal = 1908,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 6,
                    Name = "Office Supplies",
                    FundsFrom1 = "College",
                    Total1 = 947,
                    RSPGTotal = 1735,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 6,
                    Name = "Computer Parts",
                    FundsFrom1 = "College",
                    Total1 = 555,
                    RSPGTotal = 1624,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 7,
                    Name = "Office Supplies",
                    FundsFrom1 = "College",
                    Total1 = 583,
                    FundsFrom2 = "Private Donors",
                    Total2 = 734,
                    RSPGTotal = 1405,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 7,
                    Name = "Computer Parts",
                    FundsFrom1 = "College",
                    Total1 = 765,
                    FundsFrom2 = "Private Donors",
                    Total2 = 775,
                    RSPGTotal = 1378,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 8,
                    Name = "Office Supplies",
                    FundsFrom1 = "College",
                    Total1 = 671,
                    RSPGTotal = 1085,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 8,
                    Name = "Computer Parts",
                    FundsFrom1 = "College",
                    Total1 = 730,
                    RSPGTotal = 1031,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 9,
                    Name = "Office Supplies",
                    FundsFrom1 = "College",
                    Total1 = 750,
                    FundsFrom2 = "Private Donors",
                    Total2 = 995,
                    RSPGTotal = 1657,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 9,
                    Name = "Computer Parts",
                    FundsFrom1 = "College",
                    Total1 = 994,
                    FundsFrom2 = "Private Donors",
                    Total2 = 774,
                    RSPGTotal = 1443,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 10,
                    Name = "Office Supplies",
                    FundsFrom1 = "College",
                    Total1 = 798,
                    FundsFrom2 = "Private Donors",
                    Total2 = 946,
                    FundsFrom3 = "Fundraising",
                    Total3 = 853,
                    RSPGTotal = 1966,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 10,
                    Name = "Computer Parts",
                    FundsFrom1 = "College",
                    Total1 = 689,
                    FundsFrom2 = "Private Donors",
                    Total2 = 533,
                    FundsFrom3 = "Fundraising",
                    Total3 = 625,
                    RSPGTotal = 1051,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 11,
                    Name = "Office Supplies",
                    FundsFrom1 = "College",
                    Total1 = 858,
                    FundsFrom2 = "Private Donors",
                    Total2 = 935,
                    FundsFrom3 = "Fundraising",
                    Total3 = 795,
                    RSPGTotal = 1739,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 11,
                    Name = "Computer Parts",
                    FundsFrom1 = "College",
                    Total1 = 776,
                    FundsFrom2 = "Private Donors",
                    Total2 = 771,
                    FundsFrom3 = "Fundraising",
                    Total3 = 830,
                    RSPGTotal = 1794,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 12,
                    Name = "Office Supplies",
                    FundsFrom1 = "College",
                    Total1 = 775,
                    FundsFrom2 = "Private Donors",
                    Total2 = 738,
                    RSPGTotal = 1492,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 12,
                    Name = "Computer Parts",
                    FundsFrom1 = "College",
                    Total1 = 654,
                    FundsFrom2 = "Private Donors",
                    Total2 = 991,
                    RSPGTotal = 1598,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 13,
                    Name = "Office Supplies",
                    FundsFrom1 = "College",
                    Total1 = 702,
                    FundsFrom2 = "Private Donors",
                    Total2 = 650,
                    RSPGTotal = 1858,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 13,
                    Name = "Computer Parts",
                    FundsFrom1 = "College",
                    Total1 = 657,
                    FundsFrom2 = "Private Donors",
                    Total2 = 927,
                    RSPGTotal = 1853,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 14,
                    Name = "Office Supplies",
                    FundsFrom1 = "College",
                    Total1 = 826,
                    RSPGTotal = 1333,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 14,
                    Name = "Computer Parts",
                    FundsFrom1 = "College",
                    Total1 = 625,
                    RSPGTotal = 1697,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 15,
                    Name = "Office Supplies",
                    FundsFrom1 = "College",
                    Total1 = 738,
                    FundsFrom2 = "Private Donors",
                    Total2 = 838,
                    FundsFrom3 = "Fundraising",
                    Total3 = 748,
                    RSPGTotal = 1809,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 15,
                    Name = "Computer Parts",
                    FundsFrom1 = "College",
                    Total1 = 815,
                    FundsFrom2 = "Private Donors",
                    Total2 = 704,
                    FundsFrom3 = "Fundraising",
                    Total3 = 892,
                    RSPGTotal = 1784,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 16,
                    Name = "Office Supplies",
                    FundsFrom1 = "College",
                    Total1 = 555,
                    FundsFrom2 = "Private Donors",
                    Total2 = 923,
                    RSPGTotal = 1702,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 16,
                    Name = "Computer Parts",
                    FundsFrom1 = "College",
                    Total1 = 714,
                    FundsFrom2 = "Private Donors",
                    Total2 = 905,
                    RSPGTotal = 1667,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 17,
                    Name = "Office Supplies",
                    FundsFrom1 = "College",
                    Total1 = 627,
                    RSPGTotal = 1133,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 17,
                    Name = "Computer Parts",
                    FundsFrom1 = "College",
                    Total1 = 689,
                    RSPGTotal = 1723,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 18,
                    Name = "Office Supplies",
                    FundsFrom1 = "College",
                    Total1 = 620,
                    FundsFrom2 = "Private Donors",
                    Total2 = 583,
                    RSPGTotal = 1339,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 18,
                    Name = "Computer Parts",
                    FundsFrom1 = "College",
                    Total1 = 529,
                    FundsFrom2 = "Private Donors",
                    Total2 = 753,
                    RSPGTotal = 1275,
                    },

                    new EquipmentResource
                    {
                    BudgetFormId = 19,
                    Name = "Computer Parts",
                    RSPGTotal = 1275,
                    },
                    new EquipmentResource
                    {
                    BudgetFormId = 20,
                    Name = "Computer Parts",
                    RSPGTotal = 1275,
                    },
                    new EquipmentResource
                    {
                    BudgetFormId = 21,
                    Name = "Computer Parts",
                    RSPGTotal = 1275,
                    },
                    new EquipmentResource
                    {
                    BudgetFormId = 22,
                    Name = "Computer Parts",
                    RSPGTotal = 1275,
                    },
                    new EquipmentResource
                    {
                    BudgetFormId = 23,
                    Name = "Computer Parts",
                    RSPGTotal = 1275,
                    },
                    new EquipmentResource
                    {
                    BudgetFormId = 24,
                    Name = "Computer Parts",
                    RSPGTotal = 1275,
                    },
                    new EquipmentResource
                    {
                    BudgetFormId = 25,
                    Name = "Computer Parts",
                    RSPGTotal = 1275,
                    },
                    new EquipmentResource
                    {
                    BudgetFormId = 26,
                    Name = "Computer Parts",
                    RSPGTotal = 1275,
                    }

                );
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Add forms to the database
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddTravelResources(IServiceProvider serviceProvider)
        {
            using (var context = new RSPGApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RSPGApplicationContext>>()))
            {
                if (context == null || context.TravelResource == null)
                {
                    throw new ArgumentNullException("RSPGApplicationContext");
                }

                if (context.TravelResource.Any())
                {
                    return;
                }

                context.TravelResource.AddRange(

                    new TravelResource
                    {
                        BudgetFormId = 1,
                        Name = "Rental Car",
                        FundsFrom1 = "Computer Science Dept.",
                        Total1 = 500,
                        RSPGTotal = 500
                    },
                    new TravelResource
                    {
                        BudgetFormId = 2,
                        Name = "Flights",
                        FundsFrom1 = "College of E.A.S.T",
                        Total1 = 1500,
                        FundsFrom2 = "Computer Science Dept.",
                        Total2 = 1500,
                        RSPGTotal = 1000
                    },
                    new TravelResource
                    {
                        BudgetFormId = 2,
                        Name = "Rental Cars",
                        FundsFrom1 = "College of E.A.S.T",
                        Total1 = 1000,
                        FundsFrom2 = "Computer Science Dept.",
                        Total2 = 1000,
                        RSPGTotal = 2500
                    },
                    new TravelResource
                    {
                        BudgetFormId = 3,
                        Name = "Gas",
                        FundsFrom1 = "College of E.A.S.T",
                        Total1 = 500,
                        FundsFrom2 = "Computer Science Dept.",
                        Total2 = 500,
                        FundsFrom3 = "Weber State University",
                        Total3 = 500,
                        RSPGTotal = 500
                    },
                    new TravelResource
                    {
                        BudgetFormId = 4,
                        Name = "Gas",
                        FundsFrom1 = "College",
                        Total1 = 830,
                        RSPGTotal = 1978,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 4,
                        Name = "Rental Car",
                        FundsFrom1 = "College",
                        Total1 = 892,
                        RSPGTotal = 1347,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 5,
                        Name = "Gas",
                        FundsFrom1 = "College",
                        Total1 = 820,
                        RSPGTotal = 1491,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 5,
                        Name = "Rental Car",
                        FundsFrom1 = "College",
                        Total1 = 865,
                        RSPGTotal = 1988,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 6,
                        Name = "Gas",
                        FundsFrom1 = "College",
                        Total1 = 920,
                        RSPGTotal = 1616,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 6,
                        Name = "Rental Car",
                        FundsFrom1 = "College",
                        Total1 = 851,
                        RSPGTotal = 1535,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 7,
                        Name = "Gas",
                        FundsFrom1 = "College",
                        Total1 = 914,
                        FundsFrom2 = "Private Donors",
                        Total2 = 682,
                        FundsFrom3 = "Fundraising",
                        Total3 = 629,
                        RSPGTotal = 1240,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 7,
                        Name = "Rental Car",
                        FundsFrom1 = "College",
                        Total1 = 972,
                        FundsFrom2 = "Private Donors",
                        Total2 = 909,
                        FundsFrom3 = "Fundraising",
                        Total3 = 643,
                        RSPGTotal = 1401,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 8,
                        Name = "Gas",
                        FundsFrom1 = "College",
                        Total1 = 815,
                        FundsFrom2 = "Private Donors",
                        Total2 = 584,
                        FundsFrom3 = "Fundraising",
                        Total3 = 919,
                        RSPGTotal = 1038,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 8,
                        Name = "Rental Car",
                        FundsFrom1 = "College",
                        Total1 = 660,
                        FundsFrom2 = "Private Donors",
                        Total2 = 587,
                        FundsFrom3 = "Fundraising",
                        Total3 = 894,
                        RSPGTotal = 1999,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 9,
                        Name = "Gas",
                        FundsFrom1 = "College",
                        Total1 = 591,
                        RSPGTotal = 1597,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 9,
                        Name = "Rental Car",
                        FundsFrom1 = "College",
                        Total1 = 626,
                        RSPGTotal = 1855,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 10,
                        Name = "Gas",
                        FundsFrom1 = "College",
                        Total1 = 547,
                        RSPGTotal = 1976,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 10,
                        Name = "Rental Car",
                        FundsFrom1 = "College",
                        Total1 = 515,
                        RSPGTotal = 1616,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 11,
                        Name = "Gas",
                        FundsFrom1 = "College",
                        Total1 = 689,
                        RSPGTotal = 1306,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 11,
                        Name = "Rental Car",
                        FundsFrom1 = "College",
                        Total1 = 739,
                        RSPGTotal = 1825,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 12,
                        Name = "Gas",
                        FundsFrom1 = "College",
                        Total1 = 619,
                        RSPGTotal = 1914,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 12,
                        Name = "Rental Car",
                        FundsFrom1 = "College",
                        Total1 = 707,
                        RSPGTotal = 1721,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 13,
                        Name = "Gas",
                        FundsFrom1 = "College",
                        Total1 = 874,
                        FundsFrom2 = "Private Donors",
                        Total2 = 958,
                        FundsFrom3 = "Fundraising",
                        Total3 = 802,
                        RSPGTotal = 1637,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 13,
                        Name = "Rental Car",
                        FundsFrom1 = "College",
                        Total1 = 757,
                        FundsFrom2 = "Private Donors",
                        Total2 = 576,
                        FundsFrom3 = "Fundraising",
                        Total3 = 942,
                        RSPGTotal = 1945,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 14,
                        Name = "Gas",
                        FundsFrom1 = "College",
                        Total1 = 547,
                        FundsFrom2 = "Private Donors",
                        Total2 = 773,
                        FundsFrom3 = "Fundraising",
                        Total3 = 913,
                        RSPGTotal = 1298,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 14,
                        Name = "Rental Car",
                        FundsFrom1 = "College",
                        Total1 = 870,
                        FundsFrom2 = "Private Donors",
                        Total2 = 660,
                        FundsFrom3 = "Fundraising",
                        Total3 = 892,
                        RSPGTotal = 1581,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 15,
                        Name = "Gas",
                        FundsFrom1 = "College",
                        Total1 = 815,
                        RSPGTotal = 1523,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 15,
                        Name = "Rental Car",
                        FundsFrom1 = "College",
                        Total1 = 634,
                        RSPGTotal = 1132,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 16,
                        Name = "Gas",
                        FundsFrom1 = "College",
                        Total1 = 526,
                        FundsFrom2 = "Private Donors",
                        Total2 = 812,
                        FundsFrom3 = "Fundraising",
                        Total3 = 812,
                        RSPGTotal = 1567,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 16,
                        Name = "Rental Car",
                        FundsFrom1 = "College",
                        Total1 = 588,
                        FundsFrom2 = "Private Donors",
                        Total2 = 996,
                        FundsFrom3 = "Fundraising",
                        Total3 = 535,
                        RSPGTotal = 1766,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 17,
                        Name = "Gas",
                        FundsFrom1 = "College",
                        Total1 = 900,
                        RSPGTotal = 1530,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 17,
                        Name = "Rental Car",
                        FundsFrom1 = "College",
                        Total1 = 655,
                        RSPGTotal = 1402,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 18,
                        Name = "Gas",
                        FundsFrom1 = "College",
                        Total1 = 535,
                        RSPGTotal = 1412,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 18,
                        Name = "Rental Car",
                        FundsFrom1 = "College",
                        Total1 = 999,
                        RSPGTotal = 1448,
                    },

                    new TravelResource
                    {
                        BudgetFormId = 19,
                        Name = "Computer Parts",
                        RSPGTotal = 1275,
                    },
                    new TravelResource
                    {
                        BudgetFormId = 20,
                        Name = "Computer Parts",
                        RSPGTotal = 1275,
                    },
                    new TravelResource
                    {
                        BudgetFormId = 21,
                        Name = "Computer Parts",
                        RSPGTotal = 1275,
                    },
                    new TravelResource
                    {
                        BudgetFormId = 22,
                        Name = "Computer Parts",
                        RSPGTotal = 1275,
                    },
                    new TravelResource
                    {
                        BudgetFormId = 23,
                        Name = "Computer Parts",
                        RSPGTotal = 1275,
                    },
                    new TravelResource
                    {
                        BudgetFormId = 24,
                        Name = "Computer Parts",
                        RSPGTotal = 1275,
                    },
                    new TravelResource
                    {
                        BudgetFormId = 25,
                        Name = "Computer Parts",
                        RSPGTotal = 1275,
                    },
                    new TravelResource
                    {
                        BudgetFormId = 26,
                        Name = "Computer Parts",
                        RSPGTotal = 1275,
                    }

                );
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Add forms to the database
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddOtherResources(IServiceProvider serviceProvider)
        {
            using (var context = new RSPGApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RSPGApplicationContext>>()))
            {
                if (context == null || context.OtherResource == null)
                {
                    throw new ArgumentNullException("RSPGApplicationContext");
                }

                if (context.OtherResource.Any())
                {
                    return;
                }

                context.OtherResource.AddRange(

                    new OtherResource
                    {
                        BudgetFormId = 1,
                        Name = "Food",
                        FundsFrom1 = "Computer Science Dept.",
                        Total1 = 250,
                        RSPGTotal = 250
                    },
                    new OtherResource
                    {
                        BudgetFormId = 2,
                        Name = "Food",
                        FundsFrom1 = "College of E.A.S.T",
                        Total1 = 150,
                        FundsFrom2 = "Computer Science Dept.",
                        Total2 = 150,
                        RSPGTotal = 100
                    },
                    new OtherResource
                    {
                        BudgetFormId = 2,
                        Name = "Public Awareness",
                        FundsFrom1 = "College of E.A.S.T",
                        Total1 = 1000,
                        FundsFrom2 = "Computer Science Dept.",
                        Total2 = 1000,
                        RSPGTotal = 2500
                    },
                    new OtherResource
                    {
                        BudgetFormId = 3,
                        Name = "Food",
                        FundsFrom1 = "College of E.A.S.T",
                        Total1 = 500,
                        FundsFrom2 = "Computer Science Dept.",
                        Total2 = 500,
                        FundsFrom3 = "Weber State University",
                        Total3 = 500,
                        RSPGTotal = 500
                    },
                    new OtherResource
                    {
                        BudgetFormId = 4,
                        Name = "Food",
                        FundsFrom1 = "College",
                        Total1 = 724,
                        FundsFrom2 = "Private Donors",
                        Total2 = 518,
                        FundsFrom3 = "Fundraising",
                        Total3 = 565,
                        RSPGTotal = 1911,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 4,
                        Name = "Public Awareness",
                        FundsFrom1 = "College",
                        Total1 = 903,
                        FundsFrom2 = "Private Donors",
                        Total2 = 782,
                        FundsFrom3 = "Fundraising",
                        Total3 = 593,
                        RSPGTotal = 1344,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 5,
                        Name = "Food",
                        FundsFrom1 = "College",
                        Total1 = 854,
                        FundsFrom2 = "Private Donors",
                        Total2 = 506,
                        FundsFrom3 = "Fundraising",
                        Total3 = 944,
                        RSPGTotal = 1694,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 5,
                        Name = "Public Awareness",
                        FundsFrom1 = "College",
                        Total1 = 858,
                        FundsFrom2 = "Private Donors",
                        Total2 = 577,
                        FundsFrom3 = "Fundraising",
                        Total3 = 990,
                        RSPGTotal = 1470,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 6,
                        Name = "Food",
                        FundsFrom1 = "College",
                        Total1 = 985,
                        FundsFrom2 = "Private Donors",
                        Total2 = 937,
                        RSPGTotal = 1378,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 6,
                        Name = "Public Awareness",
                        FundsFrom1 = "College",
                        Total1 = 618,
                        FundsFrom2 = "Private Donors",
                        Total2 = 932,
                        RSPGTotal = 1754,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 7,
                        Name = "Food",
                        FundsFrom1 = "College",
                        Total1 = 837,
                        FundsFrom2 = "Private Donors",
                        Total2 = 990,
                        FundsFrom3 = "Fundraising",
                        Total3 = 907,
                        RSPGTotal = 1881,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 7,
                        Name = "Public Awareness",
                        FundsFrom1 = "College",
                        Total1 = 842,
                        FundsFrom2 = "Private Donors",
                        Total2 = 527,
                        FundsFrom3 = "Fundraising",
                        Total3 = 627,
                        RSPGTotal = 1446,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 8,
                        Name = "Food",
                        FundsFrom1 = "College",
                        Total1 = 507,
                        FundsFrom2 = "Private Donors",
                        Total2 = 947,
                        FundsFrom3 = "Fundraising",
                        Total3 = 762,
                        RSPGTotal = 1510,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 8,
                        Name = "Public Awareness",
                        FundsFrom1 = "College",
                        Total1 = 675,
                        FundsFrom2 = "Private Donors",
                        Total2 = 997,
                        FundsFrom3 = "Fundraising",
                        Total3 = 902,
                        RSPGTotal = 1042,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 9,
                        Name = "Food",
                        FundsFrom1 = "College",
                        Total1 = 532,
                        FundsFrom2 = "Private Donors",
                        Total2 = 994,
                        FundsFrom3 = "Fundraising",
                        Total3 = 596,
                        RSPGTotal = 1922,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 9,
                        Name = "Public Awareness",
                        FundsFrom1 = "College",
                        Total1 = 696,
                        FundsFrom2 = "Private Donors",
                        Total2 = 970,
                        FundsFrom3 = "Fundraising",
                        Total3 = 565,
                        RSPGTotal = 1381,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 10,
                        Name = "Food",
                        FundsFrom1 = "College",
                        Total1 = 673,
                        RSPGTotal = 1203,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 10,
                        Name = "Public Awareness",
                        FundsFrom1 = "College",
                        Total1 = 691,
                        RSPGTotal = 1121,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 11,
                        Name = "Food",
                        FundsFrom1 = "College",
                        Total1 = 626,
                        FundsFrom2 = "Private Donors",
                        Total2 = 735,
                        RSPGTotal = 1765,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 11,
                        Name = "Public Awareness",
                        FundsFrom1 = "College",
                        Total1 = 679,
                        FundsFrom2 = "Private Donors",
                        Total2 = 821,
                        RSPGTotal = 1101,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 12,
                        Name = "Food",
                        FundsFrom1 = "College",
                        Total1 = 864,
                        FundsFrom2 = "Private Donors",
                        Total2 = 837,
                        FundsFrom3 = "Fundraising",
                        Total3 = 737,
                        RSPGTotal = 1124,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 12,
                        Name = "Public Awareness",
                        FundsFrom1 = "College",
                        Total1 = 894,
                        FundsFrom2 = "Private Donors",
                        Total2 = 742,
                        FundsFrom3 = "Fundraising",
                        Total3 = 638,
                        RSPGTotal = 1896,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 13,
                        Name = "Food",
                        FundsFrom1 = "College",
                        Total1 = 617,
                        FundsFrom2 = "Private Donors",
                        Total2 = 551,
                        RSPGTotal = 1306,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 13,
                        Name = "Public Awareness",
                        FundsFrom1 = "College",
                        Total1 = 652,
                        FundsFrom2 = "Private Donors",
                        Total2 = 899,
                        RSPGTotal = 1835,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 14,
                        Name = "Food",
                        FundsFrom1 = "College",
                        Total1 = 704,
                        FundsFrom2 = "Private Donors",
                        Total2 = 840,
                        FundsFrom3 = "Fundraising",
                        Total3 = 637,
                        RSPGTotal = 1931,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 14,
                        Name = "Public Awareness",
                        FundsFrom1 = "College",
                        Total1 = 516,
                        FundsFrom2 = "Private Donors",
                        Total2 = 787,
                        FundsFrom3 = "Fundraising",
                        Total3 = 549,
                        RSPGTotal = 1621,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 15,
                        Name = "Food",
                        FundsFrom1 = "College",
                        Total1 = 903,
                        FundsFrom2 = "Private Donors",
                        Total2 = 615,
                        FundsFrom3 = "Fundraising",
                        Total3 = 650,
                        RSPGTotal = 1351,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 15,
                        Name = "Public Awareness",
                        FundsFrom1 = "College",
                        Total1 = 654,
                        FundsFrom2 = "Private Donors",
                        Total2 = 850,
                        FundsFrom3 = "Fundraising",
                        Total3 = 728,
                        RSPGTotal = 1159,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 16,
                        Name = "Food",
                        FundsFrom1 = "College",
                        Total1 = 575,
                        FundsFrom2 = "Private Donors",
                        Total2 = 584,
                        FundsFrom3 = "Fundraising",
                        Total3 = 685,
                        RSPGTotal = 1434,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 16,
                        Name = "Public Awareness",
                        FundsFrom1 = "College",
                        Total1 = 865,
                        FundsFrom2 = "Private Donors",
                        Total2 = 987,
                        FundsFrom3 = "Fundraising",
                        Total3 = 725,
                        RSPGTotal = 1386,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 17,
                        Name = "Food",
                        FundsFrom1 = "College",
                        Total1 = 694,
                        RSPGTotal = 1642,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 17,
                        Name = "Public Awareness",
                        FundsFrom1 = "College",
                        Total1 = 878,
                        RSPGTotal = 1480,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 18,
                        Name = "Food",
                        FundsFrom1 = "College",
                        Total1 = 809,
                        RSPGTotal = 1655,
                    },

                    new OtherResource
                    {
                        BudgetFormId = 18,
                        Name = "Public Awareness",
                        FundsFrom1 = "College",
                        Total1 = 827,
                        RSPGTotal = 1643,
                    },
                    new OtherResource
                    {
                        BudgetFormId = 19,
                        Name = "Computer Parts",
                        RSPGTotal = 1275,
                    },
                    new OtherResource
                    {
                        BudgetFormId = 20,
                        Name = "Computer Parts",
                        RSPGTotal = 1275,
                    },
                    new OtherResource
                    {
                        BudgetFormId = 21,
                        Name = "Computer Parts",
                        RSPGTotal = 1275,
                    },
                    new OtherResource
                    {
                        BudgetFormId = 22,
                        Name = "Computer Parts",
                        RSPGTotal = 1275,
                    },
                    new OtherResource
                    {
                        BudgetFormId = 23,
                        Name = "Computer Parts",
                        RSPGTotal = 1275,
                    },
                    new OtherResource
                    {
                        BudgetFormId = 24,
                        Name = "Computer Parts",
                        RSPGTotal = 1275,
                    },
                    new OtherResource
                    {
                        BudgetFormId = 25,
                        Name = "Computer Parts",
                        RSPGTotal = 1275,
                    },
                    new OtherResource
                    {
                        BudgetFormId = 26,
                        Name = "Computer Parts",
                        RSPGTotal = 1275,
                    }

                );
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Add departments to the database
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddRatings(IServiceProvider serviceProvider)
        {
            using (var context = new RSPGApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RSPGApplicationContext>>()))
            {
                if (context == null || context.Rating == null)
                {
                    throw new ArgumentNullException("RSPGApplicationContext");
                }

                if (context.Rating.Any())
                {
                    return;
                }

                context.Rating.AddRange(

                    new Rating
                    {
                        UserId = 1,
                        RSPGFormId = 1,
                        RSPGRating = 52,
                    },

                    new Rating
                    {
                        UserId = 2,
                        RSPGFormId = 1,
                        RSPGRating = 56,
                    },

                    new Rating
                    {
                        UserId = 3,
                        RSPGFormId = 1,
                        RSPGRating = 81,
                    },

                    new Rating
                    {
                        UserId = 4,
                        RSPGFormId = 1,
                        RSPGRating = 88,
                    },

                    new Rating
                    {
                        UserId = 5,
                        RSPGFormId = 1,
                        RSPGRating = 53,
                    },

                    new Rating
                    {
                        UserId = 6,
                        RSPGFormId = 1,
                        RSPGRating = 78,
                    },

                    new Rating
                    {
                        UserId = 7,
                        RSPGFormId = 1,
                        RSPGRating = 70,
                    },

                    new Rating
                    {
                        UserId = 8,
                        RSPGFormId = 1,
                        RSPGRating = 85,
                    },

                    new Rating
                    {
                        UserId = 9,
                        RSPGFormId = 1,
                        RSPGRating = 59,
                    },

                    new Rating
                    {
                        UserId = 10,
                        RSPGFormId = 1,
                        RSPGRating = 70,
                    },

                    new Rating
                    {
                        UserId = 11,
                        RSPGFormId = 1,
                        RSPGRating = 50,
                    },

                    new Rating
                    {
                        UserId = 12,
                        RSPGFormId = 1,
                        RSPGRating = 59,
                    },

                    new Rating
                    {
                        UserId = 13,
                        RSPGFormId = 1,
                        RSPGRating = 89,
                    },

                    new Rating
                    {
                        UserId = 14,
                        RSPGFormId = 1,
                        RSPGRating = 83,
                    },

                    new Rating
                    {
                        UserId = 15,
                        RSPGFormId = 1,
                        RSPGRating = 88,
                    },

                    new Rating
                    {
                        UserId = 1,
                        RSPGFormId = 2,
                        RSPGRating = 81,
                    },

                    new Rating
                    {
                        UserId = 2,
                        RSPGFormId = 2,
                        RSPGRating = 84,
                    },

                    new Rating
                    {
                        UserId = 3,
                        RSPGFormId = 2,
                        RSPGRating = 54,
                    },

                    new Rating
                    {
                        UserId = 4,
                        RSPGFormId = 2,
                        RSPGRating = 94,
                    },

                    new Rating
                    {
                        UserId = 5,
                        RSPGFormId = 2,
                        RSPGRating = 72,
                    },

                    new Rating
                    {
                        UserId = 6,
                        RSPGFormId = 2,
                        RSPGRating = 83,
                    },

                    new Rating
                    {
                        UserId = 7,
                        RSPGFormId = 2,
                        RSPGRating = 67,
                    },

                    new Rating
                    {
                        UserId = 8,
                        RSPGFormId = 2,
                        RSPGRating = 74,
                    },

                    new Rating
                    {
                        UserId = 9,
                        RSPGFormId = 2,
                        RSPGRating = 89,
                    },

                    new Rating
                    {
                        UserId = 10,
                        RSPGFormId = 2,
                        RSPGRating = 79,
                    },

                    new Rating
                    {
                        UserId = 11,
                        RSPGFormId = 2,
                        RSPGRating = 58,
                    },

                    new Rating
                    {
                        UserId = 12,
                        RSPGFormId = 2,
                        RSPGRating = 52,
                    },

                    new Rating
                    {
                        UserId = 13,
                        RSPGFormId = 2,
                        RSPGRating = 77,
                    },

                    new Rating
                    {
                        UserId = 14,
                        RSPGFormId = 2,
                        RSPGRating = 78,
                    },

                    new Rating
                    {
                        UserId = 15,
                        RSPGFormId = 2,
                        RSPGRating = 78,
                    },

                    new Rating
                    {
                        UserId = 1,
                        RSPGFormId = 3,
                        RSPGRating = 86,
                    },

                    new Rating
                    {
                        UserId = 2,
                        RSPGFormId = 3,
                        RSPGRating = 62,
                    },

                    new Rating
                    {
                        UserId = 3,
                        RSPGFormId = 3,
                        RSPGRating = 59,
                    },

                    new Rating
                    {
                        UserId = 4,
                        RSPGFormId = 3,
                        RSPGRating = 93,
                    },

                    new Rating
                    {
                        UserId = 5,
                        RSPGFormId = 3,
                        RSPGRating = 74,
                    },

                    new Rating
                    {
                        UserId = 6,
                        RSPGFormId = 3,
                        RSPGRating = 73,
                    },

                    new Rating
                    {
                        UserId = 7,
                        RSPGFormId = 3,
                        RSPGRating = 81,
                    },

                    new Rating
                    {
                        UserId = 8,
                        RSPGFormId = 3,
                        RSPGRating = 85,
                    },

                    new Rating
                    {
                        UserId = 9,
                        RSPGFormId = 3,
                        RSPGRating = 51,
                    },

                    new Rating
                    {
                        UserId = 10,
                        RSPGFormId = 3,
                        RSPGRating = 69,
                    },

                    new Rating
                    {
                        UserId = 11,
                        RSPGFormId = 3,
                        RSPGRating = 56,
                    },

                    new Rating
                    {
                        UserId = 12,
                        RSPGFormId = 3,
                        RSPGRating = 88,
                    },

                    new Rating
                    {
                        UserId = 13,
                        RSPGFormId = 3,
                        RSPGRating = 60,
                    },

                    new Rating
                    {
                        UserId = 14,
                        RSPGFormId = 3,
                        RSPGRating = 56,
                    },

                    new Rating
                    {
                        UserId = 15,
                        RSPGFormId = 3,
                        RSPGRating = 82,
                    },

                    new Rating
                    {
                        UserId = 1,
                        RSPGFormId = 4,
                        RSPGRating = 51,
                    },

                    new Rating
                    {
                        UserId = 2,
                        RSPGFormId = 4,
                        RSPGRating = 76,
                    },

                    new Rating
                    {
                        UserId = 3,
                        RSPGFormId = 4,
                        RSPGRating = 71,
                    },

                    new Rating
                    {
                        UserId = 4,
                        RSPGFormId = 4,
                        RSPGRating = 85,
                    },

                    new Rating
                    {
                        UserId = 5,
                        RSPGFormId = 4,
                        RSPGRating = 74,
                    },

                    new Rating
                    {
                        UserId = 6,
                        RSPGFormId = 4,
                        RSPGRating = 84,
                    },

                    new Rating
                    {
                        UserId = 7,
                        RSPGFormId = 4,
                        RSPGRating = 65,
                    },

                    new Rating
                    {
                        UserId = 8,
                        RSPGFormId = 4,
                        RSPGRating = 53,
                    },

                    new Rating
                    {
                        UserId = 9,
                        RSPGFormId = 4,
                        RSPGRating = 65,
                    },

                    new Rating
                    {
                        UserId = 10,
                        RSPGFormId = 4,
                        RSPGRating = 95,
                    },

                    new Rating
                    {
                        UserId = 11,
                        RSPGFormId = 4,
                        RSPGRating = 73,
                    },

                    new Rating
                    {
                        UserId = 12,
                        RSPGFormId = 4,
                        RSPGRating = 76,
                    },

                    new Rating
                    {
                        UserId = 13,
                        RSPGFormId = 4,
                        RSPGRating = 90,
                    },

                    new Rating
                    {
                        UserId = 14,
                        RSPGFormId = 4,
                        RSPGRating = 53,
                    },

                    new Rating
                    {
                        UserId = 15,
                        RSPGFormId = 4,
                        RSPGRating = 77,
                    },

                    new Rating
                    {
                        UserId = 1,
                        RSPGFormId = 5,
                        RSPGRating = 82,
                    },

                    new Rating
                    {
                        UserId = 2,
                        RSPGFormId = 5,
                        RSPGRating = 85,
                    },

                    new Rating
                    {
                        UserId = 3,
                        RSPGFormId = 5,
                        RSPGRating = 70,
                    },

                    new Rating
                    {
                        UserId = 4,
                        RSPGFormId = 5,
                        RSPGRating = 78,
                    },

                    new Rating
                    {
                        UserId = 5,
                        RSPGFormId = 5,
                        RSPGRating = 65,
                    },

                    new Rating
                    {
                        UserId = 6,
                        RSPGFormId = 5,
                        RSPGRating = 68,
                    },

                    new Rating
                    {
                        UserId = 7,
                        RSPGFormId = 5,
                        RSPGRating = 78,
                    },

                    new Rating
                    {
                        UserId = 8,
                        RSPGFormId = 5,
                        RSPGRating = 53,
                    },

                    new Rating
                    {
                        UserId = 9,
                        RSPGFormId = 5,
                        RSPGRating = 80,
                    },

                    new Rating
                    {
                        UserId = 10,
                        RSPGFormId = 5,
                        RSPGRating = 81,
                    },

                    new Rating
                    {
                        UserId = 11,
                        RSPGFormId = 5,
                        RSPGRating = 59,
                    },

                    new Rating
                    {
                        UserId = 12,
                        RSPGFormId = 5,
                        RSPGRating = 60,
                    },

                    new Rating
                    {
                        UserId = 13,
                        RSPGFormId = 5,
                        RSPGRating = 77,
                    },

                    new Rating
                    {
                        UserId = 14,
                        RSPGFormId = 5,
                        RSPGRating = 56,
                    },

                    new Rating
                    {
                        UserId = 15,
                        RSPGFormId = 5,
                        RSPGRating = 70,
                    },

                    new Rating
                    {
                        UserId = 1,
                        RSPGFormId = 6,
                        RSPGRating = 74,
                    },

                    new Rating
                    {
                        UserId = 2,
                        RSPGFormId = 6,
                        RSPGRating = 88,
                    },

                    new Rating
                    {
                        UserId = 3,
                        RSPGFormId = 6,
                        RSPGRating = 77,
                    },

                    new Rating
                    {
                        UserId = 4,
                        RSPGFormId = 6,
                        RSPGRating = 72,
                    },

                    new Rating
                    {
                        UserId = 5,
                        RSPGFormId = 6,
                        RSPGRating = 84,
                    },

                    new Rating
                    {
                        UserId = 6,
                        RSPGFormId = 6,
                        RSPGRating = 87,
                    },

                    new Rating
                    {
                        UserId = 7,
                        RSPGFormId = 6,
                        RSPGRating = 82,
                    },

                    new Rating
                    {
                        UserId = 8,
                        RSPGFormId = 6,
                        RSPGRating = 65,
                    },

                    new Rating
                    {
                        UserId = 9,
                        RSPGFormId = 6,
                        RSPGRating = 95,
                    },

                    new Rating
                    {
                        UserId = 10,
                        RSPGFormId = 6,
                        RSPGRating = 53,
                    },

                    new Rating
                    {
                        UserId = 11,
                        RSPGFormId = 6,
                        RSPGRating = 50,
                    },

                    new Rating
                    {
                        UserId = 12,
                        RSPGFormId = 6,
                        RSPGRating = 64,
                    },

                    new Rating
                    {
                        UserId = 13,
                        RSPGFormId = 6,
                        RSPGRating = 70,
                    },

                    new Rating
                    {
                        UserId = 14,
                        RSPGFormId = 6,
                        RSPGRating = 60,
                    },

                    new Rating
                    {
                        UserId = 15,
                        RSPGFormId = 6,
                        RSPGRating = 60,
                    },

                    new Rating
                    {
                        UserId = 1,
                        RSPGFormId = 7,
                        RSPGRating = 78,
                    },

                    new Rating
                    {
                        UserId = 2,
                        RSPGFormId = 7,
                        RSPGRating = 56,
                    },

                    new Rating
                    {
                        UserId = 3,
                        RSPGFormId = 7,
                        RSPGRating = 67,
                    },

                    new Rating
                    {
                        UserId = 4,
                        RSPGFormId = 7,
                        RSPGRating = 56,
                    },

                    new Rating
                    {
                        UserId = 5,
                        RSPGFormId = 7,
                        RSPGRating = 54,
                    },

                    new Rating
                    {
                        UserId = 6,
                        RSPGFormId = 7,
                        RSPGRating = 84,
                    },

                    new Rating
                    {
                        UserId = 7,
                        RSPGFormId = 7,
                        RSPGRating = 90,
                    },

                    new Rating
                    {
                        UserId = 8,
                        RSPGFormId = 7,
                        RSPGRating = 92,
                    },

                    new Rating
                    {
                        UserId = 9,
                        RSPGFormId = 7,
                        RSPGRating = 82,
                    },

                    new Rating
                    {
                        UserId = 10,
                        RSPGFormId = 7,
                        RSPGRating = 66,
                    },

                    new Rating
                    {
                        UserId = 11,
                        RSPGFormId = 7,
                        RSPGRating = 79,
                    },

                    new Rating
                    {
                        UserId = 12,
                        RSPGFormId = 7,
                        RSPGRating = 76,
                    },

                    new Rating
                    {
                        UserId = 13,
                        RSPGFormId = 7,
                        RSPGRating = 63,
                    },

                    new Rating
                    {
                        UserId = 14,
                        RSPGFormId = 7,
                        RSPGRating = 92,
                    },

                    new Rating
                    {
                        UserId = 15,
                        RSPGFormId = 7,
                        RSPGRating = 50,
                    },

                    new Rating
                    {
                        UserId = 1,
                        RSPGFormId = 8,
                        RSPGRating = 69,
                    },

                    new Rating
                    {
                        UserId = 2,
                        RSPGFormId = 8,
                        RSPGRating = 63,
                    },

                    new Rating
                    {
                        UserId = 3,
                        RSPGFormId = 8,
                        RSPGRating = 62,
                    },

                    new Rating
                    {
                        UserId = 4,
                        RSPGFormId = 8,
                        RSPGRating = 66,
                    },

                    new Rating
                    {
                        UserId = 5,
                        RSPGFormId = 8,
                        RSPGRating = 92,
                    },

                    new Rating
                    {
                        UserId = 6,
                        RSPGFormId = 8,
                        RSPGRating = 59,
                    },

                    new Rating
                    {
                        UserId = 7,
                        RSPGFormId = 8,
                        RSPGRating = 71,
                    },

                    new Rating
                    {
                        UserId = 8,
                        RSPGFormId = 8,
                        RSPGRating = 74,
                    },

                    new Rating
                    {
                        UserId = 9,
                        RSPGFormId = 8,
                        RSPGRating = 94,
                    },

                    new Rating
                    {
                        UserId = 10,
                        RSPGFormId = 8,
                        RSPGRating = 55,
                    },

                    new Rating
                    {
                        UserId = 11,
                        RSPGFormId = 8,
                        RSPGRating = 95,
                    },

                    new Rating
                    {
                        UserId = 12,
                        RSPGFormId = 8,
                        RSPGRating = 61,
                    },

                    new Rating
                    {
                        UserId = 13,
                        RSPGFormId = 8,
                        RSPGRating = 59,
                    },

                    new Rating
                    {
                        UserId = 14,
                        RSPGFormId = 8,
                        RSPGRating = 58,
                    },

                    new Rating
                    {
                        UserId = 15,
                        RSPGFormId = 8,
                        RSPGRating = 80,
                    },

                    new Rating
                    {
                        UserId = 1,
                        RSPGFormId = 9,
                        RSPGRating = 69,
                    },

                    new Rating
                    {
                        UserId = 2,
                        RSPGFormId = 9,
                        RSPGRating = 86,
                    },

                    new Rating
                    {
                        UserId = 3,
                        RSPGFormId = 9,
                        RSPGRating = 63,
                    },

                    new Rating
                    {
                        UserId = 4,
                        RSPGFormId = 9,
                        RSPGRating = 59,
                    },

                    new Rating
                    {
                        UserId = 5,
                        RSPGFormId = 9,
                        RSPGRating = 84,
                    },

                    new Rating
                    {
                        UserId = 6,
                        RSPGFormId = 9,
                        RSPGRating = 72,
                    },

                    new Rating
                    {
                        UserId = 7,
                        RSPGFormId = 9,
                        RSPGRating = 91,
                    },

                    new Rating
                    {
                        UserId = 8,
                        RSPGFormId = 9,
                        RSPGRating = 80,
                    },

                    new Rating
                    {
                        UserId = 9,
                        RSPGFormId = 9,
                        RSPGRating = 90,
                    },

                    new Rating
                    {
                        UserId = 10,
                        RSPGFormId = 9,
                        RSPGRating = 81,
                    },

                    new Rating
                    {
                        UserId = 11,
                        RSPGFormId = 9,
                        RSPGRating = 89,
                    },

                    new Rating
                    {
                        UserId = 12,
                        RSPGFormId = 9,
                        RSPGRating = 86,
                    },

                    new Rating
                    {
                        UserId = 13,
                        RSPGFormId = 9,
                        RSPGRating = 80,
                    },

                    new Rating
                    {
                        UserId = 14,
                        RSPGFormId = 9,
                        RSPGRating = 60,
                    },

                    new Rating
                    {
                        UserId = 15,
                        RSPGFormId = 9,
                        RSPGRating = 89,
                    },

                    new Rating
                    {
                        UserId = 1,
                        RSPGFormId = 10,
                        RSPGRating = 66,
                    },

                    new Rating
                    {
                        UserId = 2,
                        RSPGFormId = 10,
                        RSPGRating = 92,
                    },

                    new Rating
                    {
                        UserId = 3,
                        RSPGFormId = 10,
                        RSPGRating = 92,
                    },

                    new Rating
                    {
                        UserId = 4,
                        RSPGFormId = 10,
                        RSPGRating = 82,
                    },

                    new Rating
                    {
                        UserId = 5,
                        RSPGFormId = 10,
                        RSPGRating = 63,
                    },

                    new Rating
                    {
                        UserId = 6,
                        RSPGFormId = 10,
                        RSPGRating = 69,
                    },

                    new Rating
                    {
                        UserId = 7,
                        RSPGFormId = 10,
                        RSPGRating = 51,
                    },

                    new Rating
                    {
                        UserId = 8,
                        RSPGFormId = 10,
                        RSPGRating = 73,
                    },

                    new Rating
                    {
                        UserId = 9,
                        RSPGFormId = 10,
                        RSPGRating = 69,
                    },

                    new Rating
                    {
                        UserId = 10,
                        RSPGFormId = 10,
                        RSPGRating = 54,
                    },

                    new Rating
                    {
                        UserId = 11,
                        RSPGFormId = 10,
                        RSPGRating = 78,
                    },

                    new Rating
                    {
                        UserId = 12,
                        RSPGFormId = 10,
                        RSPGRating = 79,
                    },

                    new Rating
                    {
                        UserId = 13,
                        RSPGFormId = 10,
                        RSPGRating = 77,
                    },

                    new Rating
                    {
                        UserId = 14,
                        RSPGFormId = 10,
                        RSPGRating = 75,
                    },

                    new Rating
                    {
                        UserId = 15,
                        RSPGFormId = 10,
                        RSPGRating = 67,
                    },

                    new Rating
                    {
                        UserId = 1,
                        RSPGFormId = 11,
                        RSPGRating = 80,
                    },

                    new Rating
                    {
                        UserId = 2,
                        RSPGFormId = 11,
                        RSPGRating = 58,
                    },

                    new Rating
                    {
                        UserId = 3,
                        RSPGFormId = 11,
                        RSPGRating = 80,
                    },

                    new Rating
                    {
                        UserId = 4,
                        RSPGFormId = 11,
                        RSPGRating = 84,
                    },

                    new Rating
                    {
                        UserId = 5,
                        RSPGFormId = 11,
                        RSPGRating = 64,
                    },

                    new Rating
                    {
                        UserId = 6,
                        RSPGFormId = 11,
                        RSPGRating = 72,
                    },

                    new Rating
                    {
                        UserId = 7,
                        RSPGFormId = 11,
                        RSPGRating = 94,
                    },

                    new Rating
                    {
                        UserId = 8,
                        RSPGFormId = 11,
                        RSPGRating = 90,
                    },

                    new Rating
                    {
                        UserId = 9,
                        RSPGFormId = 11,
                        RSPGRating = 67,
                    },

                    new Rating
                    {
                        UserId = 10,
                        RSPGFormId = 11,
                        RSPGRating = 95,
                    },

                    new Rating
                    {
                        UserId = 11,
                        RSPGFormId = 11,
                        RSPGRating = 92,
                    },

                    new Rating
                    {
                        UserId = 12,
                        RSPGFormId = 11,
                        RSPGRating = 63,
                    },

                    new Rating
                    {
                        UserId = 13,
                        RSPGFormId = 11,
                        RSPGRating = 86,
                    },

                    new Rating
                    {
                        UserId = 14,
                        RSPGFormId = 11,
                        RSPGRating = 66,
                    },

                    new Rating
                    {
                        UserId = 15,
                        RSPGFormId = 11,
                        RSPGRating = 64,
                    },

                    new Rating
                    {
                        UserId = 1,
                        RSPGFormId = 12,
                        RSPGRating = 54,
                    },

                    new Rating
                    {
                        UserId = 2,
                        RSPGFormId = 12,
                        RSPGRating = 76,
                    },

                    new Rating
                    {
                        UserId = 3,
                        RSPGFormId = 12,
                        RSPGRating = 72,
                    },

                    new Rating
                    {
                        UserId = 4,
                        RSPGFormId = 12,
                        RSPGRating = 65,
                    },

                    new Rating
                    {
                        UserId = 5,
                        RSPGFormId = 12,
                        RSPGRating = 62,
                    },

                    new Rating
                    {
                        UserId = 6,
                        RSPGFormId = 12,
                        RSPGRating = 62,
                    },

                    new Rating
                    {
                        UserId = 7,
                        RSPGFormId = 12,
                        RSPGRating = 56,
                    },

                    new Rating
                    {
                        UserId = 8,
                        RSPGFormId = 12,
                        RSPGRating = 52,
                    },

                    new Rating
                    {
                        UserId = 9,
                        RSPGFormId = 12,
                        RSPGRating = 79,
                    },

                    new Rating
                    {
                        UserId = 10,
                        RSPGFormId = 12,
                        RSPGRating = 61,
                    },

                    new Rating
                    {
                        UserId = 11,
                        RSPGFormId = 12,
                        RSPGRating = 54,
                    },

                    new Rating
                    {
                        UserId = 12,
                        RSPGFormId = 12,
                        RSPGRating = 53,
                    },

                    new Rating
                    {
                        UserId = 13,
                        RSPGFormId = 12,
                        RSPGRating = 80,
                    },

                    new Rating
                    {
                        UserId = 14,
                        RSPGFormId = 12,
                        RSPGRating = 57,
                    },

                    new Rating
                    {
                        UserId = 15,
                        RSPGFormId = 12,
                        RSPGRating = 69,
                    },

                    new Rating
                    {
                        UserId = 1,
                        RSPGFormId = 13,
                        RSPGRating = 93,
                    },

                    new Rating
                    {
                        UserId = 2,
                        RSPGFormId = 13,
                        RSPGRating = 62,
                    },

                    new Rating
                    {
                        UserId = 3,
                        RSPGFormId = 13,
                        RSPGRating = 78,
                    },

                    new Rating
                    {
                        UserId = 4,
                        RSPGFormId = 13,
                        RSPGRating = 66,
                    },

                    new Rating
                    {
                        UserId = 5,
                        RSPGFormId = 13,
                        RSPGRating = 85,
                    },

                    new Rating
                    {
                        UserId = 6,
                        RSPGFormId = 13,
                        RSPGRating = 87,
                    },

                    new Rating
                    {
                        UserId = 7,
                        RSPGFormId = 13,
                        RSPGRating = 69,
                    },

                    new Rating
                    {
                        UserId = 8,
                        RSPGFormId = 13,
                        RSPGRating = 72,
                    },

                    new Rating
                    {
                        UserId = 9,
                        RSPGFormId = 13,
                        RSPGRating = 50,
                    },

                    new Rating
                    {
                        UserId = 10,
                        RSPGFormId = 13,
                        RSPGRating = 63,
                    },

                    new Rating
                    {
                        UserId = 11,
                        RSPGFormId = 13,
                        RSPGRating = 52,
                    },

                    new Rating
                    {
                        UserId = 12,
                        RSPGFormId = 13,
                        RSPGRating = 89,
                    },

                    new Rating
                    {
                        UserId = 13,
                        RSPGFormId = 13,
                        RSPGRating = 91,
                    },

                    new Rating
                    {
                        UserId = 14,
                        RSPGFormId = 13,
                        RSPGRating = 93,
                    },

                    new Rating
                    {
                        UserId = 15,
                        RSPGFormId = 13,
                        RSPGRating = 51,
                    },

                    new Rating
                    {
                        UserId = 1,
                        RSPGFormId = 14,
                        RSPGRating = 75,
                    },

                    new Rating
                    {
                        UserId = 2,
                        RSPGFormId = 14,
                        RSPGRating = 71,
                    },

                    new Rating
                    {
                        UserId = 3,
                        RSPGFormId = 14,
                        RSPGRating = 56,
                    },

                    new Rating
                    {
                        UserId = 4,
                        RSPGFormId = 14,
                        RSPGRating = 58,
                    },

                    new Rating
                    {
                        UserId = 5,
                        RSPGFormId = 14,
                        RSPGRating = 91,
                    },

                    new Rating
                    {
                        UserId = 6,
                        RSPGFormId = 14,
                        RSPGRating = 53,
                    },

                    new Rating
                    {
                        UserId = 7,
                        RSPGFormId = 14,
                        RSPGRating = 88,
                    },

                    new Rating
                    {
                        UserId = 8,
                        RSPGFormId = 14,
                        RSPGRating = 53,
                    },

                    new Rating
                    {
                        UserId = 9,
                        RSPGFormId = 14,
                        RSPGRating = 51,
                    },

                    new Rating
                    {
                        UserId = 10,
                        RSPGFormId = 14,
                        RSPGRating = 60,
                    },

                    new Rating
                    {
                        UserId = 11,
                        RSPGFormId = 14,
                        RSPGRating = 53,
                    },

                    new Rating
                    {
                        UserId = 12,
                        RSPGFormId = 14,
                        RSPGRating = 60,
                    },

                    new Rating
                    {
                        UserId = 13,
                        RSPGFormId = 14,
                        RSPGRating = 84,
                    },

                    new Rating
                    {
                        UserId = 14,
                        RSPGFormId = 14,
                        RSPGRating = 56,
                    },

                    new Rating
                    {
                        UserId = 15,
                        RSPGFormId = 14,
                        RSPGRating = 68,
                    },

                    new Rating
                    {
                        UserId = 1,
                        RSPGFormId = 15,
                        RSPGRating = 89,
                    },

                    new Rating
                    {
                        UserId = 2,
                        RSPGFormId = 15,
                        RSPGRating = 91,
                    },

                    new Rating
                    {
                        UserId = 3,
                        RSPGFormId = 15,
                        RSPGRating = 68,
                    },

                    new Rating
                    {
                        UserId = 4,
                        RSPGFormId = 15,
                        RSPGRating = 50,
                    },

                    new Rating
                    {
                        UserId = 5,
                        RSPGFormId = 15,
                        RSPGRating = 58,
                    },

                    new Rating
                    {
                        UserId = 6,
                        RSPGFormId = 15,
                        RSPGRating = 86,
                    },

                    new Rating
                    {
                        UserId = 7,
                        RSPGFormId = 15,
                        RSPGRating = 69,
                    },

                    new Rating
                    {
                        UserId = 8,
                        RSPGFormId = 15,
                        RSPGRating = 64,
                    },

                    new Rating
                    {
                        UserId = 9,
                        RSPGFormId = 15,
                        RSPGRating = 53,
                    },

                    new Rating
                    {
                        UserId = 10,
                        RSPGFormId = 15,
                        RSPGRating = 68,
                    },

                    new Rating
                    {
                        UserId = 11,
                        RSPGFormId = 15,
                        RSPGRating = 73,
                    },

                    new Rating
                    {
                        UserId = 12,
                        RSPGFormId = 15,
                        RSPGRating = 61,
                    },

                    new Rating
                    {
                        UserId = 13,
                        RSPGFormId = 15,
                        RSPGRating = 54,
                    },

                    new Rating
                    {
                        UserId = 14,
                        RSPGFormId = 15,
                        RSPGRating = 92,
                    },

                    new Rating
                    {
                        UserId = 15,
                        RSPGFormId = 15,
                        RSPGRating = 54,
                    },

                    new Rating
                    {
                        UserId = 1,
                        RSPGFormId = 16,
                        RSPGRating = 57,
                    },

                    new Rating
                    {
                        UserId = 2,
                        RSPGFormId = 16,
                        RSPGRating = 53,
                    },

                    new Rating
                    {
                        UserId = 3,
                        RSPGFormId = 16,
                        RSPGRating = 79,
                    },

                    new Rating
                    {
                        UserId = 4,
                        RSPGFormId = 16,
                        RSPGRating = 58,
                    },

                    new Rating
                    {
                        UserId = 5,
                        RSPGFormId = 16,
                        RSPGRating = 77,
                    },

                    new Rating
                    {
                        UserId = 6,
                        RSPGFormId = 16,
                        RSPGRating = 74,
                    },

                    new Rating
                    {
                        UserId = 7,
                        RSPGFormId = 16,
                        RSPGRating = 66,
                    },

                    new Rating
                    {
                        UserId = 8,
                        RSPGFormId = 16,
                        RSPGRating = 73,
                    },

                    new Rating
                    {
                        UserId = 9,
                        RSPGFormId = 16,
                        RSPGRating = 67,
                    },

                    new Rating
                    {
                        UserId = 10,
                        RSPGFormId = 16,
                        RSPGRating = 70,
                    },

                    new Rating
                    {
                        UserId = 11,
                        RSPGFormId = 16,
                        RSPGRating = 85,
                    },

                    new Rating
                    {
                        UserId = 12,
                        RSPGFormId = 16,
                        RSPGRating = 57,
                    },

                    new Rating
                    {
                        UserId = 13,
                        RSPGFormId = 16,
                        RSPGRating = 83,
                    },

                    new Rating
                    {
                        UserId = 14,
                        RSPGFormId = 16,
                        RSPGRating = 93,
                    },

                    new Rating
                    {
                        UserId = 15,
                        RSPGFormId = 16,
                        RSPGRating = 75,
                    },

                    new Rating
                    {
                        UserId = 1,
                        RSPGFormId = 17,
                        RSPGRating = 92,
                    },

                    new Rating
                    {
                        UserId = 2,
                        RSPGFormId = 17,
                        RSPGRating = 71,
                    },

                    new Rating
                    {
                        UserId = 3,
                        RSPGFormId = 17,
                        RSPGRating = 91,
                    },

                    new Rating
                    {
                        UserId = 4,
                        RSPGFormId = 17,
                        RSPGRating = 56,
                    },

                    new Rating
                    {
                        UserId = 5,
                        RSPGFormId = 17,
                        RSPGRating = 59,
                    },

                    new Rating
                    {
                        UserId = 6,
                        RSPGFormId = 17,
                        RSPGRating = 59,
                    },

                    new Rating
                    {
                        UserId = 7,
                        RSPGFormId = 17,
                        RSPGRating = 91,
                    },

                    new Rating
                    {
                        UserId = 8,
                        RSPGFormId = 17,
                        RSPGRating = 56,
                    },

                    new Rating
                    {
                        UserId = 9,
                        RSPGFormId = 17,
                        RSPGRating = 53,
                    },

                    new Rating
                    {
                        UserId = 10,
                        RSPGFormId = 17,
                        RSPGRating = 80,
                    },

                    new Rating
                    {
                        UserId = 11,
                        RSPGFormId = 17,
                        RSPGRating = 70,
                    },

                    new Rating
                    {
                        UserId = 12,
                        RSPGFormId = 17,
                        RSPGRating = 88,
                    },

                    new Rating
                    {
                        UserId = 13,
                        RSPGFormId = 17,
                        RSPGRating = 69,
                    },

                    new Rating
                    {
                        UserId = 14,
                        RSPGFormId = 17,
                        RSPGRating = 79,
                    },

                    new Rating
                    {
                        UserId = 15,
                        RSPGFormId = 17,
                        RSPGRating = 90,
                    },

                    new Rating
                    {
                        UserId = 1,
                        RSPGFormId = 18,
                        RSPGRating = 57,
                    },

                    new Rating
                    {
                        UserId = 2,
                        RSPGFormId = 18,
                        RSPGRating = 67,
                    },

                    new Rating
                    {
                        UserId = 3,
                        RSPGFormId = 18,
                        RSPGRating = 83,
                    },

                    new Rating
                    {
                        UserId = 4,
                        RSPGFormId = 18,
                        RSPGRating = 60,
                    },

                    new Rating
                    {
                        UserId = 5,
                        RSPGFormId = 18,
                        RSPGRating = 78,
                    },

                    new Rating
                    {
                        UserId = 6,
                        RSPGFormId = 18,
                        RSPGRating = 84,
                    },

                    new Rating
                    {
                        UserId = 7,
                        RSPGFormId = 18,
                        RSPGRating = 85,
                    },

                    new Rating
                    {
                        UserId = 8,
                        RSPGFormId = 18,
                        RSPGRating = 55,
                    },

                    new Rating
                    {
                        UserId = 9,
                        RSPGFormId = 18,
                        RSPGRating = 52,
                    },

                    new Rating
                    {
                        UserId = 10,
                        RSPGFormId = 18,
                        RSPGRating = 85,
                    },

                    new Rating
                    {
                        UserId = 11,
                        RSPGFormId = 18,
                        RSPGRating = 60,
                    },

                    new Rating
                    {
                        UserId = 12,
                        RSPGFormId = 18,
                        RSPGRating = 95,
                    },

                    new Rating
                    {
                        UserId = 13,
                        RSPGFormId = 18,
                        RSPGRating = 63,
                    },

                    new Rating
                    {
                        UserId = 14,
                        RSPGFormId = 18,
                        RSPGRating = 85,
                    },

                    new Rating
                    {
                        UserId = 15,
                        RSPGFormId = 18,
                        RSPGRating = 55,
                    }


                );
                context.SaveChanges();
            }
        }
    }
}
