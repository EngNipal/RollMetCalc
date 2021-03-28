using System;
using System.Collections.Generic;

namespace RollMetCalc
{
    public class Part : IComparable
    {
        public Assembly Owner { get; set; }
        public string ID { get; set; } // Уникальный идентификатор.
        public float Length { get; set; } // Длина.
        public float Mass { get; set; } // Масса.
        public uint Count { get; set; } // Количество.
        public string Name { get; set; } // Наименование.
        public string Material { get; set; } // Материал.
        public string FlatType { get; set; } // Тип проката.
        public static Dictionary<int, Part> Base = new Dictionary<int, Part>();
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="length"></param>
        /// <param name="mass"></param>
        /// <param name="count"></param>
        /// <param name="name"></param>
        /// <param name="material"></param>
        /// <param name="flattype"></param>
        /// <param name="owner"></param>
        public Part(string id, float length, float mass, uint count, string name, string material, string flattype, Assembly owner)
        {
            ID = id;
            Length = length;
            Mass = mass;
            Count = count;
            Name = name;
            Material = material;
            FlatType = flattype;
            Owner = owner;
        }
        /// <summary>
        /// Детали сравниваются по их реальному типу.
        /// В пределах одного типа - по параметрам.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj is Part part)
            {
                if (this is Armature armature)
                {
                    return !(part is Armature) ? -1 : armature.Compare(part as Armature);
                }
                else if (this is Sheet leaf)
                {
                    if (part is Armature)
                    {
                        return 1;
                    }
                    else
                    {
                        return part is Sheet ? leaf.Compare(part as Sheet) : -1;
                    }
                }
                else if (this is Pipe pipe)
                {
                    if (part is Corner)
                    {
                        return -1;
                    }
                    else
                    {
                        return part is Pipe ? pipe.Compare(part as Pipe) : 1;
                    }
                }
                else
                {
                    return part is Corner ? ((Corner)this).Compare(part as Corner) : 1;
                }
            }
            else
            {
                throw new Exception("Параметр должен быть типа Part");
            }
        }
    }
}
