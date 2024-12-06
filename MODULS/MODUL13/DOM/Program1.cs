using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL13.DOM
{
    // Модель заявки на вакансию
    class JobApplication
    {
        public string DepartmentHead { get; set; }
        public string Position { get; set; }
        public bool IsApproved { get; set; } = false;
    }

    // Модель кандидата
    class Candidate
    {
        public string Name { get; set; }
        public string Resume { get; set; }
        public bool IsQualified { get; set; } = false;
        public bool PassedInterview { get; set; } = false;
    }

    class HiringSystem
    {
        private List<JobApplication> jobApplications = new List<JobApplication>();
        private List<Candidate> candidates = new List<Candidate>();

        // Метод для создания заявки на вакансию
        public void SubmitJobApplication(JobApplication application)
        {
            Console.WriteLine($"Руководитель создает заявку на позицию: {application.Position}");
            if (CheckApplicationRequirements(application))
            {
                application.IsApproved = true;
                Console.WriteLine("Заявка утверждена HR-отделом.");
            }
            else
            {
                Console.WriteLine("Заявка отклонена. Требуется доработка.");
            }
            jobApplications.Add(application);
        }

        // Метод проверки заявки
        private bool CheckApplicationRequirements(JobApplication application)
        {
            // Упрощенная логика проверки заявки
            return !string.IsNullOrEmpty(application.Position);
        }

        // Метод публикации вакансии
        public void PublishJob(JobApplication application)
        {
            if (application.IsApproved)
            {
                Console.WriteLine($"Вакансия на позицию {application.Position} опубликована.");
            }
        }

        // Метод подачи заявки кандидатом
        public void SubmitCandidateApplication(Candidate candidate)
        {
            Console.WriteLine($"Кандидат {candidate.Name} подает заявку.");
            if (CheckCandidateResume(candidate))
            {
                candidate.IsQualified = true;
                Console.WriteLine("Кандидат приглашен на собеседование.");
            }
            else
            {
                Console.WriteLine("Заявка кандидата отклонена.");
            }
            candidates.Add(candidate);
        }

        // Проверка резюме кандидата
        private bool CheckCandidateResume(Candidate candidate)
        {
            // Упрощенная логика проверки резюме
            return !string.IsNullOrEmpty(candidate.Resume);
        }

        // Проведение собеседований
        public void ConductInterviews(Candidate candidate)
        {
            if (candidate.IsQualified)
            {
                Console.WriteLine($"Проведение первичного интервью с кандидатом {candidate.Name}.");
                Console.WriteLine($"Проведение технического собеседования с кандидатом {candidate.Name}.");

                // Упрощенная логика оценки собеседования
                candidate.PassedInterview = true;
                Console.WriteLine("Кандидату предложен оффер.");
            }
            else
            {
                Console.WriteLine($"Кандидат {candidate.Name} не приглашен на собеседование.");
            }
        }

        // Завершение процесса найма
        public void FinalizeHiring(Candidate candidate)
        {
            if (candidate.PassedInterview)
            {
                Console.WriteLine($"Кандидат {candidate.Name} подтверждает оффер.");
                Console.WriteLine("Сотрудник добавлен в базу данных компании.");
                NotifyITDepartment();
            }
            else
            {
                Console.WriteLine($"Кандидат {candidate.Name} получил уведомление об отказе.");
            }
        }

        // Уведомление IT-отдела
        private void NotifyITDepartment()
        {
            Console.WriteLine("HR-отдел уведомляет IT-отдел о необходимости настройки рабочего места.");
        }
    }

    internal class Program1
    {
        /*static void Main(string[] args)
        {
            HiringSystem system = new HiringSystem();

            // Этап 1: Создание заявки на вакансию
            JobApplication application = new JobApplication { DepartmentHead = "Ернар Калдарбек", Position = "Программист" };
            system.SubmitJobApplication(application);

            // Этап 2: Публикация вакансии
            system.PublishJob(application);

            // Этап 3: Прием заявок от кандидатов
            Candidate candidate = new Candidate { Name = "Макс Бак", Resume = "Резюме" };
            system.SubmitCandidateApplication(candidate);

            // Этап 4: Проведение собеседований
            system.ConductInterviews(candidate);

            // Этап 5: Завершение процесса найма
            system.FinalizeHiring(candidate);
        }*/
    }
}
