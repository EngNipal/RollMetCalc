using System.Collections.Generic;

namespace RollMetCalc
{
    public class Order
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Customer { get; set; }
        public List<Assembly> AsmList { get; set; }
        public static Dictionary<int, Order> Base = new Dictionary<int, Order>();
        public Order(string id, string name, string customer)
        {
            ID = id;
            Name = name;
            Customer = customer;
            AsmList = new List<Assembly>();
        }
    }
}
