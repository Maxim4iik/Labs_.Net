namespace ComputerStructure
{
    /// <summary>
    /// Загальний інтерфейс для всіх відвідувачів.
    /// </summary>
    public interface IVisitor
    {
        /// <summary>
        /// Відвідує процесор.
        /// </summary>
        /// <param name="processor">Процесор для відвідування.</param>
        public void VisitProcessor(Processor processor);

        /// <summary>
        /// Відвідує відеокарту.
        /// </summary>
        /// <param name="graphics">Відеокарта для відвідування.</param>
        public void VisitGraphics(Graphics graphics);

        /// <summary>
        /// Відвідує пам'ять.
        /// </summary>
        /// <param name="memory">Пам'ять для відвідування.</param>
        public void VisitMemory(Memory memory);
    }
}
