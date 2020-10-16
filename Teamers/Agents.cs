using System;

namespace Teamers
{
    public class Agent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Agent(int objID, string name)
        {
            this.ID = objID;
            this.Name = name;
        }

        public int GetID()
        {
            return this.ID;
        }
    }
}