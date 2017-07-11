// #1 Classe | Class

using System;

namespace HumanResource
{
    public class Person
    {
        public Person()
        {
            PersonId = 8;
            Name = "John Snow";
            BirthDate = new DateTime(1952, 11, 25);
            Steps = 20;
        }

        public int PersonId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Steps { get; set; }

        public void Walk()
        {
            Steps++;
        }

        public void Walk(int steps)
        {
            Steps+=steps;
        }
    }
}
