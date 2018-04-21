namespace Matrix
{
    /// <summary>
    /// square matrix
    /// </summary>
    /// <typeparam name="T">type of data in matrix</typeparam>
    /// <seealso cref="Matrix.Matrix{T}" />
    public class SquareMatrix<T> : Matrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public SquareMatrix(int size) : base(size, size)
        {
            this.Size = this.FirstDimension;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        public SquareMatrix() : base()
        {
            this.Size = this.FirstDimension;
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public int Size { get; private set; }
    }
}
