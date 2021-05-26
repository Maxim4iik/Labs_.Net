namespace ComputerStructure
{
    /// <summary>
    /// Відвідувач для отримання загальної потужності відвіданих компонентів.
    /// </summary>
    class GetPowerVisitor : Visitor<double>
    {
        /// <summary>
        /// Результат всіх відвідувань.
        /// </summary>
        public override double Result { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        public GetPowerVisitor()
        {
            Result = 0;
        }

        /// <summary>
        /// Відвідує відеокарту.
        /// </summary>
        /// <param name="graphics">Відеокарта для відвідування.</param>
        public override void VisitGraphics(Graphics graphics)
        {
            Result += graphics.Power;
        }

        /// <summary>
        /// Відвідує пам'ять.
        /// </summary>
        /// <param name="memory">пам'ять для відвідування.</param>
        public override void VisitMemory(Memory memory)
        {
            Result += memory.Power;
        }

        /// <summary>
        /// Відвідує процесор.
        /// </summary>
        /// <param name="processor">Процесор для відвідування.</param>
        public override void VisitProcessor(Processor processor)
        {
            Result += processor.Power;
        }
    }
}
