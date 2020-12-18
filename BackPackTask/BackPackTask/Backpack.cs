using System.Collections.Generic;
using System.Linq;

namespace BackPackTask
{
    /// <summary>
    /// Рюкзак
    /// </summary>
    public class Backpack
    {
        /// <summary>
        /// Инстанс синглтона
        /// </summary>
        private static Backpack instance;

        /// <summary>
        /// Размер рюкзака
        /// </summary>
        public double Size { get; private set; }

        /// <summary>
        /// Заполненность
        /// </summary>
        public double Fullness { get { return Objects.Sum(o => o.Volume); } }

        /// <summary>
        /// Полная ценность объектов
        /// </summary>
        public double FullCost { get { return Objects.Sum(o => o.Cost); } }

        /// <summary>
        /// Объекты в рюкзаке
        /// </summary>
        public List<BackpackObject> Objects { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="size">Размер рюкзака</param>
        private Backpack(double size)
        {
            Objects = new List<BackpackObject>();
            Size = size;
        }

        /// <summary>
        /// Получить инстанс рюкзака
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Backpack GetInstance(double size)
        {
            if (instance == null)
                instance = new Backpack(size);
            return instance;
        }
    }
}
