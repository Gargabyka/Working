using System;
using System.Collections.Generic;


namespace Working
{
    [Serializable]
    public class Employee : Person, IEmployee
    {
        public int Salary { get; set; }
        public int Experience { get; set; }
        public DateTime HireDate { get; set; }

        public Employee()
        {
            
        }

        public Employee(int id, string name, int salary, int experience, DateTime hireDate) : base(id, name)
        {
            Salary = salary;
            Experience = experience;
            HireDate = hireDate;
        }

        public void Fired()
        {
            Random random = new Random();
            int value = random.Next(1, 100);
            Console.WriteLine($"Risk of firing: {value} %");
        }
        
        /// <summary>
        /// Создание стажера
        /// </summary>
        public void NewEmployee(List<Employee> employees)
        {
            var settings = new Settings();
            Console.WriteLine("New ID? ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var employee in employees)
            {
                if (employee.ID == id)
                {
                    Console.Clear();
                    throw new Exception("This ID already exists");
                }
            }
            Console.WriteLine("Name of new employee?: ");
            string name = Console.ReadLine();
            Console.WriteLine("Salary?");
            int salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Experience?");
            int experience = Convert.ToInt32(Console.ReadLine());
            DateTime hiredate;
            while (true)
            {
                Console.Write("Hire Date? (yyyy.mm.dd.):");
                if (DateTime.TryParse(Console.ReadLine(), out hiredate)) break;
                else
                {
                    Console.WriteLine("Error format");
                }
            }
            employees.Add(new Employee(id, name, salary, experience, hiredate));
            Console.WriteLine("Done! Press any key to continue.");
            Console.ReadKey();
            settings.Save(employees);
        }
    }
}