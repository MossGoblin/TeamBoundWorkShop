using System;
using System.Collections.Generic;
using System.Linq;

namespace Teamers
{

    public class Factory : ILogger
    {
        // Producers
        public Dictionary<string, IProductionUnit> producers { get; set; }
        // Collections
        public Dictionary<string, Dictionary<IProduct, bool>> storage { get; set; }
        public Factory()
        {
            this.producers = new Dictionary<string, IProductionUnit>();
            this.storage = new Dictionary<string, Dictionary<IProduct, bool>>();
            SoundOff();
        }
        public bool RegisterProducer(string name, IProductionUnit prod)
        {
            if (producers.ContainsKey(name))
            {
                return false;
            }
            else
            {
                producers.Add(name, prod);
                Dictionary<IProduct, bool> newProducerStorage = new Dictionary<IProduct, bool>();
                storage.Add(name, newProducerStorage);
                return true;
            }
        }

        public IProduct GetProduct(string producerName, string productName)
        {
            // Check if such producer is registered
            if (!this.producers.ContainsKey(producerName))
            return null;

            // Check if there is an available product
            Dictionary<IProduct, bool> productDict = storage[producerName];
            IProduct product = productDict.FirstOrDefault(x => x.Value == false).Key;
            if (product != null)
            {
                product.SetName(productName);
                storage[producerName][product] = true;
                return product;
            }

            // There is not an available product of this type - create one
            IProductionUnit producer = producers[producerName];
            IProduct newProduct = producer.Create(productName);
            this.storage[producerName].Add(newProduct, true);
            return newProduct;
        }

        public bool RemoveProduct(string productType, string productName)
        {
            // Check if such producer is registered
            if (!this.producers.ContainsKey(productType))
            return false;

            // Check if there is such a product and if it is active
            Dictionary<IProduct, bool> producer = this.storage.FirstOrDefault(x => x.Key == productType).Value;
            IProduct product = producer.FirstOrDefault(x => x.Key.GetName() == productName).Key;
            if ((product == null) || (producer[product] == false))
            {
                return false;
            }


            // There is such a product - deactivate
            producer[product] = false;
            return true;
        }
    
        public void SoundOff()
        {
            System.Console.WriteLine("Factory ON");
        }
    }
}