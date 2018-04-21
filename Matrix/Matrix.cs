using System;

namespace Matrix
{
    /// <summary>
    /// class that represents matrix
    /// </summary>
    /// <typeparam name="T">type of data in matrix</typeparam>
    public abstract class Matrix<T> 
    {
        /// <summary>
        /// The dimension default
        /// </summary>
        private const int DimensionDefault = 4;

        /// <summary>
        /// The first dimension
        /// </summary>
        private readonly int firstDimension;

        /// <summary>
        /// The second dimension
        /// </summary>
        private readonly int secondDimension;

        /// <summary>
        /// The matrix
        /// </summary>
        private T[,] matrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T}"/> class.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">invalid dimensions</exception>
        public Matrix(int i = DimensionDefault, int j = DimensionDefault)
        {
            if (i < 1 || j < 1) 
            {
                throw new ArgumentOutOfRangeException("invalid dimensions");
            }

            this.matrix = new T[i, j];
            this.firstDimension = i;
            this.secondDimension = j;
        }

        /// <summary>
        /// Occurs when [matrix change].
        /// </summary>
        public event EventHandler<MatrixEventArgs> MatrixChange = delegate { };

        /// <summary>
        /// Gets the first dimension.
        /// </summary>
        /// <value>
        /// The first dimension.
        /// </value>
        public int FirstDimension => this.firstDimension;

        /// <summary>
        /// Gets the second dimension.
        /// </summary>
        /// <value>
        /// The second dimension.
        /// </value>
        public int SecondDimension => this.secondDimension;

        /// <summary>
        /// Gets the matrix.
        /// </summary>
        /// <value>
        /// The matrix.
        /// </value>
        protected T[,] MatrixArr => this.matrix;

        /// <summary>
        /// Gets or sets the <see cref="T"/> with the specified i.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns>element with this index</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// parameter value must be more or equal zero
        /// or
        /// parameters must be less than dimensions
        /// or
        /// parameter value must be more or equal zero
        /// or
        /// parameters must be less than dimensions
        /// </exception>
        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0)
                {
                    throw new ArgumentOutOfRangeException("parameter value must be more or equal zero");
                }

                if (i >= this.FirstDimension || j >= this.SecondDimension)
                {
                    throw new ArgumentOutOfRangeException("parameters must be less than dimensions");
                }

                return this.matrix[i, j];
            }

            set
            {
                if (i < 0 || j < 0)
                {
                    throw new ArgumentOutOfRangeException("parameter value must be more or equal zero");
                }

                if (i > this.FirstDimension || j > this.SecondDimension)
                {
                    throw new ArgumentOutOfRangeException("parameters must be less than dimensions");
                }

                this.ChangeElement(value, i, j);
                this.OnMatrixChange(new MatrixEventArgs(i, j));                
            }
        }

        /// <summary>
        /// Changes the element.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        protected virtual void ChangeElement(T value, int i, int j)
        {
            this.matrix[i, j] = value;
        }

        /// <summary>
        /// Raises the <see cref="E:MatrixChange" /> event.
        /// </summary>
        /// <param name="e">The <see cref="MatrixEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMatrixChange(MatrixEventArgs e)
        {
            var temp = this.MatrixChange;
            temp?.Invoke(this, e);
        }
    }

    /// <summary>
    /// matrix event arguments
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class MatrixEventArgs : EventArgs
    {
        /// <summary>
        /// The row
        /// </summary>
        private readonly int row;

        /// <summary>
        /// The column
        /// </summary>
        private readonly int column;

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixEventArgs"/> class.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        public MatrixEventArgs(int i, int j)
        {
            this.row = i;
            this.column = j;
        }

        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <value>
        /// The row.
        /// </value>
        public int Row
        {
            get => this.row;
        }

        /// <summary>
        /// Gets the column.
        /// </summary>
        /// <value>
        /// The column.
        /// </value>
        public int Column
        {
            get => this.column;
        }
    }
}  