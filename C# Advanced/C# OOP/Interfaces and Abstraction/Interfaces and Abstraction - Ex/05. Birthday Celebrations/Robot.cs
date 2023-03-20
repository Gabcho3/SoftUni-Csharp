using PersonInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            Name = model;
            Id = id;
        }

        public string Name { get; }
        public string Id { get; }
    }
}
