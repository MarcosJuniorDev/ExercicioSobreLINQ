using ExercicioLINQ.Entities;
using System.Globalization;

namespace ExercicioLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter the full file path: ");
            string path = Console.ReadLine();

            List<Employee> list = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                    list.Add(new Employee(name, email, salary));

                }
            }

            Console.Write("Enter the salary: ");
            double valueSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine($"Email of people whose salary is more than {valueSalary.ToString("F2", CultureInfo.InvariantCulture)}:");

            var emailFuncs = list.Where(p => p.Salary > valueSalary).OrderBy(p => p.Email).Select(p => p.Email);

            var somaSalario = list.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);

            foreach (string email in emailFuncs)
            {
                Console.WriteLine(email);
            }

            Console.WriteLine($"Sum of salary of people whose name starts whith 'M': {somaSalario.ToString("F2", CultureInfo.InvariantCulture)}");




        }
    }
}