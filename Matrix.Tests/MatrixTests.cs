using System;
using NUnit.Framework;
using Matrix;

namespace Matrix.Tests
{
    [TestFixture]
    public class MatrixTests
    {
        [Test]
        [TestCase(4, ExpectedResult = 4)]
        [TestCase(5, ExpectedResult = 5)]
        [TestCase(143243, ExpectedResult = 143243)]
        public int SquareMatrixIndexerTests(int number)
        {
            var matrix = new SquareMatrix<int>();
            matrix[3, 2] = number;
            return matrix[3, 2];
        }

        [Test]
        [TestCase(4, ExpectedResult = 4)]
        [TestCase(5, ExpectedResult = 5)]
        [TestCase(143243, ExpectedResult = 143243)]
        public int  SymmetricMatrixIndexerTests(int number)
        {
            var matrix = new SymmetricMatrix<int>();
            matrix[3, 2] = number;
            return matrix[2, 3];
        }

        [Test]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(143243)]
        public void DiagonalMatrixIndexerTests(int number)
        {
            var matrix = new DiagonalMatrix<int>();
            Assert.Throws<ArgumentException>(() => matrix[3, 2] = number);
        }

        [Test]
        public void SumTests()
        {
            var matrix1 = new SquareMatrix<int>(2);
            var matrix2 = new DiagonalMatrix<int>(2);
            var matrix3 = new SymmetricMatrix<int>(2);

            matrix1[0, 0] = 17;
            matrix1[0, 1] = 20;
            matrix1[1, 0] = 13;
            matrix1[1, 1] = 15;

            matrix2[0, 0] = 3;
            matrix2[1, 1] = 4;

            matrix3[0, 0] = -5;
            matrix3[0, 1] = 12;
            matrix3[1, 1] = 3;

            var expected = new SquareMatrix<int>(2);

            expected[0, 0] = 15;
            expected[0, 1] = 32;
            expected[1, 0] = 25;
            expected[1, 1] = 22;

            var actual = matrix2.Sum(matrix3, (x, y) => x + y);
            actual = actual.Sum(matrix1, (x, y) => x + y);

            for (int i = 0; i < expected.Size; i++) 
            {
                for (int j = 0; j < expected.Size; j++) 
                {
                    if (expected[i, j] != actual[i, j])
                    {
                        Assert.Fail();
                    }
                }
            }
        }
    }
}
