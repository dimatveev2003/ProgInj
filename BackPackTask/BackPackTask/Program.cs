using System;
using System.Collections.Generic;
using System.Linq;

namespace BackPackTask
{
    public class Program
    {
        /// <summary>
        /// Размер рюкзака
        /// </summary>
        const double size = 100;

        /// <summary>
        /// Заполнить объектом
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="backpack"></param>
        /// <returns></returns>
        public static bool FillWithObject(List<BackpackObject> objects, Backpack backpack)
        {
            var remaining = backpack.Size - backpack.Fullness;
            var suitableObjects = objects.Where(o => o.Volume <= remaining).ToList();
            if (!(suitableObjects.Count > 0))
                return false;

            backpack.Objects.Add(suitableObjects.OrderByDescending(o => o.Cost).FirstOrDefault());

            return true;
        }

        /// <summary>
        /// Заполнить учитывая важность
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="backpack"></param>
        /// <returns></returns>
        public static bool FillWithObjectUseImportance(List<BackpackObject> objects, Backpack backpack)
        {
            var remaining = backpack.Size - backpack.Fullness;
            var suitableObjects = objects.Where(o => o.Volume <= remaining).ToList();
            if (!(suitableObjects.Count > 0))
                return false;

            backpack.Objects.Add(suitableObjects.OrderByDescending(o => o.Importance).FirstOrDefault());

            return true;
        }

        public static void Main(string[] args)
        {
            //Учитывать ли важность
            var isUseImportance = false;

            var backpack = Backpack.GetInstance(size);

            List<BackpackObject> backpackObjects = new List<BackpackObject>()
            {
                new BackpackObject { Volume = 10, Cost = 10 },
                new BackpackObject { Volume = 30, Cost = 33 },
                new BackpackObject { Volume = 50, Cost = 50 }
            };

            var isContinue = true;
            
            while (isContinue)
            {
                isContinue = isUseImportance ? FillWithObjectUseImportance(backpackObjects, backpack) : FillWithObject(backpackObjects, backpack) ;
            }

            Console.WriteLine($"Рюкзак заполнен {backpack.Objects.Count} объектами:");
            foreach (var obj in backpack.Objects)
            {
                Console.WriteLine(obj);
            }

            Console.ReadKey();
        }
    }
}
