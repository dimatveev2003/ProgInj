namespace BackPackTask
{
    /// <summary>
    /// Объект для рюкзака
    /// </summary>
    public class BackpackObject
    {
        /// <summary>
        /// Объем
        /// </summary>
        public double Volume { get; set; }

        /// <summary>
        /// Ценность
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Коэффициент важности объекта на единицу объема
        /// </summary>
        public double Importance { get { return Cost / Volume; } }

        public override string ToString()
        {
            return $"Объем: {Volume}, Ценность: {Cost}";
        }
    }
}
