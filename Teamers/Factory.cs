using System;
using System.Collections.Generic;
using System.Linq;

namespace Teamers
{

    public class Factory
    {
        // Collections
        public Dictionary<Agent, bool> storage { get; set; }
        private int largestID = 0;

        // constructor
        public Factory()
        {
            this.storage = new Dictionary<Agent, bool>();
            System.Console.WriteLine("Factory ON");
        }

        public override string ToString()
        {
            List<int> list = new List<int>();
            foreach (KeyValuePair<Agent, bool> agent in this.storage)
            {
                int id = agent.Key.ID;
                list.Add(id);
            }
            String listString = String.Join(", ", list);

            return $"{this.storage.Count} : {list}";
        }
        // implement singleton

        // Create new object - per type??
        // For now - only Agents
        private Agent createAgent(string name)
        {
            int objectID = generateID();
            Agent newAgent = new Agent(objectID, name);

            return newAgent;
        }

        // Extract object
        public Agent getAgent(string name)
        {
            foreach (KeyValuePair<Agent, bool> agent in this.storage)
            {
                if (!agent.Value)
                {
                    this.storage[agent.Key] = true;
                    Agent oldAgent = agent.Key;
                    oldAgent.Name = name;

                    return oldAgent;
                }
            }

            Agent newAgent = this.createAgent(name);
            this.storage.Add(newAgent, true);
            this.largestID = newAgent.ID;

            return newAgent;
        }

        // Register object

        public bool removeAgent(int id)
        {
            Agent agentToBoRemoved = this.storage.FirstOrDefault(a => a.Key.ID == id).Key;
            if (agentToBoRemoved != null)
            {
                this.storage.Remove(agentToBoRemoved);

                return true;
            }
            else
            {
                return false;
            }
        }

        // Deregister object

        private int generateID()
        {
            return largestID + 1;
        }

    }

}