using System;

namespace RollMetCalc
{
    internal class Pipe : Part
    {
        public float Diameter { get; set; }
        public float LinearDensity { get; set; } // в кг/м.
        public float Thickness { get; set; }
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="length"></param>
        /// <param name="diameter"></param>
        /// <param name="thickness"></param>
        /// <param name="linearDensity"></param>
        /// <param name="mass"></param>
        /// <param name="count"></param>
        /// <param name="name"></param>
        /// <param name="material"></param>
        /// <param name="owner"></param>
        public Pipe(string id, float length, float diameter, float thickness, float linearDensity, float mass, uint count, string name, string material, Assembly owner)
            : base(id, length, mass, count, name, material, "Труба", owner)
        {
            if (diameter / 2 > thickness)                                       // Если толщина не больше радиуса.
            {
                Diameter = diameter;
                LinearDensity = linearDensity;
                Thickness = thickness;
            }
            else
            {
                throw new Exception("Несогласованные толщина и диаметр");       // TODO: Доработать исключение (2021-02-22)
            }
        }
        /// <summary>
        /// Трубы сравниваются по диаметру.
        /// При равенстве диаметров - по толщине стенки.
        /// При равенстве толщин - по длине.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object obj)
        {
            if (obj is Pipe tmp)
            {
                if (Diameter > tmp.Diameter)
                {
                    return -1;
                }
                else if (Diameter == tmp.Diameter)
                {
                    return Thickness > tmp.Thickness ? -1 : Thickness < tmp.Thickness ? 1 : (Length > tmp.Length ? -1 : Length < tmp.Length ? 1 : 0);
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                throw new Exception("Параметр должен быть типа Pipe");
            }
        }
    }
}
