using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker;
using CV;
using Notification;
using Vacancy;
using System.Data;

namespace Boss
{
    class Func
    {
        #region CreatCv
        static public void CreatCv(Workerc worker, List<Workerc> workers, int index)
        {
            Console.Write("Enter qualification: ");
            var qualification = Console.ReadLine();
            Console.Write("Enter school you graduated: ");
            var school = Console.ReadLine();
            Console.Write("Enter university: ");
            var university = Console.ReadLine();
            Console.Write("Enter skill: ");
            var skill = Console.ReadLine();
            var skills = new List<string> { };
            skills.Add(skill);
            Console.Write("Do you want to add another skill? (Y/N)");
            while (true)
            {
                var result = Console.ReadLine();
                if (result.ToUpper() == "Y")
                {
                    Console.Write("Enter skill: ");
                    var newSkill = Console.ReadLine();
                    skills.Add(newSkill);
                }
                else if (result.ToUpper() == "N")
                {
                    break;
                }
            }
            Console.Write("Enter company: ");
            var companies = Console.ReadLine();
            var companiess = new List<string> { };
            companiess.Add(companies);
            Console.Write("Do you want to add another companie? (Y/N)");
            while (true)
            {
                var result = Console.ReadLine();
                if (result.ToUpper() == "Y")
                {
                    Console.Write("Enter company: ");
                    var newCompany = Console.ReadLine();
                    companiess.Add(newCompany);
                }
                else if (result.ToUpper() == "N")
                {
                    break;
                }
            }
            Console.Write("Enter language: ");
            var language = Console.ReadLine();
            var languages = new List<string> { };
            languages.Add(language);
            Console.Write("Do you want to add another company? (Y/N)");
            while (true)
            {
                var result = Console.ReadLine();
                if (result.ToUpper() == "Y")
                {
                    Console.Write("Enter companies: ");
                    var newLanguage = Console.ReadLine();
                    languages.Add(newLanguage);
                }
                else if (result.ToUpper() == "N")
                {
                    break;
                }
            }
            Console.Write("Enter work start date: ");
            string? start = Console.ReadLine();
            Console.Write("Enter work end date: ");
            var end = Console.ReadLine();
            Console.Write("Honors Diploma (Y/N): ");
            var checkDiplom = Console.ReadLine();
            bool HonorsDiploma = false;
            if (checkDiplom.ToUpper() == "Y")
            {
                HonorsDiploma = true;
            }
            Console.Write("Gitlink (Y/N): ");
            var checkGit = Console.ReadLine();
            string gitlink = null;
            if (checkGit.ToUpper() == "Y")
            {
                gitlink = Console.ReadLine();
            }
            Console.Write("Linkedin (Y/N): ");
            var checkLinkedin = Console.ReadLine();
            string linkedin = null;
            if (checkLinkedin.ToUpper() == "Y")
            {
                linkedin = Console.ReadLine();
            }
            CVc cV = new CVc()
            {
                Qualification = qualification,
                School = school,
                UniversityScore = university,
                Skills = skills,
                Companies = companiess,
                StartTime = $"{start}",
                EndTime = $"{end}",
                Languages = languages,
                HasHonorDiplom = HonorsDiploma,
                GitLink = gitlink,
                Linkedin = linkedin
            };

        }
        #endregion


