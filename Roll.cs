using System;
using System.Collections.Generic;

namespace RollMetCalc
{
    internal class Roll
    {
        public List<Part> PartTypes { get; set; }
        public List<float> Lengthes { get; set; }
        public List<float> Masses { get; set; }
        public List<uint> Counts { get; set; }
        public List<(int Count, double Percent)>[] StdLen { get; set; }
        public List<(int Count, double Percent)>[] StdSheet { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="n"></param>
        public Roll(int n)
        {
            StdLen = n >= 0 ? (new List<(int, double)>[n]) : throw new Exception("Количество элементов массива не может быть отрицательным");
            StdSheet = n >= 0 ? (new List<(int, double)>[n]) : throw new Exception("Количество элементов массива не может быть отрицательным");
            for (int i = 0; i < n; i++)
            {
                StdSheet[i] = new List<(int Count, double Percent)>();
                StdLen[i] = new List<(int Count, double Percent)>();
            }
            PartTypes = new List<Part>();
            Masses = new List<float>();
            Lengthes = new List<float>();
            Counts = new List<uint>();
        }
        /// <summary>
        /// Добавление нового типа детали.
        /// </summary>
        /// <param name="part">Образец детали</param>
        internal void AddNewPartType(Part part)
        {
            PartTypes.Add(part);
            Lengthes.Add(part.Length * part.Count * part.Owner.Count);
            Masses.Add(part.Mass * part.Count * part.Owner.Count);
            Counts.Add(part.Count * part.Owner.Count);
        }
        /// <summary>
        /// Уточнение параметров типа
        /// </summary>
        /// <param name="k"></param>
        /// <param name="part"></param>
        internal void Update_kType (int k, Part part)
        {
            Lengthes[k] += part.Length * part.Count * part.Owner.Count;
            Masses[k] += part.Mass * part.Count * part.Owner.Count;
            Counts[k] += part.Count * part.Owner.Count;
        }
    }
}
