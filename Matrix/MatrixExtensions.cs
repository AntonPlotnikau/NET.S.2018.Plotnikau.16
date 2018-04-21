using System;

namespace Matrix
{
    /// <summary>
    /// matrix extensions
    /// </summary>
    public static class MatrixExtensions
    {
        /// <summary>
        /// Sums the specified matrix and other matrix.
        /// </summary>
        /// <typeparam name="T">type of data in matrix</typeparam>
        /// <param name="matrix">The matrix.</param>
        /// <param name="other">The other.</param>
        /// <param name="sum">The sum.</param>
        /// <returns>matrix that a result of sum</returns>
        /// <exception cref="System.ArgumentNullException">
        /// matrix is null
        /// or
        /// other is null
        /// </exception>
        public static Matrix<T> Sum<T>(this Matrix<T> matrix, Matrix<T> other, Func<T, T, T> sum)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var visitor = new MatrixSumVisitor<T>(sum);
            visitor.Visit(matrix, other);
            return visitor.Result;
        }
    }
}
