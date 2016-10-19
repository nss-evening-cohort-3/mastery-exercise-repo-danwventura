using RepoQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepoQuiz.DAL
{
    public class NameGenerator
    {
        // This class should be used to generate random names and Majors for Students.
        // This is NOT your Repository
        // All methods should be Unit Tested :)
        String[] first_names = new String[] { "Mary", "Susan", "Kim", "Jane", "Stephanie", "Louise", "Rachel", "Amanda", "Austin", "Sam", "John", "Paul", "Chris", "Matt", "David", "Tim", "Luke", "Dan", "Brad", "Zach" };
        String[] last_names = new String[] { "Smith", "Johnson", "Anderson", "Ventura", "Gallagher", "Stevenson", "Martinez", "Xiao", "Fields", "Cuba", "Robinson", "White", "Black", "Green", "Long", "Byram", "Rupp", "Hamill", "Zullo", "McDonald" };
        String[] majors = new String[] { "English", "Physics", "Pre-Med", "Linguistics", "Political Science", "Hospitality", "Electrical Engineering", "Chemistry", "Finance", "Chinese", "French", "BioChemistry", "Material Sciences", "Theatre", "History", "Computer Science",  "Japanese", "Asian Studies", "Education", "Pre-Law" };

        Random random_int = new Random();
        

        public Student GenerateStudentData()
        {
            

           
            Student new_student = new Student();
            int random_name_index = random_int.Next(0, 20);
            int random_major_index = random_int.Next(0, 20);

            new_student.FirstName = first_names[random_name_index];
            new_student.LastName = last_names[random_name_index];
            new_student.Major = majors[random_major_index];

            return new_student;
        }
    }
}