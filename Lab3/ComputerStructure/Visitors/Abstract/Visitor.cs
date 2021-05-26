namespace ComputerStructure
{
    /// <summary>
    /// Класс, що репрезентує відвідувача, що зберігає результат виконаних відвідувань.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Visitor<T> : IVisitor
    {
        /// <summary>
        /// Відвідує процесор.
        /// </summary>
        /// <param name="processor">Процесор для відвідування.</param>
        public abstract void VisitGraphics(Graphics graphics);

        /// <summary>
        /// Відвідує відеокарту.
        /// </summary>
        /// <param name="graphics">Відеокарта для відвідування.</param>
        public abstract void VisitMemory(Memory memory);

        /// <summary>
        /// Відвідує пам'ять.
        /// </summary>
        /// <param name="memory">Пам'ять для відвідування.</param>
        public abstract void VisitProcessor(Processor processor);

        /// <summary>
        /// Результат відвідування.
        /// </summary>
        public abstract T Result { get; set; }
    }
}
