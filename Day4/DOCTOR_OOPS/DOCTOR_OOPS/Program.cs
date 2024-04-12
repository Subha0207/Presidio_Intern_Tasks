using DoctorClass.Models;
using System;

namespace DoctorClass.Models
{
    class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Qualification { get; set; }
        public string Specialization { get; set; }

        public Doctor(int id) => Id = id;

        public void PrintDetails()
        {
            Console.WriteLine($"Doctor Id\t:\t {Id}");
            Console.WriteLine($"Doctor Name\t:\t {Name}");
            Console.WriteLine($"Doctor Age\t:\t {Age}");
            Console.WriteLine($"Doctor Experience\t:\t {Experience}");
            Console.WriteLine($"Doctor Qualification\t:\t {Qualification}");
            Console.WriteLine($"Doctor Specialization\t:\t {Specialization}");
        }
    }
}

namespace DoctorClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pro = new Program();
            Doctor[] docs = new Doctor[3];

            for (int i = 0; i < docs.Length; i++)
            {
                docs[i] = pro.CreateDoctorDetails(101 + i);
                Console.WriteLine("\n\n\n");
            }

            Console.WriteLine("\n\n\nDoctor Details:");
            for (int i = 0; i < docs.Length; i++)
            {
                docs[i].PrintDetails();
                Console.WriteLine("\n");
            }

            pro.FindDocBySpecialization(docs);
        }

        void FindDocBySpecialization(Doctor[] docs)
        {
            Console.WriteLine("\n\n\nFind Doctor by Specialization");
            Console.WriteLine("Enter the Specialization to proceed further:");
            string spcl = GetStringInput("Specialization");
            bool flag = false;
            for (int i = 0; i < docs.Length; i++)
            {
                if (docs[i].Specialization == spcl)
                {
                    flag = true;
                    docs[i].PrintDetails();
                }
            }
            if (!flag)
            {
                Console.WriteLine("Sorry we couldn't find any doctors!");
            }
        }

        string GetStringInput(string FieldName)
        {
            string? inp;
            do
            {
                inp = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inp))
                    Console.Write($"Invalid input, Please Enter {FieldName} again:\n");

            } while (string.IsNullOrWhiteSpace(inp));
            return inp;
        }

        int GetIntInput()
        {
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }
            return num;
        }

        Doctor CreateDoctorDetails(int id)
        {
            Console.WriteLine($"Doctor {id - 100} Detail\n");

            Doctor doc = new Doctor(id);

            Console.WriteLine("Enter Doctor Name:");
            doc.Name = GetStringInput("Name");

            Console.WriteLine("Enter Doctor Age:");
            doc.Age = GetIntInput();

            Console.WriteLine("Enter Doctor Experience:");
            doc.Experience = GetIntInput();

            Console.WriteLine("Enter Doctor Qualification:");
            doc.Qualification = GetStringInput("Qualification");

            Console.WriteLine("Enter Doctor Specialization:");
            doc.Specialization = GetStringInput("Specialization");

            return doc;
        }
    }
}
