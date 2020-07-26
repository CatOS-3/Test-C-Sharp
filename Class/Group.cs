using System;

namespace Test
{
    public class Group
    {
        public int ID { get; }

        public String Name { get; }

        public Group(int id, String n)
        {
            ID = id;
            Name = n;
        }
    }
}