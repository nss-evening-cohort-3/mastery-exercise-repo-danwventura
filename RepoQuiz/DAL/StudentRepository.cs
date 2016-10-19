using RepoQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepoQuiz.DAL
{
    public class StudentRepository
    {
        public StudentContext Context {get; set;}

        public StudentRepository()
        {
            Context = new StudentContext();
        }

        public StudentRepository(StudentContext _context)
        {
            Context = _context;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> all_students =  Context.Students.ToList();
            return all_students;
        }

        public void AddNewStudent(Student student)
        {
            Context.Students.Add(student);
            Context.SaveChanges();
        }

        public Student FindStudentById(int student_id)
        {
            Student found_student = Context.Students.FirstOrDefault(a => a.StudentID == student_id);
            return found_student;
        }
    }
}