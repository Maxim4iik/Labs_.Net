namespace ComputerStructure
{
    /// <summary>
    /// Пам'ять комп'ютера.
    /// </summary>
    public class Memory : IComponent
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
        /// Тип пам'яті.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Об'єм пам'яті.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Потужність.
        /// </summary>
        public double Power { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitMemory(this);
        }
    }
}
