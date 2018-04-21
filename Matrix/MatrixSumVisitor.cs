using System;

namespace Matrix
{
    /// <summary>
    /// matrix sum visitor
    /// </summary>
    /// <typeparam name="T">type of matrix data</typeparam>
    /// <seealso cref="Matrix.MatrixVisitor{T}" />
    public class MatrixSumVisitor<T> : MatrixVisitor<T>
    {
        /// <summary>
        /// The sum
        /// </summary>
        private Func<T, T, T> sum;

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixSumVisitor{T}"/> class.
        /// </summary>
        /// <param name="sum">The sum.</param>
        /// <exception cref="System.ArgumentNullException">sum is null</exception>
        public MatrixSumVisitor(Func<T, T, T> sum)
            => this.sum = sum ?? throw new ArgumentNullException(nameof(sum));

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public SquareMatrix<T> Result { get; private set; }

        /// <summary>
        /// Visits the specified matrix1 and matrix2.
        /// </summary>
        /// <param name="matrix1">The matrix1.</param>
        /// <param name="matrix2">The matrix2.</param>
        /// <returns>
        /// square matrix
        /// </returns>
        protected override SquareMatrix<T> Visit(SquareMatrix<T> matrix1, SquareMatrix<T> matrix2)
        {
            this.Validate(matrix1, matrix2);
            return this.Sum(matrix1, matrix2);
        }

        /// <summary>
        /// Visits the specified matrix1 and matrix2.
        /// </summary>
        /// <param name="matrix1">The matrix1.</param>
        /// <param name="matrix2">The matrix2.</param>
        /// <returns>
        /// square matrix
        /// </returns>
        protected override SquareMatrix<T> Visit(SymmetricMatrix<T> matrix1, SymmetricMatrix<T> matrix2)
        {
            this.Validate(matrix1, matrix2);
            return this.Sum(matrix1, matrix2);
        }

        /// <summary>
        /// Visits the specified matrix1 and matrix2.
        /// </summary>
        /// <param name="matrix1">The matrix1.</param>
        /// <param name="matrix2">The matrix2.</param>
        /// <returns>
        /// square matrix
        /// </returns>
        protected override SquareMatrix<T> Visit(DiagonalMatrix<T> matrix1, DiagonalMatrix<T> matrix2)
        {
            this.Validate(matrix1, matrix2);
            return this.Sum(matrix1, matrix2);
        }

        /// <summary>
        /// Sums the specified matrix1 and matrix2.
        /// </summary>
        /// <param name="matrix1">The matrix1.</param>
        /// <param name="matrix2">The matrix2.</param>
        /// <returns>square matrix</returns>
        private SquareMatrix<T> Sum(SquareMatrix<T> matrix1, SquareMatrix<T> matrix2)
        {
            this.Result = new SquareMatrix<T>(matrix1.Size);

            for (int i = 0; i < matrix1.Size; i++) 
            {
                for (int j = 0; j < matrix1.Size; j++)
                {
                    this.Result[i, j] = this.sum(matrix1[i, j], matrix2[i, j]);
                }
            }

            return this.Result;
        }

        /// <summary>
        /// Validates the specified matrix1.
        /// </summary>
        /// <param name="matrix1">The matrix1.</param>
        /// <param name="matrix2">The matrix2.</param>
        /// <exception cref="System.ArgumentNullException">
        /// matrix1 is null
        /// or
        /// matrix2 is null
        /// </exception>
        /// <exception cref="System.ArgumentException">Can not sum two matrix with different size</exception>
        private void Validate(SquareMatrix<T> matrix1, SquareMatrix<T> matrix2)
        {
            if (matrix1 == null)
            {
                throw new ArgumentNullException(nameof(matrix1));
            }

            if (matrix2 == null)
            {
                throw new ArgumentNullException(nameof(matrix2));
            }

            if (matrix1.Size != matrix2.Size)
            {
                throw new ArgumentException("Can not sum two matrix with different size");
            }
        }
    }
}
