using System;

namespace Matrix
{
    /// <summary>
    /// diagonal matrix
    /// </summary>
    /// <typeparam name="T">type of data in matrix</typeparam>
    /// <seealso cref="Matrix.SquareMatrix{T}" />
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        public DiagonalMatrix() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public DiagonalMatrix(int size) : base(size) { }

        /// <summary>
        /// Changes the element.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <exception cref="System.ArgumentException">you can only change elements within the diagonal</exception>
        protected override void ChangeElement(T value, int i, int j)
        {
            if (i != j)
            {
                throw new ArgumentException("you can only change elements within the diagonal");
            }

            this.MatrixArr[i, j] = value;
        }
    }
}
