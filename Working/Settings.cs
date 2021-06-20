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

        public void CreateUser(int number)
        {
            var employee = new Employee();
            var intern = new Intern();

            switch (number)
            {
                case 1:
                    employee.NewEmployee(employees);
                    break;
                case 2:
                    intern.NewIntern(interns);
                    break;
                default:
                    Console.WriteLine("Incorrect command line");
                    break;
            }
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
        public void Save(List<Employee> employees)
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