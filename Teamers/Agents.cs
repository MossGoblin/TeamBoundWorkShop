using System;

namespace Teamers
{
    public class Agent : IProduct
    {
        private int ID { get; set; }
        private string Name { get; set; }
        public Agent(int objID, string name)
        {
            this.ID = objID;
            this.Name = name;
        }

        public int GetID()
        {
            return this.ID;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public string GetName()
        {
            return this.Name;
        }
    }

    public class Team : IProduct
    {
        private int ID { get; set; }
        private string Name { get; set; }
        public Team(int objID, string name)
        {
            this.ID = objID;
            this.Name = name;
        }

        public int GetID()
        {
            return this.ID;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public string GetName()
        {
            return this.Name;
        }
    }
}