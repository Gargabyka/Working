using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Working
{
    public class Settings
    {
        public List<Employee> employees = new List<Employee>();
        public List<Intern> interns = new List<Intern>();
        
        // создание нового стажера
        public void NewIntern(List<Intern> interns)
        {
            Console.WriteLine("New ID? ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var intern in interns)
            {
                if (intern.ID == id)
                {
                    Console.Clear();
                    throw new Exception("This ID already exists");
                }
            }
            Console.WriteLine("Name of new intern?: ");
            var name = Console.ReadLine();
            Console.WriteLine("Education Level? Bachelor, Specialist or Master? ");
            var education = Console.ReadLine();
            Console.WriteLine("Do you want to hire that person? write true or false");
            bool hire = Convert.ToBoolean(Console.ReadLine());

            interns.Add(new Intern(id, name, education, hire));
            Console.WriteLine("Done! Press any key to continue.");
            Console.ReadKey();
        }
        
        // создание нового работника
        public void NewEmployee(List<Employee> employees)
        {
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
            Save(employees);
        }
        
        //показать список всех (работники + стажеры)
        public void ShowEmployees(List<Employee> employees, List<Intern> interns)
        {
            ConsoleColor color1 = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkCyan; 
            Console.WriteLine("Employees list");
            Console.ForegroundColor = color1;
            
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"\nID: {employee.ID}");
                Console.WriteLine($"Name: {employee.Name}");
                Console.WriteLine($"Salary: {employee.Salary}");
                Console.WriteLine($"Experience: {employee.Experience}");
                Console.WriteLine($"HireDate: {employee.HireDate}");
            }

            ConsoleColor color2 = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkCyan; 
            Console.WriteLine("\nInterns list");
            Console.ForegroundColor = color2;
            
            foreach (Intern intern in interns)
            {
                Console.WriteLine($"\nID: {intern.ID}");
                Console.WriteLine($"Name: {intern.Name}");
                Console.WriteLine($"Education Level: {intern.EducationLvl}");
                Console.WriteLine($"Hiring: {intern.Hire}");

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        // сохранить в файл
        void Save(List<Employee> employees)
            {
                var serializer = new BinaryFormatter();
                using (FileStream fs = new FileStream("employees.dat", FileMode.OpenOrCreate))
                {
                    serializer.Serialize(fs, employees);
                    Console.WriteLine("Data has been save to file");
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        
        // повышение сотрудников
        public void Promotion(List<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                if (employee.Salary < 4000 && employee.Experience >= 2)
                {
                    Console.WriteLine(employee.Name + " needs to be promoted. " + "New salary: " + employee.Salary * 1.5);
                    employee.Fired();
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        
        // кого взять на работу
        public void Hiring(List<Intern> interns)
        {
            foreach (Intern intern in interns)
            {
                if (intern.Hire)
                {
                    Console.WriteLine(intern.Name + " needs to be hired.");
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }

}