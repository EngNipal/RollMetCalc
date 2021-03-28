using System;

namespace RollMetCalc
{
    internal class Sheet : Part
    {
        public float Width { get; set; }
        public float Thickness { get; set; }
        public float Density { get; set; } // Плотность в г/(см^3)
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="thickness"></param>
        /// <param name="density"></param>
        /// <param name="mass"></param>
        /// <param name="count"></param>
        /// <param name="name"></param>
        /// <param name="material"></param>
        /// <param name="owner"></param>
        public Sheet(string id, float length, float width, float thickness, float density, float mass, uint count, string name, string material, Assembly owner)
            : base(id, length, mass, count, name, material, "Лист", owner)
        {
            Width = width;
            Thickness = thickness;
            Density = density;
        }
        /// <summary>
        /// Листы сравниваются по толщине, затем по длине, затем по ширине.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object obj)
        {
            if (obj is Sheet tmp)
            {
                if (Thickness > tmp.Thickness)
                {
                    return -1;
                }
                else if (Thickness == tmp.Thickness)
                {
                    if (Length > tmp.Length)
                    {
                        return -1;
                    }
                    else if (Length == tmp.Length)
                    {
                        return Width > tmp.Width ? -1 : Width == tmp.Width ? 0 : 1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                throw new Exception("Параметр должен быть типа Sheet");
            }
        }
    }
}
