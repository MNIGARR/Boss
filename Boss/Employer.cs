using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Worker;
using Notification;
using Vacancy;

namespace Boss
{
    //id
    //name
    //surname
    //Sheher
    //Phone
    //Age
    //Vacancies
    internal class Employer
    {
        static int Id { get; set; } = 0;
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public List<Vacancyc> vacancies { get; set; } = new List<Vacancyc>();
        public List<Workerc> Workers { get; set; } = null;
        public Notificationc Notifications { get; set; } = new Notificationc();
        public List<Workerc> Applicant { get; set; } = new List<Workerc>();
        public List<Workerc> ApplicantVacancies { get; set; } = new List<Workerc>();

        public Employer( string username, string password, string name, string surname, int age, string city, string phone)
        {
            id = ++Id;
            this.username = username;
            this.password = password;
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.city = city;
            this.phone = phone;
        }
        public void ShowEmployer()
        {
            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Surname: {surname}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"City: {city}");
            Console.WriteLine($"Phone: {phone}");
            Console.WriteLine($"Vacancy count: {vacancies}");
        }

        public Vacancyc GetVacancyById(int id)
        {
            foreach (var vacancy in vacancies)
            {
                if (vacancy.id == id)
                {
                    return vacancy;
                }
            }
            return null;
        }
    }
}
