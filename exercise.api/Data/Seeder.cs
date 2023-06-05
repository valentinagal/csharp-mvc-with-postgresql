﻿using exercise.api.Context;
using exercise.api.Models;

namespace exercise.api.Data
{
    public static class Seeder
    {
        private static List<string> Names = new List<string>()
        {
            "Rubeus",
            "Gellert",
            "Firenze",
            "Barty",
            "Minerva",
            "Molly",
            "Cornelius",
            "Xenophilius",
            "Percy",
            "Gregory"
        };
        private static List<string> FirstWord = new List<string>()
        {
            "Advisor",
            "Head of",
            "Secretary",
            "Analyst",
            "Officer"
        };
        private static List<string> SecondWord = new List<string>()
        {
            "Quill Control",
            "Hall of Prophecy",
            "Law Enforcement",
            "Elf Legislation",
            "Rune Translator"
        };
        private static List<string> Department = new List<string>()
        {
            "Accidental Magic Reversal Squad",
            "Department of Mysteries",
            "Portkey Office",
            "Misuse of Muggle Artefacts Office",
            "Auror Office"
        };
        private static List<string> SalaryGrade = new List<string>()
        {
            "052M",
            "055Q",
            "047A",
            "059C",
            "064G"
        };


        public static void Seed(this WebApplication app)
        {
            using (var db = new EmployeeContext())
            {
                Random employeeRandom = new Random();
                var employees = new List<Employee>();

                if (!db.Employees.Any())
                {
                    for (int x = 1; x < 80; x++)
                    {
                        Employee employee = new Employee();
                        employee.Id = x;
                        employee.Name = Names[employeeRandom.Next(Names.Count)];
                        employee.JobName = $"{FirstWord[employeeRandom.Next(FirstWord.Count)]} {SecondWord[employeeRandom.Next(SecondWord.Count)]}";
                        employee.Department = Department[employeeRandom.Next(Department.Count)];
                        employee.SalaryGrade =SalaryGrade[employeeRandom.Next(SalaryGrade.Count)];

                        employees.Add(employee);

                    }
                    db.Employees.AddRange(employees);
                }
                db.SaveChanges();
            }
        }
    }
}
