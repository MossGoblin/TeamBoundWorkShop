using System.Collections.Generic;

namespace Teamers
{
    public class IDMint : ILogger
    {
        private HashSet<int> idList;
        int maxID = 0;
        public IDMint()
        {
            idList = new HashSet<int>();

            SoundOff();
        }

        public int GetID()
        {
            this.maxID += 1;
            idList.Add(maxID);
            return maxID;
        }

        public bool RetireID(int id)
        {
            if (idList.Contains(id))
            {
                idList.Remove(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SoundOff()
        {
            System.Console.WriteLine("Mint ON");
        }
    }

    public class AgentProducer : IProductionUnit, ILogger
    {
        private IDMint idMint;
        public AgentProducer(IDMint idMint)
        {
            this.idMint = idMint;
            SoundOff();
        }
        public IProduct Create(string name)
        {
            int agentID = idMint.GetID();
            IProduct newAgent = new Agent(agentID, name) as IProduct;
            return newAgent;
        }

        public void SoundOff()
        {
            System.Console.WriteLine("Agent Producer ON");
        }
    }
}