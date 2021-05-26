namespace ComputerStructure
{
    /// <summary>
    /// Процесор комп'ютера.
    /// </summary>
    public class Processor : IComponent
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
        /// Потужність.
        /// </summary>
        public double Power { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitProcessor(this);
        }
    }
}
