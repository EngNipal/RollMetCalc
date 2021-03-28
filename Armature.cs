using System;

namespace RollMetCalc
{
    internal class Armature : Part
    {
        public float Diameter { get; set; }
        public float LinearDensity { get; set; } // в кг/м.
        public Armature(string id, float length, float diameter, float linearDensity, float mass, uint count, string name, string material, Assembly owner)
            : base(id, length, mass, count, name, material, "Арматура", owner)
        {
            Diameter = diameter;
            LinearDensity = linearDensity;
        }
        /// <summary>
        /// Арматура сравнивается по диаметру, затем по длине.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Compare(object obj)
        {
            if (obj is Armature tmp)
            {
                return Diameter > tmp.Diameter ? -1 : Diameter < tmp.Diameter ? 1 : (Length > tmp.Length ? -1 : Length < tmp.Length ? 1 : 0);
            }
            else
            {
                throw new Exception("Параметр должен быть типа Armature");
            }
        }
    }
}
