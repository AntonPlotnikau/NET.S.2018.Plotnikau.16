namespace Matrix
{
    /// <summary>
    /// matrix visitor
    /// </summary>
    /// <typeparam name="T">type of data in matrix</typeparam>
    public abstract class MatrixVisitor<T>
    {
        /// <summary>
        /// Visits the specified matrix1 and matrix2.
        /// </summary>
        /// <param name="matrix1">The matrix1.</param>
        /// <param name="matrix2">The matrix2.</param>
        public void Visit(Matrix<T> matrix1, Matrix<T> matrix2) => this.Visit((dynamic)matrix1, (dynamic)matrix2);

        /// <summary>
        /// Visits the specified matrix1 and matrix2.
        /// </summary>
        /// <param name="matrix1">The matrix1.</param>
        /// <param name="matrix2">The matrix2.</param>      
        /// <returns>square matrix</returns>
        protected abstract SquareMatrix<T> Visit(SquareMatrix<T> matrix1, SquareMatrix<T> matrix2);

        /// <summary>
        /// Visits the specified matrix1 and matrix2.
        /// </summary>
        /// <param name="matrix1">The matrix1.</param>
        /// <param name="matrix2">The matrix2.</param>
        /// <returns>square matrix</returns>
        protected abstract SquareMatrix<T> Visit(SymmetricMatrix<T> matrix1, SymmetricMatrix<T> matrix2);

        /// <summary>
        /// Visits the specified matrix1 and matrix2.
        /// </summary>
        /// <param name="matrix1">The matrix1.</param>
        /// <param name="matrix2">The matrix2.</param>
        /// <returns>square matrix</returns>
        protected abstract SquareMatrix<T> Visit(DiagonalMatrix<T> matrix1, DiagonalMatrix<T> matrix2);
    }
}
