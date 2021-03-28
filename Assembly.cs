using System.Collections.Generic;

namespace RollMetCalc
{
    public class Assembly
    {
        public Order Owner { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public uint Count { get; set; }
        public List<Part> PartList { get; set; }
        public static Dictionary<int, Assembly> Base = new Dictionary<int, Assembly>();
        public Assembly(string id, string name, uint count, Order owner)
        {
            ID = id;
            Name = name;
            Count = count;
            Owner = owner;
            PartList = new List<Part>();
        }
    }
}
