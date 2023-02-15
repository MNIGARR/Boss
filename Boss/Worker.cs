using Boss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using CV;
using Notification;
using Vacancy;

namespace Worker
{
    internal class Workerc 
    {
        static int Id { get; set; } = 0;
        public int id { get; set; }
        public CVc cv { get; set; } = null;
        public string name { get; set; }
        public string surname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int age { get; set; }
        public string city { get; set; }
        public string Phone { get; set; }

        public Notificationc Notification { get; set; } = new Notificationc();
        public List<Employer> Applicant { get; set; } = new List<Employer>();
        public List<Vacancyc> ApplicantVacancy { get; set; } = new List<Vacancyc>();

        public Workerc() { }
        public Workerc( string name, string surname, string username, string password, int age, string city, string phone)
        {
            id = ++Id;
            this.name = name;
            this.surname = surname;
            this.username = username;
            this.password = password;
            this.age = age;
            this.city = city;
            Phone = phone;
        }

        public void AddCv(CVc cv)
        {
            this.cv = cv;
        }
        public new void WorkerInfoShow()
        {
            Console.WriteLine($"Id : {Id}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Surname: {surname}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"City: {city}");
            Console.WriteLine($"Phone: {Phone}");
        }

        public void ShowCv()
        {
            Console.WriteLine($"Speciality: {cv.Qualification}");

            Console.WriteLine($"School: {cv.School}");

            Console.WriteLine($"University score: {cv.UniversityScore}");

            cv.Skills.ForEach(s => Console.WriteLine($"Skill/s: {s}"));

            cv.Companies.ForEach(c => Console.WriteLine($"Company/s: {c}"));

            Console.WriteLine($"Work start time: {cv.StartTime}");
            Console.WriteLine($"Work end time: {cv.EndTime}");
          
            cv.Languages.ForEach(l => Console.WriteLine($"Language/s: {l}"));

            if (cv.HasHonorDiplom)
            {
                Console.WriteLine($"Honors diploma: Yes");
            }
            else
            {
                Console.WriteLine($"Honors diploma: No");
            }
            if (cv.GitLink != null)
            {
                Console.WriteLine($"Github link: {cv.GitLink}");
            }
            if (cv.Linkedin != null)
            {
                Console.WriteLine($"Linkedin link: {cv.Linkedin}");
            }
        }
    }
}

