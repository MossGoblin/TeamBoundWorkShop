using System;
using System.Collections.Generic;

namespace Teamers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Factory factory = new Factory();

            List<string> agentList = new List<string>() {"agent One", "agent Two", "asdasd", "123qweasdzsc", "something", "something else"};

            foreach (string agentName in agentList)
            {
                Agent newAgent = factory.getAgent(agentName);
                System.Console.WriteLine($"ID: {newAgent.ID} // Name {newAgent.Name}");
            }
            System.Console.WriteLine(factory.ToString());

            for (int id = 0; id < 7; id++)
            {
                if (id % 2 ==0)
                {
                    factory.removeAgent(id);
                }
            }
            System.Console.WriteLine(factory.ToString());
        }
    } 
}
