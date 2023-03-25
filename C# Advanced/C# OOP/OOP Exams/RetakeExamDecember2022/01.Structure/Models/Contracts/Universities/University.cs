﻿using System;
using System.Collections.Generic;

namespace UniversityCompetition.Models.Contracts.Universities
{
    public class University : IUniversity
    {
        private string name;
        private string category;
        private List<string> categories = new List<string>() { "Technical", "Economical", "Humanity" };
        private int capacity;

        public University(int id, string name, string category, int capacity, IReadOnlyCollection<int> requiredSubjects)
        {
            Id = id;
            Name = name;
            Category = category;
            Capacity = capacity;
            RequiredSubjects = requiredSubjects;
        }

        public int Id { get; }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public string Category
        {
            get { return category; }
            private set
            {
                if (!categories.Contains(value))
                {
                    throw new ArgumentException("University category {0} is not allowed in the application!", value);
                }
                category = value;
            }
        }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("University capacity cannot be a negative value!");
                }
                capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects { get; }
    }
}
