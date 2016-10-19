namespace RepoQuiz.Migrations
{
    using DAL;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RepoQuiz.DAL.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RepoQuiz.DAL.StudentContext context)
        {
            NameGenerator generator1 = new NameGenerator();
            Student student1 = generator1.GenerateStudentData();
            Student student2 = generator1.GenerateStudentData();
            Student student3 = generator1.GenerateStudentData();
            Student student4 = generator1.GenerateStudentData();
            Student student5 = generator1.GenerateStudentData();
            Student student6 = generator1.GenerateStudentData();
            Student student7 = generator1.GenerateStudentData();
            Student student8 = generator1.GenerateStudentData();
            Student student9 = generator1.GenerateStudentData();
            Student student10 = generator1.GenerateStudentData();
            Student student11 = generator1.GenerateStudentData();
            Student student12 = generator1.GenerateStudentData();
            Student student13 = generator1.GenerateStudentData();
            Student student14 = generator1.GenerateStudentData();
            Student student15 = generator1.GenerateStudentData();
            Student student16 = generator1.GenerateStudentData();
            Student student17 = generator1.GenerateStudentData();
            Student student18 = generator1.GenerateStudentData();
            Student student19 = generator1.GenerateStudentData();
            Student student20 = generator1.GenerateStudentData();
            Student student21 = generator1.GenerateStudentData();
            Student student22 = generator1.GenerateStudentData();
            Student student23 = generator1.GenerateStudentData();
            Student student24 = generator1.GenerateStudentData();
            Student student25 = generator1.GenerateStudentData();
            Student student26 = generator1.GenerateStudentData();
            Student student27 = generator1.GenerateStudentData();
            Student student28 = generator1.GenerateStudentData();
            Student student29 = generator1.GenerateStudentData();
            Student student30 = generator1.GenerateStudentData();

            context.Students.AddOrUpdate(
            s => new {s.FirstName, s.LastName, s.Major }, student1, student2, student3, student4, student5, student6, student7, student8, student9, student10, student11, student12, student13, student14, student15, student16, student17, student18, student19, student20, student21, student22, student23, student24, student25, student26, student27, student28, student29, student30


            );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
