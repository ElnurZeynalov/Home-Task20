using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            studentCRUD studentCRUD = new studentCRUD();
            bool exit = false;
            do
            {
                Console.WriteLine("\n============Menu===============\n");
                Console.WriteLine("1. Telebe elave et\n2. Telebeye imtahan elave et\n3. Telebenin bir imtahan balına bax\n4. Telebenin bütün imtahanlarını göster\n5. Telebenin imtahan ortalamasını göster\n6. Telebeden imtahan sil\n0. Proqramı bitir");
                string choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        Console.Write("Telebenin adi ve soyadi: ");
                        string fullName = Console.ReadLine();
                        Student student = new Student();
                        student.FullName = fullName;
                        studentCRUD.AddStudent(student);
                        break;
                    case "2":
                        int no = IntChecker("Imtahan elave edilecek telebein No daxil edin\nNo: ", "No yalniz reqem olmalidir");
                        if (Data.Students.Exists(x => x.No == no))
                        {
                            Student wantedStudent = studentCRUD.GetStudentByNo(no);
                            Console.Write("Imtahan adini daxil edin: ");
                            string examName = Console.ReadLine();
                            double examPoint = DoubleChecker("Imtahandan topladigi bali daxil edin: ", "Imtahan bali 0-100 arasi ve yalniz reqem olmalidir");
                            wantedStudent.AddExam(examName, examPoint);
                        }
                        break;
                    case "3":
                        no = IntChecker("Balina baxilacaq telebein No daxil edin\nNo: ", "No yalniz reqem olmalidir");
                        if (Data.Students.Exists(x => x.No == no))
                        {
                            Student wantedStudent = studentCRUD.GetStudentByNo(no);
                            Console.Write("Balina baxilacaq imtahan adini daxil edin\nImtahan adi: ");
                            string examNameForPoint = Console.ReadLine();
                            Console.WriteLine(wantedStudent.Exams[examNameForPoint]);
                        }
                        break;
                    case "4":
                        no = IntChecker("Imtahan ballarina baxilacaq telebein No daxil edin\nNo: ", "No yalniz reqem olmalidir");
                        if (Data.Students.Exists(x => x.No == no))
                        {
                            Student wantedStudent = studentCRUD.GetStudentByNo(no);
                            foreach (var item in wantedStudent.Exams)
                            {
                                Console.WriteLine(item.Key + " - " + item.Value);
                            }
                        }
                        break;
                    case "5":
                        no = IntChecker("Imtahan ballarinin ortalamasina baxilacaq telebein No daxil edin\nNo: ", "No yalniz reqem olmalidir");
                        if (Data.Students.Exists(x => x.No == no))
                        {
                            Student wantedStudent = studentCRUD.GetStudentByNo(no);
                            Console.WriteLine(wantedStudent.GetExamAvg());
                        }
                        break;
                    case "6":
                        no = IntChecker("Imtahani silinecek telebein No daxil edin\nNo: ", "No yalniz reqem olmalidir");
                        if (Data.Students.Exists(x => x.No == no))
                        {
                            Student wantedStudent = studentCRUD.GetStudentByNo(no);
                            Console.Write("Silinecek imtahan adi: ");
                            string removedExamName = Console.ReadLine();
                            wantedStudent.Exams.Remove(removedExamName);
                        }
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("0-6 arsi bir reqem daxil edin");
                        break;
                }
            } while (!exit);
        }
        static int IntChecker(string text1, string text2)
        {
            int value;
            string valueStr;
            do
            {
                Console.Write(text1);
                valueStr = Console.ReadLine();
                if (!int.TryParse(valueStr, out value))
                    Console.WriteLine(text2);
            } while (!int.TryParse(valueStr, out value));
            return value = Convert.ToInt32(valueStr);
        }
        static double DoubleChecker(string text1, string text2)
        {
            double value;
            string valueStr;
            do
            {
                do
                {
                    Console.Write(text1);
                    valueStr = Console.ReadLine();
                    if (!double.TryParse(valueStr, out value))
                        Console.WriteLine(text2);
                } while (!double.TryParse(valueStr, out value));
                value = Convert.ToDouble(valueStr);
            } while (!(value >= 0 && value <= 100));
            return value;
        }
    }
}
