using System;

namespace RollMetCalc
{
    internal class Corner : Part
    {
        public float LongShelf { get; set; }
        public float ShortShelf { get; set; }
        public float Thickness { get; set; }
        public float LinearDensity { get; set; } // в кг/м.
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="id"> Уникальный идентификатор </param>
        /// <param name="length"> Длина </param>
        /// <param name="longShelf"> Длина длинной полки </param>
        /// <param name="shortShelf"> Длина короткой полки </param>
        /// <param name="thickness"> Толщина металла </param>
        /// <param name="linearDensity"> Линейная плотность </param>
        /// <param name="mass"> Масса </param>
        /// <param name="count"> Количество в сборке </param>
        /// <param name="name"> Наименование </param>
        /// <param name="material"> Материал </param>
        /// <param name="owner"> Сборка, куда входит деталь </param>
        public Corner(string id, float length, float longShelf, float shortShelf, float thickness, float linearDensity, float mass, uint count, string name, string material, Assembly owner)
            : base(id, length, mass, count, name, material, "Уголок", owner)
        {
            LinearDensity = linearDensity;
            LongShelf = longShelf;
            ShortShelf = shortShelf;
            Thickness = thickness;
        }
        /// <summary>
        /// Уголки сравниваются по толщине,
        /// затем по длинной и короткой полкам,
        /// затем по длине.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object obj)
        {
            if (obj is Corner tmp)
            {
                if (Thickness > tmp.Thickness)
                {
                    return -1;
                }
                else if (Thickness == tmp.Thickness)
                {
                    if (LongShelf > tmp.LongShelf)
                    {
                        return -1;
                    }
                    else if (LongShelf == tmp.LongShelf)
                    {
                        return ShortShelf > tmp.ShortShelf ? -1 : ShortShelf < tmp.ShortShelf ? 1 : (Length > tmp.Length ? -1 : Length < tmp.Length ? 1 : 0);
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
                throw new Exception("Параметр должен быть типа Corner");
            }
        }
    }
}
