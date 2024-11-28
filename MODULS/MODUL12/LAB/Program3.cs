using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL12.LAB
{
    // Интерфейс пользователя
    public interface IUser
    {
        void Register();
        void Login();
    }

    // Класс Студента
    public class Student : IUser
    {
        public void Register()
        {
            Console.WriteLine("Студент зарегистрирован.");
        }

        public void Login()
        {
            Console.WriteLine("Студент вошел в систему.");
        }

        public void ViewCourses()
        {
            Console.WriteLine("Студент просматривает доступные курсы.");
        }

        public void EnrollInCourse()
        {
            Console.WriteLine("Студент записался на курс.");
        }

        public void TakeTest()
        {
            Console.WriteLine("Студент проходит тест.");
        }

        public void LeaveReview()
        {
            Console.WriteLine("Студент оставил отзыв.");
        }
    }

    // Класс Преподавателя
    public class Instructor : IUser
    {
        public void Register()
        {
            Console.WriteLine("Преподаватель зарегистрирован.");
        }

        public void Login()
        {
            Console.WriteLine("Преподаватель вошел в систему.");
        }

        public void CreateOrEditCourse()
        {
            Console.WriteLine("Преподаватель создает или редактирует курс.");
        }

        public void AddCourseMaterial()
        {
            Console.WriteLine("Преподаватель добавляет материалы курса.");
        }

        public void CreateTest()
        {
            Console.WriteLine("Преподаватель создает тест для курса.");
        }

        public void ViewStudentStatistics()
        {
            Console.WriteLine("Преподаватель просматривает статистику успеваемости студентов.");
        }

        public void ModerateReviews()
        {
            Console.WriteLine("Преподаватель модерирует отзывы.");
        }
    }

    // Класс Администратора
    public class Administrator : IUser
    {
        public void Register()
        {
            Console.WriteLine("Администратор зарегистрирован.");
        }

        public void Login()
        {
            Console.WriteLine("Администратор вошел в систему.");
        }

        public void ManageUserAccounts()
        {
            Console.WriteLine("Администратор управляет учетными записями пользователей.");
        }

        public void ManageCourseCategories()
        {
            Console.WriteLine("Администратор управляет категориями курсов.");
        }

        public void ViewAnalytics()
        {
            Console.WriteLine("Администратор просматривает аналитику системы.");
        }
    }
    internal class Program3
    {
        /*public static void Main(string[] args)
        {
            IUser student = new Student();
            student.Register();
            student.Login();
            ((Student)student).ViewCourses();
            ((Student)student).EnrollInCourse();
            ((Student)student).TakeTest();
            ((Student)student).LeaveReview();

            IUser instructor = new Instructor();
            instructor.Register();
            instructor.Login();
            ((Instructor)instructor).CreateOrEditCourse();
            ((Instructor)instructor).AddCourseMaterial();
            ((Instructor)instructor).CreateTest();
            ((Instructor)instructor).ViewStudentStatistics();
            ((Instructor)instructor).ModerateReviews();

            IUser admin = new Administrator();
            admin.Register();
            admin.Login();
            ((Administrator)admin).ManageUserAccounts();
            ((Administrator)admin).ManageCourseCategories();
            ((Administrator)admin).ViewAnalytics();
        }*/
    }
}
