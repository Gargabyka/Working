using System;
   

namespace Working
{
    [Serializable]
    public class Employee : Person, IEmployee
    {
        public int Salary { get; set; }
        public int Experience { get; set; }
        public DateTime HireDate { get; set; }

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
    }
}