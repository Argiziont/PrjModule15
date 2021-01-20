using System;
using System.IO;
using Xunit;

namespace MatrixMathLib.Tests
{
    public class StreamMatrixCreatorTests
    {
        #region snippet_CreateMatrix_Passes_InputIsCorrect

        [Fact]
        public void CreateMatrix_Passes_InputIsCorrect()
        {
            // Arrange
            var matrix = new ElementMatrix();

            using var consoleStream = new MemoryStream();
            using var consoleWriter = new BinaryWriter(consoleStream);

            consoleWriter.Write(1);
            consoleWriter.Write(1);
            consoleWriter.Write(1);

            // Act
            StreamMatrixCreator.CreateMatrix(consoleStream, matrix);

            // Assert
            Assert.Equal(1, matrix[0,0]);
        }

        #endregion

        #region snippet_CreateMatrix_ThrowsArgumentNullException_InputStreamIsNull

        [Fact]
        public void CreateMatrix_ThrowsArgumentNullException_InputStreamIsNull()
        {
            //Arrange&& Act
            static void Result() =>
                StreamMatrixCreator.CreateMatrix(null, null);

            // Assert
            Assert.Throws<ArgumentNullException>(Result);
        }

        #endregion
    }
}