using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Student
    {
        private static int _no;
        public int No { get; }
        public string FullName { get; set; }
        public Dictionary<string, double> Exams { get; set; }
        public Student()
        {
            _no++;
            No = _no;
            Exams = new Dictionary<string, double>();
        }
        public void AddExam(string examName, double point)
        {
            Exams.Add(examName, point);
        }
        public double GetExamResult(string examName)
        {
            return Exams[examName];
        }
        public double GetExamAvg()
        {
            double result = 0;
            foreach (var item in Exams)
            {
                result += item.Value;
            }
            return result / Exams.Count;
        }
    }
}
