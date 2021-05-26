namespace ComputerStructure
{
    /// <summary>
    /// Відеокарта комп'ютера
    /// </summary>
    public class Graphics : IComponent
    {
        /// <summary>
        /// Виробник.
        /// </summary>
        public string Producer { get; set; }

        /// <summary>
        /// Модель.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Об'єм відеопам'яті.
        /// </summary>
        public string MemoryCopacity { get; set; }

        /// <summary>
        /// Потужність
        /// </summary>
        public double Power { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitGraphics(this);
        }
    }
}
