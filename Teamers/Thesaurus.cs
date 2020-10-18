using System;

namespace Teamers
{
    public interface IProduct
    {
        public int GetID();
        public void SetName(string name);
        public string GetName();
    }

    public interface IProductionUnit
    {
        public IProduct Create(string name);
    }

    public interface ILogger
    {
        public void SoundOff();
    }
}