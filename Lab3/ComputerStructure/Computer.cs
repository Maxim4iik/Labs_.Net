/// <summary>
/// Розробити модель системи, що реалізує елементи структури комп'ютера (процесор, пам'ять, відеокарта тощо).
/// Реалізувати механізм додаткових операцій над структурою комп'ютера без зміни її елементів.
/// В якості ілюстрації такого механізму розробити операцію визначення потужності, що потребляє комп'ютер.
/// </summary>
namespace ComputerStructure
{
    /// <summary>
    /// Комп'ютер.
    /// </summary>
    class Computer
    {
        /// <summary>
        /// Пам'ять комп'ютера.
        /// </summary>
        public Memory Memory { get; set; }

        /// <summary>
        /// Процесор комп'ютера.
        /// </summary>
        public Processor Processor { get; set; }

        /// <summary>
        /// Відеокарта комп'ютера.
        /// </summary>
        public Graphics Graphics { get; set; }

        /// <summary>
        /// Приймає відвідувача для всіх компонентів комп'ютера.
        /// </summary>
        /// <param name="visitor">Відвідувач.</param>
        /// <returns>Відвідувача.</returns>
        public IVisitor Accept(IVisitor visitor)
        {
            Memory.Accept(visitor);
            Processor.Accept(visitor);
            Graphics.Accept(visitor);

            return visitor;
        }
    }
}
