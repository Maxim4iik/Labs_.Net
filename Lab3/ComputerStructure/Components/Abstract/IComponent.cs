namespace ComputerStructure
{
    /// <summary>
    /// Загальний інтерфейс для всіх компонентів комп'ютера.
    /// </summary>
    interface IComponent
    {
        /// <summary>
        /// Приймає відвідувача.
        /// </summary>
        /// <param name="visitor">Відвідувач.</param>
        public abstract void Accept(IVisitor visitor);
    }
}
