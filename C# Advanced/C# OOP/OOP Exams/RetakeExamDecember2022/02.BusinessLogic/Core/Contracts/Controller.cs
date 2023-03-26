using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Models.Contracts.Students;
using UniversityCompetition.Models.Contracts.Subjects;
using UniversityCompetition.Models.Contracts.Universities;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Core.Contracts
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;
        private List<string> subjectTypes = new List<string>() { "TechnicalSubject", "EconomicalSubject", "HumanitySubject" };

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            string fullName = string.Join(" ", firstName, lastName);
            if (students.FindByName(fullName) != null)
            {
                return $"{fullName} is already added in the repository.";
            }

            Student student = new Student(students.Models.Count + 1, firstName, lastName);
            students.AddModel(student);
            return $"Student {firstName} {lastName} is added to the {students.GetType().Name}!";
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (!subjectTypes.Contains(subjectType))
            {
                return $"Subject type {subjectType} is not available in the application!";
            }

            if (subjects.FindByName(subjectName) != null)
            {
                return $"{subjectName} is already added in the repository.";
            }

            switch (subjectType)
            {
                case "TechnicalSubject": subjects.AddModel(new TechnicalSubject(subjects.Models.Count + 1, subjectName)); break;
                case "EconomicalSubject": subjects.AddModel(new EconomicalSubject(subjects.Models.Count + 1, subjectName)); break;
                case "HumanitySubject": subjects.AddModel(new HumanitySubject(subjects.Models.Count + 1, subjectName)); break;
            }
            return $"{subjectType} {subjectName} is created and added to the {subjects.GetType().Name}!";
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.FindByName(universityName) != null)
            {
                return $"{universityName} is already added in the repository.";
            }

            List<int> subjectsId = new List<int>();
            foreach (var subjectName in requiredSubjects)
            {
                var subject = subjects.FindByName(subjectName);
                subjectsId.Add(subject.Id);
            }

            University university = new University(universities.Models.Count + 1, universityName, category, capacity, subjectsId);
            universities.AddModel(university);
            return $"{universityName} university is created and added to the {universities.GetType().Name}!";
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string studentFirstName = studentName.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
            string studentLastName = studentName.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];

            if (students.FindByName(studentName) == null)
            {
                return $"{studentFirstName} {studentLastName} is not registered in the application!";
            }

            if (universities.FindByName(universityName) == null)
            {
                return $"{universityName} is not registered in the application!";
            }

            IStudent student = students.FindByName(studentName);
            University university = universities.FindByName(universityName) as University;
            
            foreach(var studentCoveredExam in student.CoveredExams)
            {
                bool found = false;
                foreach (var universityRequiredSubject in university.RequiredSubjects)
                {
                    if (studentCoveredExam == universityRequiredSubject)
                        found = true;
                }

                if(found == false)
                    return $"{studentName} has not covered all the required exams for {universityName} university!";
            }

            if(student.University == university)
            {
                return $"{studentFirstName} {studentLastName} has already joined {universityName}.";
            }

            student.JoinUniversity(university);
            university.Capacity--;
            return $"{studentFirstName} {studentLastName} joined {universityName} university!";
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (students.FindById(studentId) == null)
            {
                return "Invalid student ID!";
            }

            if (subjects.FindById(subjectId) == null)
            {
                return "Invalid subject ID!";
            }

            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);
            if (student.CoveredExams.Any(e => e == subjectId))
            {
                return $"{student.FirstName} {student.LastName} has already covered exam of {subject.Name}.";
            }

            student.CoverExam(subject);
            return $"{student.FirstName} {student.LastName} covered {subject.Name} exam!";
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);
            int studentsAdmitted = students.Models.Where(s => s.University == university).Count();

            return $"*** {university.Name} ***" + Environment.NewLine +
                $"Profile: {university.Category}" + Environment.NewLine +
                $"Students admitted: {studentsAdmitted}" + Environment.NewLine +
                $"University vacancy: {university.Capacity}";
        }
    }
}
