using System;
using System.IO;
using Xunit;

namespace MatrixMathLib.Tests
{
    public class ElementMatrixTests
    {
        #region snippet_GetMemoryStream_Passes_InputIsCorrect

        [Fact]
        public void GetMemoryStream_Passes_InputIsCorrect()
        {
            // Arrange
            var matrix1 = new ElementMatrix(1, 1)
            {
                [0, 0] = 1
            };
            using var stream = new MemoryStream();
            using var resultStream = new BinaryWriter(stream);

            // Act
            matrix1.GetMemoryStream(resultStream, out _);

            // Assert
            Assert.True(stream.Length>0);
        }

        #endregion

        #region snippet_GetMemoryStream_ThrowsArgumentNullException_InputStreamIsNull

        [Fact]
        public void GetMemoryStream_ThrowsArgumentNullException_InputStreamIsNull()
        {
            // Arrange
            var matrix1 = new ElementMatrix(1, 1)
            {
                [0, 0] = 1
            };

            // Act
            void Result()=>
            matrix1.GetMemoryStream(null, out _);

            // Assert
            Assert.Throws<ArgumentNullException>(Result);
        }

        #endregion

        #region snippet_Remove_Passes_InputIsCorrect

        [Fact]
        public void Remove_Passes_InputIsCorrect()
        {
            // Arrange
            var matrix1 = new ElementMatrix(1, 1)
            {
                [0, 0] = 1
            };

            // Act
            matrix1.Remove(0,0);

            // Assert
            Assert.True(matrix1[0,0]==0);
        }

        #endregion

        #region snippet_Remove_ThrowsIndexOutOfRangeException_InputIsOutOfRange

        [Fact]
        public void Remove_ThrowsIndexOutOfRangeException_InputIsOutOfRange()
        {
            // Arrange
            var matrix1 = new ElementMatrix(1, 1);

            // Act
            void Result() =>
                matrix1.Remove(1, 1);

            // Assert
            Assert.Throws<IndexOutOfRangeException>(Result);
        }

        #endregion

        #region snippet_AddRows_Passes_InputIsCorrect

        [Fact]
        public void AddRows_Passes_InputIsCorrect()
        {
            // Arrange
            var matrix1 = new ElementMatrix(1, 1)
            {
                [0, 0] = 1
            };

            // Act
            matrix1.AddRows(1);

            // Assert
            Assert.Equal(2,matrix1.Rows);
        }

        #endregion

        #region snippet_AddColumn_Passes_InputIsCorrect

        [Fact]
        public void AddColumn_Passes_InputIsCorrect()
        {
            // Arrange
            var matrix1 = new ElementMatrix(1, 1)
            {
                [0, 0] = 1
            };

            // Act
            matrix1.AddColumns(1);

            // Assert
            Assert.Equal(2, matrix1.Columns);
        }

        #endregion

        #region snippet_GetSum_Passes_InputIsCorrect

        [Fact]
        public void GetSum_Passes_InputIsCorrect()
        {
            // Arrange
            var matrix1 = new ElementMatrix(1, 1)
            {
                [0, 0] = 1
            };

            // Act
            var result=  matrix1.GetSum();

            // Assert
            Assert.Equal(1, result);
        }

        #endregion

        #region snippet_GetProduct_Passes_InputIsCorrect

        [Fact]
        public void GetProduct_Passes_InputIsCorrect()
        {
            // Arrange
            var matrix1 = new ElementMatrix(1, 1)
            {
                [0, 0] = 1
            };

            // Act
            var result = matrix1.GetProduct();

            // Assert
            Assert.Equal(1, result);
        }

        #endregion

        #region snippet_AddMatrix_Passes_InputIsCorrect

        [Fact]
        public void AddMatrix_Passes_InputIsCorrect()
        {
            // Arrange
            var matrix1 = new ElementMatrix(1, 1)
            {
                [0, 0] = 1
            };
            var matrix2 = new ElementMatrix(1, 1)
            {
                [0, 0] = 1
            };

            // Act
            var result = matrix1.AddMatrix(matrix2);

            // Assert
            Assert.Equal(2, result[0,0]);
        }

        #endregion

        #region snippet_AddMatrix_ThrowsArgumentNullException_InputIsNull

        [Fact]
        public void AddMatrix_ThrowsArgumentNullException_InputIsNull()
        {
            // Arrange
            var matrix1 = new ElementMatrix(1, 1)
            {
                [0, 0] = 1
            };

            // Act
            void Result() =>
                matrix1.AddMatrix(null);

            // Assert
            Assert.Throws<ArgumentNullException>(Result);
        }

        #endregion

        #region snippet_SubtractMatrix_Passes_InputIsCorrect

        [Fact]
        public void SubtractMatrix_Passes_InputIsCorrect()
        {
            // Arrange
            var matrix1 = new ElementMatrix(1, 1)
            {
                [0, 0] = 1
            };
            var matrix2 = new ElementMatrix(1, 1)
            {
                [0, 0] = 1
            };

            // Act
            var result = matrix1.SubtractMatrix(matrix2);

            // Assert
            Assert.Equal(0, result[0, 0]);
        }

        #endregion

        #region snippet_SubtractMatrix_ThrowsArgumentNullException_InputIsNull

        [Fact]
        public void SubtractMatrix_ThrowsArgumentNullException_InputIsNull()
        {
            // Arrange
            var matrix1 = new ElementMatrix(1, 1)
            {
                [0, 0] = 1
            };

            // Act
            void Result() =>
                matrix1.SubtractMatrix(null);

            // Assert
            Assert.Throws<ArgumentNullException>(Result);
        }

        #endregion

        #region snippet_ProductMatrix_Passes_InputIsCorrect

        [Fact]
        public void ProductMatrix_Passes_InputIsCorrect()
        {
            // Arrange
            var matrix1 = new ElementMatrix(1, 1)
            {
                [0, 0] = 1
            };
            var matrix2 = new ElementMatrix(1, 1)
            {
                [0, 0] = 1
            };

            // Act
            var result = matrix1.ProductMatrix(matrix2);

            // Assert
            Assert.Equal(1, result[0, 0]);
        }

        #endregion

        #region snippet_ProductMatrix_ThrowsArgumentNullException_InputIsNull

        [Fact]
        public void ProductMatrix_ThrowsArgumentNullException_InputIsNull()
        {
            // Arrange
            var matrix1 = new ElementMatrix(1, 1)
            {
                [0, 0] = 1
            };

            // Act
            void Result() =>
                matrix1.ProductMatrix(null);

            // Assert
            Assert.Throws<ArgumentNullException>(Result);
        }

        #endregion
    }
}