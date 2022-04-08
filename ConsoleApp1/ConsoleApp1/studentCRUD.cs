using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class studentCRUD
    {
        public void AddStudent(Student student)
        {
            Data.Students.Add(student);
        }
        public Student GetStudentByNo(int? no)
        {
            if(no == null)
                throw new NullReferenceException();
            Student student = Data.Students.Find(x => x.No == no);
            if(student == null)
                throw new NullReferenceException();
            return student;
        }
        public List<Student> GetAllStudent()
        {
            return Data.Students;
        }
    }
}
