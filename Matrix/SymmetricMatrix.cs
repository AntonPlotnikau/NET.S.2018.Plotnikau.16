namespace Matrix
{
    /// <summary>
    /// symmetric matrix
    /// </summary>
    /// <typeparam name="T">type of data in matrix</typeparam>
    /// <seealso cref="Matrix.SquareMatrix{T}" />
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// </summary>
        public SymmetricMatrix() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public SymmetricMatrix(int size) : base(size) { }

        /// <summary>
        /// Changes the element.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        protected override void ChangeElement(T value, int i, int j)
        {
            this.MatrixArr[i, j] = value;
            this.MatrixArr[j, i] = value;
        }
    }
}
