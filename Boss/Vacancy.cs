using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacancy;

internal class Vacancyc
{
    public string Specification { get; set; }
    public double Salary { get; set; }
    public int Experience { get; set; }
    public int id { get; set; }
    static public int Id { get; set; } = 0;

    public Vacancyc() { }
    public Vacancyc(string specification, double salary, int experience)
    {
        id = ++Id;
        Specification = specification;
        Salary = salary;
        Experience = experience;
    }

    public void ShowVacancy()
    {
        Console.WriteLine();
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Specification: {Specification}");
        Console.WriteLine($"Salary: {Salary} $");
        Console.WriteLine($"Experience year: {Experience}\n");
    }
}