        #region Worker
        static public void Worker(Workerc worker, List<Employer> employers, int index1, List<Workerc> workers)
        {
            string?[] menuOptions = new string[] { "\n\t\t 1. Show CV   ", "\n\t\t 2. Search vacancy   ", "\n\t\t 3. Update CV   ", "\n\t\t 4. Creat CV   ", "\n\t\t 5. Notification   ", "\n\t\t 6. Sign out   ", "\n\t\t 7. Exit   " };
            int workerMenuSelect = 0;

            while (true)
            {
                Console.Clear();
                string a = "\n\t\t\t\t\t\t";
                //Console.WriteLine($"{a}Welcome {worker.name} {worker.surname}");

                while (true)
                {
                    Console.Clear();
                    Console.CursorVisible = false;

                    for (int i = 0; i < menuOptions.Length; i++)
                    {
                        Console.WriteLine((i == workerMenuSelect ? " *" : "") + menuOptions[i] + (i == workerMenuSelect ? "<--" : ""));
                    }

                    var pressedKey = Console.ReadKey();

                    if (pressedKey.Key == ConsoleKey.DownArrow && workerMenuSelect != menuOptions.Length - 1)
                    {
                        workerMenuSelect++;
                    }
                    else if (pressedKey.Key == ConsoleKey.UpArrow && workerMenuSelect >= 1)
                    {
                        workerMenuSelect--;
                    }
                    else if (pressedKey.Key == ConsoleKey.Enter)
                    {
                        switch (workerMenuSelect)
                        {
                            case 0:
                                if (worker.cv != null)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Your CV");
                                    worker.ShowCv();
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write("You have no CV. Please create your Cv!");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                                break;
                            case 1:
                                string search = String.Empty;
                                int result;
                                while (true)
                                {
                                    var letter = Console.ReadKey();
                                    if (letter.Key == ConsoleKey.D1 || letter.Key == ConsoleKey.D2 ||
                                        letter.Key == ConsoleKey.D3 || letter.Key == ConsoleKey.D4 ||
                                        letter.Key == ConsoleKey.D5 || letter.Key == ConsoleKey.D6 ||
                                        letter.Key == ConsoleKey.D7 || letter.Key == ConsoleKey.D8 ||
                                        letter.Key == ConsoleKey.D9)
                                    {
                                        var result1 = letter.Key.ToString();
                                        result1 = result1.Replace('D', ' ');
                                        result = int.Parse(result1);
                                        break;
                                    }
                                    Console.Clear();
                                    search += letter.KeyChar;
                                    search = search.ToLower();
                                    if (letter.Key == ConsoleKey.Backspace)
                                    {
                                        search = "";
                                    }
                                    Console.WriteLine(search);
                                    var selectedVacancy = from e in employers
                                                          from v in e.vacancies
                                                          where v.Specification.ToLower().Contains(search)
                                                          select v;
                                    foreach (var vacancy in selectedVacancy)
                                    {
                                        Console.WriteLine($"{vacancy.id} - {vacancy.Specification}");
                                    }
                                    Console.WriteLine("\n\n");
                                }
                                Console.Clear();
                                var vacancy1 = from e in employers
                                               from v in e.vacancies
                                               where v.id == result
                                               select v;
                                Vacancyc vacancyResult = new Vacancyc();
                                foreach (var vacancy in vacancy1)
                                {
                                    vacancyResult = vacancy;
                                }
                                vacancyResult.ShowVacancy();
                                Console.WriteLine("1. Apply");
                                Console.WriteLine("2. Back");
                                Console.Write("Select : ");
                                var select1 = Console.ReadLine();
                                if (select1 == "1")
                                {
                                    for (int i = 0; i < employers.Count; i++)
                                    {
                                        for (int k = 0; k < employers[i].vacancies.Count; k++)
                                        {
                                            if (result == employers[i].vacancies[k].id)
                                            {
                                                employers[i].Notifications.Count += 1;
                                                employers[i].Applicant.Add(worker);
                                                employers[i].vacancies.Add(vacancyResult);
                                            }
                                        }
                                    }
                                    Notificationc notification = new Notificationc();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("Request sent successfully");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                                else if (select1 == "2") { }
                                break;
                            case 2:
                                while (true)
                                {
                                    if (worker.cv != null)
                                    {
                                        string?[] CVmenuOptions = new string[] { "\t 1. Qualification   ", "\t 2. School   ", "\t 3. University Score   ", "\t 4. Skills   ", "\t 5. Companies   ", "\t 6. Languages   ", "\t 7. Check honor diplom   ", "\t 8. GitLink   ", "\t9. Linkedin   ", "\t 10. Exit   " };
                                        int CVmenuSelect = 0;
                                        while (true)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Your CV");
                                            worker.ShowCv();
                                            for (int i = 0; i < CVmenuOptions.Length; i++)
                                            {
                                                Console.WriteLine((i == CVmenuSelect ? "* " : "") + CVmenuOptions[i] + (i == CVmenuSelect ? "<--" : ""));
                                            }

                                            var key = Console.ReadKey();

                                            if (key.Key == ConsoleKey.DownArrow && CVmenuSelect != menuOptions.Length - 1)
                                            {
                                                CVmenuSelect++;
                                            }
                                            else if (key.Key == ConsoleKey.UpArrow && CVmenuSelect >= 1)
                                            {
                                                CVmenuSelect--;
                                            }

                                            else if (key.Key == ConsoleKey.Enter)
                                            {
                                                switch (CVmenuSelect)
                                                {
                                                    case 0:

                                                        Console.Write("Enter new speciality: ");
                                                        var newspeciality = Console.ReadLine();
                                                        worker.cv.Qualification = newspeciality;
                                                        workers[index1].cv.Qualification = newspeciality;
                                                        break;
                                                    case 1:
                                                        Console.Write("Enter new school: ");
                                                        var newSchool = Console.ReadLine();
                                                        worker.cv.School = newSchool;
                                                        workers[index1].cv.School = newSchool;
                                                        break;
                                                    case 2:
                                                        Console.Write("Enter new university: ");
                                                        var newUni = Console.ReadLine();
                                                        worker.cv.UniversityScore = newUni;
                                                        workers[index1].cv.UniversityScore = newUni;
                                                        break;
                                                    case 3:
                                                        Console.Write("Add or uptade? (1/2) : ");
                                                        var choise = Console.ReadLine();
                                                        if (choise == "1")
                                                        {
                                                            Console.Write("Enter skill : ");
                                                            var skill = Console.ReadLine();
                                                            worker.cv.Skills.Add(skill);
                                                            workers[index1].cv.Skills.Add(skill);
                                                            Console.Write("Do you want to add a new skill? (Y/N)");
                                                            while (true)
                                                            {
                                                                var skillupdate = Console.ReadLine();
                                                                if (skillupdate.ToUpper() == "Y")
                                                                {
                                                                    Console.Write("Enter skill : ");
                                                                    var skill1 = Console.ReadLine();
                                                                    worker.cv.Skills.Add(skill1);
                                                                    workers[index1].cv.Skills.Add(skill1);
                                                                }
                                                                else if (skillupdate.ToUpper() == "N")
                                                                {
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        else if (choise == "2")
                                                        {
                                                            bool flag = true;
                                                            while (flag)
                                                            {
                                                                Console.Clear();
                                                                worker.cv.Skills.ForEach(s => Console.WriteLine($"Skill : {s}"));
                                                                Console.Write("Enter skill name : ");
                                                                var skill = Console.ReadLine();
                                                                foreach (var skill1 in worker.cv.Skills)
                                                                {
                                                                    if (skill == skill1)
                                                                    {
                                                                        Console.Write("Enter new skill name : ");
                                                                        var newSkill = Console.ReadLine();
                                                                        var index = worker.cv.Skills.IndexOf(skill1);
                                                                        worker.cv.Skills[index] = newSkill;
                                                                        workers[index1].cv.Skills[index] = newSkill;
                                                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                                        Console.Write("Succesfully!!! ");
                                                                        Console.ResetColor();
                                                                        Console.ReadKey();
                                                                        flag = false;
                                                                        break;
                                                                    }
                                                                }
                                                                if (flag)
                                                                {
                                                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                                                    Console.WriteLine("Skill not found!!");
                                                                    Console.ResetColor();
                                                                    Console.ReadKey();
                                                                }
                                                            }
                                                        }
                                                        break;
                                                    case 4:
                                                        Console.Write("Add or uptade? (1/2): ");
                                                        var CvUpdatechoise = Console.ReadLine();
                                                        if (CvUpdatechoise == "1")
                                                        {
                                                            Console.Write("Enter companies: ");
                                                            var companies = Console.ReadLine();
                                                            worker.cv.Companies.Add(companies);
                                                            workers[index1].cv.Companies.Add(companies);
                                                            Console.Write("Do you want to add a new company? (Y/N)");
                                                            while (true)
                                                            {
                                                                var newCompCh = Console.ReadLine();
                                                                if (newCompCh.ToUpper() == "Y")
                                                                {
                                                                    Console.Write("Enter company: ");
                                                                    var addcompany = Console.ReadLine();
                                                                    worker.cv.Companies.Add(addcompany);
                                                                    workers[index1].cv.Companies.Add(addcompany);
                                                                }
                                                                else if (newCompCh.ToUpper() == "N")
                                                                {
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        else if (CvUpdatechoise == "2")
                                                        {
                                                            bool flag = true;
                                                            while (flag)
                                                            {
                                                                Console.Clear();
                                                                worker.cv.Companies.ForEach(cmpns => Console.WriteLine($"Companies: {cmpns}"));
                                                                Console.Write("Enter companies name: ");
                                                                var companies = Console.ReadLine();
                                                                foreach (var companies1 in worker.cv.Companies)
                                                                {
                                                                    if (companies == companies1)
                                                                    {
                                                                        Console.Write("Enter new company name: ");
                                                                        var newCompany = Console.ReadLine();
                                                                        var index = worker.cv.Companies.IndexOf(companies1);
                                                                        worker.cv.Companies[index] = newCompany;
                                                                        workers[index1].cv.Companies[index] = newCompany;
                                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                                        Console.Write("Succesfully!!!");
                                                                        Console.ResetColor();
                                                                        Console.ReadKey();
                                                                        flag = false;
                                                                        break;
                                                                    }
                                                                }
                                                                if (flag)
                                                                {
                                                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                                                    Console.WriteLine("Companies not found!!");
                                                                    Console.ResetColor();
                                                                    Console.ReadKey();
                                                                }
                                                            }
                                                        }
                                                        break;
                                                    case 5:
                                                        Console.Write("Add or uptade? (1/2): ");
                                                        var langChoice = Console.ReadLine();
                                                        if (langChoice == "1")
                                                        {
                                                            Console.Write("Enter language: ");
                                                            var language = Console.ReadLine();
                                                            worker.cv.Languages.Add(language);
                                                            workers[index1].cv.Languages.Add(language);
                                                            Console.Write("Do you want to add a new language? (Y/N)");
                                                            while (true)
                                                            {
                                                                var newLang = Console.ReadLine();
                                                                if (newLang.ToUpper() == "Y")
                                                                {
                                                                    Console.Write("Enter language: ");
                                                                    var language1 = Console.ReadLine();
                                                                    worker.cv.Languages.Add(language1);
                                                                    workers[index1].cv.Languages.Add(language1);
                                                                }
                                                                else if (newLang.ToUpper() == "N")
                                                                {
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        else if (langChoice == "2")
                                                        {
                                                            bool flag = true;
                                                            while (flag)
                                                            {
                                                                Console.Clear();
                                                                worker.cv.Languages.ForEach(s => Console.WriteLine($"Language: {s}"));
                                                                Console.Write("Enter language name: ");
                                                                var language = Console.ReadLine();
                                                                foreach (var language1 in worker.cv.Languages)
                                                                {
                                                                    if (language == language1)
                                                                    {
                                                                        Console.Write("Enter new language name : ");
                                                                        var newLanguage = Console.ReadLine();
                                                                        var index = worker.cv.Languages.IndexOf(language1);
                                                                        worker.cv.Languages[index] = newLanguage;
                                                                        workers[index1].cv.Languages[index] = newLanguage;
                                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                                        Console.Write("Succesfully!!!");
                                                                        Console.ResetColor();
                                                                        Console.ReadKey();
                                                                        flag = false;
                                                                        break;
                                                                    }
                                                                }
                                                                if (flag)
                                                                {
                                                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                                                    Console.WriteLine("Language not found!!");
                                                                    Console.ResetColor();
                                                                    Console.ReadKey();
                                                                }
                                                            }
                                                        }
                                                        break;
                                                    case 6:
                                                        if (worker.cv.HasHonorDiplom == false)
                                                        {
                                                            Console.Write("Do you want to add an honor diplom? (Y/N) : ");
                                                            var honordiplomch = Console.ReadLine();
                                                            if (honordiplomch.ToUpper() == "Y")
                                                            {
                                                                worker.cv.HasHonorDiplom = true;
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.Write("Succesfully!!! ");
                                                                Console.ResetColor();
                                                                Console.ReadKey();
                                                            }
                                                            else if (honordiplomch.ToUpper() == "N") { }
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                            Console.WriteLine("You have a diploma of distinction");
                                                            Console.ResetColor();
                                                            Console.ReadKey();
                                                        }
                                                        break;
                                                    case 7:
                                                        if (worker.cv.GitLink == null)
                                                        {
                                                            Console.Write("Enter gitlink: ");
                                                            var githublink = Console.ReadLine();
                                                            worker.cv.GitLink = githublink;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                            Console.WriteLine("You have a github link");
                                                            Console.ResetColor();
                                                            Console.ReadKey();
                                                        }
                                                        break;
                                                    case 8:
                                                        if (worker.cv.Linkedin == null)
                                                        {
                                                            Console.Write("Enter linkedin link: ");
                                                            var linkedin = Console.ReadLine();
                                                            worker.cv.GitLink = linkedin;
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                            Console.WriteLine("You have a linkedin");
                                                            Console.ResetColor();
                                                            Console.ReadKey();
                                                        }
                                                        break;
                                                    case 9:
                                                        Worker(worker, employers, index1, workers);
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                }
                            case 3:
                                if (worker.cv == null)
                                {
                                    CreatCv(worker, workers, index1);
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.Write("You already have a CV !");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                                break;
                            case 5:
                                if (worker.Applicant.Count != 0)
                                {
                                    worker.Applicant.ForEach(e => e.ShowEmployer());
                                    worker.ApplicantVacancy.ForEach(v => v.ShowVacancy());
                                    Console.WriteLine(worker.Notification.NotificationContent);
                                    Console.ReadKey();
                                    worker.Applicant.Clear();
                                    worker.ApplicantVacancy.Clear();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("There is no information.");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                                break;
                            case 6:
                                Begin();
                                break;

                        }

                    }
                }

            }

        }
        #endregion


        #region Employer

        static public void Employer(Employer employer, List<Employer> employers)
        {
            string a = "\n\t\t\t";
            string?[] EmpmenuOptions = new string[] { "\n\t\t 1. Show vacancy/s   ", "\n\t\t 2. Add vacancy   ", "\n\t\t 3. Update vacancy   ", "\n\t\t 4. Exit   " };
            int EmpmenuSelect = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{a}Welcome {employer.name} {employer.surname}");

                for (int i = 0; i < EmpmenuOptions.Length; i++)
                {
                    Console.WriteLine((i == EmpmenuSelect ? " " : "") + EmpmenuOptions[i] + (i == EmpmenuSelect ? "<--" : ""));
                }

                var keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.DownArrow && EmpmenuSelect != EmpmenuOptions.Length - 1)
                {
                    EmpmenuSelect++;
                }
                else if (keyPressed.Key == ConsoleKey.UpArrow && EmpmenuSelect >= 1)
                {
                    EmpmenuSelect--;
                }
                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    switch (EmpmenuSelect)
                    {
                        case 0:

                            if (employer.vacancies.Count != 0)
                            {
                                employer.vacancies.ForEach(v => v.ShowVacancy());
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("You have not vacancy!!");
                                Console.ResetColor();
                                Console.ReadKey();
                            }
                            break;
                        case 1:
                            Console.WriteLine();
                            Console.Write("Specification: ");
                            var speciality = Console.ReadLine();

                            Console.WriteLine();
                            Console.Write("Salary: ");
                            var salary = double.Parse(Console.ReadLine());

                            Console.WriteLine();
                            Console.Write("Experience year: ");
                            var experienceYear = int.Parse(Console.ReadLine());

                            Vacancyc v1 = new Vacancyc(speciality, salary, experienceYear);
                            employer.vacancies.Add(v1);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Added succesfully!!!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case 2:
                            employer.vacancies.ForEach(v => v.ShowVacancy());
                            Console.Write("Enter vacancy id: ");
                            var id = int.Parse(Console.ReadLine());
                            var vacancy = employer.GetVacancyById(id);
                            if (vacancy != null)
                            {
                                Console.WriteLine("1. Speciality\n");
                                Console.WriteLine("2. Salary\n");
                                Console.WriteLine("3. Experience year\n");
                                Console.Write("Select: ");
                                var updatech = Console.ReadLine();
                                if (updatech == "1")
                                {
                                    Console.WriteLine();
                                    Console.Write("Enter new speciality: ");
                                    var newSpecification = Console.ReadLine();
                                    vacancy.Specification = newSpecification;
                                }
                                else if (updatech == "2")
                                {
                                    Console.WriteLine();
                                    Console.Write("Enetr new salary: ");
                                    var newSalary = double.Parse(Console.ReadLine());
                                    vacancy.Salary = newSalary;

                                }
                                else if (updatech == "3")
                                {
                                    Console.WriteLine();
                                    Console.Write("Enter new experience year: ");
                                    var newExperienceYear = int.Parse(Console.ReadLine());
                                    vacancy.Experience = newExperienceYear;
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write("Invalid select!!!");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.ReadKey();
                                }

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("Vacancy not found!!!");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.ReadKey();
                            }
                            break;
                        case 3:
                            Console.Clear();
                            Begin();
                            break;
                    }
                }

            }
        }
        #endregion


        static public void Begin()
        {
            List<Workerc> workers = new List<Workerc>();
            Workerc worker1 = new Workerc(
                "Baris_",
                "123Baris",
                "Baris",
                "Akarsu",
                25,
                "Istanbul",
                "0557132456");
            Workerc worker2 = new Workerc(
                "John_doe",
                "JD1357",
                "John",
                "Doe",
                29,
                "Canada",
                "0708080791");
            Workerc worker3 = new Workerc(
                "Aysu_mammadova",
                "ayandsu",
                "Aysu",
                "Qenberli",
                20,
                "Baku",
                "0503935567");
            worker1.AddCv(new CVc()
            {
                Qualification = "C# Developer",
                School = "244",
                UniversityScore = "BSU",
                Skills = new List<string> { "C#", "CSS", "HTML" },
                Companies = new List<string> { "Socar" },
                StartTime = " 20 / 05 / 2017 ",
                EndTime = " 10 / 10 / 2019 ",
                Languages = new List<string> { "English", "French" },
                HasHonorDiplom = false,
                GitLink = "github.com/1Baris3"
            });
            workers.Add(worker1);
            workers.Add(worker2);
            workers.Add(worker3);


            List<Employer> employers = new List<Employer>();
            Employer empl1 = new Employer(
                "nigar.m",
                "123niqa",
                "Nigar",
                "Mustafazada",
                45,
                "Baku",
                "0708095641");
            Employer empl2 = new Employer(
                "mammadova",
                "ay2ten",
                "Ayten",
                "Mammadova",
                21,
                "Baku",
                "+994555555555");
            empl1.vacancies.Add(new Vacancyc("Senior C# Developer", 7000, 4));
            empl2.vacancies.Add(new Vacancyc("Java Developer", 5000, 2));
            employers.Add(empl1);
            employers.Add(empl2);

            while (true)
            {
                Console.CursorVisible = false;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t\t::::::::    ::::::::::   ::::::::::   ::::::::::              :::          :::::::::       ");
                Console.WriteLine("\t\t\t::     ::   ::      ::   ::      ::   ::      ::             :: ::               ::        ");
                Console.WriteLine("\t\t\t::     ::   ::      ::   ::           ::                    ::   ::             ::         ");
                Console.WriteLine("\t\t\t::::::::    ::      ::   ::::::::::   ::::::::::           :::::::::           ::          ");
                Console.WriteLine("\t\t\t::     ::   ::      ::           ::           ::          ::       ::         ::           ");
                Console.WriteLine("\t\t\t::     ::   ::      ::           ::           ::         ::         ::      ::             ");
                Console.WriteLine("\t\t\t::::::::    ::::::::::   ::::::::::   ::::::::::   ::   ::           ::    ::::::::::      ");
                Console.ForegroundColor
           = ConsoleColor.Gray;
                Thread.Sleep(2000);


                string?[] mainMenuOptions = new string[] { "\n\t\t 1. Login   ", "\n\t\t 2. Sign up   " };
                int mainMenuSelect = 0;

                while (true)
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    Console.WriteLine("\n\n\t\t\t\t\t M A I N    M E N U:");


                    for (int i = 0; i < mainMenuOptions.Length; i++)
                    {
                        Console.WriteLine();
                        Console.WriteLine((i == mainMenuSelect ? " " : "") + mainMenuOptions[i] + (i == mainMenuSelect ? "<--" : ""));
                    }

                    var keyPressed = Console.ReadKey();

                    if (keyPressed.Key == ConsoleKey.DownArrow && mainMenuSelect != mainMenuOptions.Length - 1)
                    {
                        mainMenuSelect++;
                    }
                    else if (keyPressed.Key == ConsoleKey.UpArrow && mainMenuSelect >= 1)
                    {
                        mainMenuSelect--;
                    }
                    else if (keyPressed.Key == ConsoleKey.Enter)
                    {
                        switch (mainMenuSelect)
                        {
                            case 0:
                                Console.Clear();
                                Console.Write("\n\n******* Enter username: ");
                                string username = Console.ReadLine();
                                Console.Write("\n******* Enter password: ");
                                string password = Console.ReadLine();
                                Workerc worker = null;
                                int workerIndex = 0;
                                Employer employer = null;
                                for (int i = 0; i < workers.Count; i++)
                                {

                                    if (username == workers[i].username && password == workers[i].password)
                                    {
                                        worker = workers[i];
                                        workerIndex = i;
                                    }
                                }

                                for (int i = 0; i < employers.Count; i++)
                                {
                                    int employerIndex = 0;
                                    if (username == employers[i].username && password == employers[i].password)
                                    {
                                        employer = employers[i];
                                        employerIndex = i;
                                    }
                                }
                                if (worker != null)
                                {
                                    Worker(worker, employers, workerIndex, workers);
                                }
                                else if (employer != null)
                                {
                                    Employer(employer, employers);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\n\t\tUser is not found. Please try again!!");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                                break;
                            case 1:
                                while(true) { 
                                    Console.Clear();
                                    string?[] options = new string[] { "\n\t 1. Worker   ", "\n\t 2. Employer   ", "\n\t 3. Exit   "};
                                    int menuselect = 0;

                                    while (true)
                                    {

                                    Workerc workerlist = null;
                                    int wrkrIndex = 0;
                                    Employer employerr = null;
                                    int emplyrIndex = 0;
                                    Console.Clear();
                                    Console.CursorVisible = false;
                                    for (int i = 0; i < options.Length; i++)
                                    {
                                            Console.WriteLine();
                                        Console.WriteLine((i == menuselect ? "" : "") + options[i] + (i == menuselect ? "<--" : ""));
                                        }

                                        var chkeyPressed = Console.ReadKey();

                                        if (chkeyPressed.Key == ConsoleKey.DownArrow && menuselect != options.Length - 1)
                                        {
                                            menuselect++;
                                        }
                                        else if (chkeyPressed.Key == ConsoleKey.UpArrow && menuselect >= 1)
                                        {
                                            menuselect--;
                                        }
                                        else if (chkeyPressed.Key == ConsoleKey.Enter)
                                        {
                                            switch (menuselect)
                                            {
                                                case 0:
                                                    Console.WriteLine();
                                                    Console.Write("Enter name: ");
                                                    var workerName = Console.ReadLine();
                                                    Console.WriteLine();

                                                    Console.Write("Enter surname: ");
                                                    var workerSurname = Console.ReadLine();
                                                    Console.WriteLine();

                                                    Console.Write("Age: ");
                                                    var workerAge = int.Parse(Console.ReadLine());
                                                    Console.WriteLine();

                                                    Console.Write("Enter city: ");
                                                    var workerCity = Console.ReadLine();
                                                    Console.WriteLine();

                                                    Console.Write("Enter phone number: ");
                                                    var workerPhone = Console.ReadLine();
                                                    Console.WriteLine();

                                                    Console.Write("Enter username: ");
                                                    var workerUsername = Console.ReadLine();
                                                    Console.WriteLine();

                                                    Console.Write("Creat password: ");
                                                    var workerPassword = Console.ReadLine();
                                                    Console.WriteLine();

                                                    Workerc newWorker = new Workerc(workerName, workerSurname, workerUsername, workerPassword, workerAge, workerCity, workerPhone);
                                                    Console.WriteLine("Do you want add CV? (Y/N)");
                                                    var choise1 = Console.ReadLine();

                                                    if (choise1.ToUpper() == "Y")
                                                    {
                                                        CreatCv(newWorker, workers, wrkrIndex);
                                                    }
                                                    workers.Add(newWorker);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("Worker added successfully!!");
                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    Thread.Sleep(1800);
                                                    break;
                                                case 1:
                                                    Console.WriteLine();
                                                    Console.Write("Enter name: ");
                                                    var employerName = Console.ReadLine();
                                                    Console.WriteLine();

                                                    Console.Write("Enter surname: ");
                                                    var employerSurname = Console.ReadLine();
                                                    Console.WriteLine();

                                                    Console.Write("Age: ");
                                                    var employerAge = int.Parse(Console.ReadLine());
                                                    Console.WriteLine();

                                                    Console.Write("Enter city: ");
                                                    var employerCity = Console.ReadLine();
                                                    Console.WriteLine();

                                                    Console.Write("Enter phone number: ");
                                                    var employerPhone = Console.ReadLine();
                                                    Console.WriteLine();

                                                    Console.Write("Enter username: ");
                                                    var employerUsername = Console.ReadLine();
                                                    Console.WriteLine();

                                                    Console.Write("Creat password: ");
                                                    var employerPassword = Console.ReadLine();
                                                    Console.WriteLine();

                                                    Employer newEmpl = new Employer(employerUsername, employerPassword, employerName, employerSurname, employerAge, employerCity, employerPhone);
                                                    employers.Add(newEmpl);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("Employer added successfully!!");
                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    Thread.Sleep(1800);
                                                    break;
                                                case 2:
                                                    Console.Clear();
                                                    Begin();
                                                    break;
                                            }
                                        }
                                    }
                                }
                        }
                    }                   
                }
            }
        }
    }
}
