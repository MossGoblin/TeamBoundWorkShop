using System;
using System.Collections.Generic;

namespace Teamers
{
    class Program
    {
        static void Main(string[] args)
        {
            bool checkRes = true;
            Console.WriteLine("START");

            // Init Factory
            Factory factory = new Factory();
            IDMint idMint = new IDMint();

            // Init Producers
            AgentProducer agentProducer = new AgentProducer(idMint);
            factory.RegisterProducer("Agents", agentProducer);
            
            // Create a couple of products
            Agent prd01 = (Agent)factory.GetProduct("Agents", "agent01");
            Agent prd02 = (Agent)factory.GetProduct("Agents", "agent02");

            // Delete a product
            checkRes = factory.RemoveProduct("Agents", "agent03");
            checkRes = factory.RemoveProduct("Agents", "agent02");

            // Create a couple of products
            Agent prd03 = (Agent)factory.GetProduct("Agents", "agent03");
            Agent prd04 = (Agent)factory.GetProduct("Agents", "agent04");

        }
    }
}
