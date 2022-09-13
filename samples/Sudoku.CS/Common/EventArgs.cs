namespace Sudoku.CS.Common
{
    using System;

    /// <summary>
    /// Generic type of event args.
    /// </summary>
    /// <typeparam name="T">Type of the argument.</typeparam>
    public class EventArgs<T> : EventArgs, IEventArgs<T> //where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventArgs&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public EventArgs(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (value is string && string.IsNullOrEmpty(value as string))
            {
                throw new ArgumentException("string value cannot be null or empty", "value");
            }

            this.Value = value;
        }

        /// <summary>
        /// Gets the value or this event argument.
        /// </summary>
        public T Value { get; private set; }
    }

    /// <summary>
    /// Interface for generic event arguments.
    /// </summary>
    /// <typeparam name="T">Type of argument.</typeparam>
    public interface IEventArgs<out T>
    {
        /// <summary>
        /// Gets the value or this event argument.
        /// </summary>
        T Value { get; }
    }
}