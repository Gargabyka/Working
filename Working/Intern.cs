using System;
using System.Collections.Generic;


namespace Working
{
    [Serializable]
    public class Intern : Person
    {
        public string EducationLvl { get; set; }
        public bool Hire { get; set; }

        public Intern()
        {
            
        }

        public Intern(int id, string name, string education, bool hire) : base(id, name)
        {
            EducationLvl = education;
            Hire = hire;
        }
        
        /// <summary>
        /// Создание стажера
        /// </summary>
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
    }
}