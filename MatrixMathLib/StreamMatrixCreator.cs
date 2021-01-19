using System;
using System.IO;

namespace MatrixMathLib
{
    public static class StreamMatrixCreator
    {
        public static void CreateMatrix(Stream stream, ElementMatrix matrix)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));

            stream.Position = 0;

            using var reader = new BinaryReader(stream);

            var rows = reader.ReadInt32();
            var columns = reader.ReadInt32();

            matrix.AddRows(rows);
            matrix.AddColumns(columns);

            for (var i = 0; i < rows; i++)
            for (var j = 0; j < columns; j++)
                matrix[i, j] = reader.ReadInt32();
        }
    }
}