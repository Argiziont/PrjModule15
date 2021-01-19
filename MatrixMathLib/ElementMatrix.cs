using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixMathLib
{
    [Serializable]
    public class ElementMatrix
    {
        public LinkedList<LinkedList<int>> Matrix;

        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public ElementMatrix()
        {
            Matrix = new LinkedList<LinkedList<int>>();

        }
        public ElementMatrix(LinkedList<LinkedList<int>> matrix)
        {
            Matrix = matrix;

            Rows = matrix.Count;
            if (matrix.Last != null) Columns = matrix.Last.Value.Count;
            else
            {
                throw new ArgumentNullException(nameof(matrix.Last));
            }
        }
        public ElementMatrix(int rows, int columns)
        {
            Matrix = new LinkedList<LinkedList<int>>();
            for (var i = 0; i < rows; i++)
            {
                var subMatrix = new LinkedList<int>();

                for (var j = 0; j < columns; j++)
                {
                    subMatrix.AddLast(0);
                }
                Matrix.AddLast(subMatrix);
            }

            Rows = rows;
            Columns = columns;
        }

        public void Remove(int row, int column)
        {
            var currentNode = Matrix.First;
            for (var i = 0; i <= row && currentNode != null; i++)
            {
                if (i != row)
                {
                    currentNode = currentNode.Next;
                    continue;
                }

                currentNode.Value.RemoveAt(column);
                return;
            }

            throw new IndexOutOfRangeException();
        }

        public void AddRows(int rowsCount)
        {
            for (var i = 0; i < rowsCount; i++)
            {
                var subMatrix = new LinkedList<int>();

                for (var j = 0; j < Columns; j++)
                {
                    subMatrix.AddLast(0);
                }
                Matrix.AddLast(subMatrix);
            }

            Rows += rowsCount;
        }

        public void AddColumns(int columnsCount)
        {
            var currentNode = Matrix.First;
            for (var i = 0; i <= Rows && currentNode != null; i++)
            {
                for (var j = 0; j < columnsCount; j++)
                {

                    currentNode.Value.AddLast(0);
                }

                currentNode = currentNode.Next;
            }

            Columns += columnsCount;
        }

        public int this[int row, int column]
        {
            get => Matrix.ElementAt(row).ElementAt(column);
            set
            {
                var currentNode = Matrix.First;
                for (var i = 0; i <= row && currentNode != null; i++)
                {
                    if (i != row)
                    {
                        currentNode = currentNode.Next;
                        continue;
                    }

                    currentNode.Value.ChangeAt(column, value);
                    return;
                }

                throw new IndexOutOfRangeException();
            }
        }

        public LinkedList<LinkedList<int>> GetMatrix() => Matrix;

        public int GetSum()
        {
            var sum = 0;
            var currentRowNode = Matrix.First;
            for (var i = 0; i <= Rows && currentRowNode != null; i++)
            {
                var currentColumnNode = currentRowNode.Value.First;
                for (var j = 0; j <= Rows && currentColumnNode != null; j++)
                {
                    sum += currentColumnNode.Value;
                    currentColumnNode = currentColumnNode.Next;
                }
                currentRowNode = currentRowNode.Next;
            }

            return sum;
        }
        public int GetProduct()
        {
            var product = 1;
            var currentRowNode = Matrix.First;
            for (var i = 0; i <= Rows && currentRowNode != null; i++)
            {
                var currentColumnNode = currentRowNode.Value.First;
                for (var j = 0; j <= Rows && currentColumnNode != null; j++)
                {
                    product *= currentColumnNode.Value;
                    currentColumnNode = currentColumnNode.Next;
                }
                currentRowNode = currentRowNode.Next;
            }

            return product;
        }
        public ElementMatrix AddMatrix(ElementMatrix matrix)
        {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));

            if (Columns != matrix.Columns || Rows != matrix.Rows)
                throw new OperationCanceledException("Columns and rows must have same size in both matrices");
            var resultMatrix = new ElementMatrix(Rows, Columns);

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {

                    resultMatrix[i, j]=this[i,j] + matrix[i, j];
                }
            }
            return resultMatrix;
        }

        public ElementMatrix SubtractMatrix(ElementMatrix matrix)
        {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));

            if (Columns != matrix.Columns || Rows != matrix.Rows)
                throw new OperationCanceledException("Columns and rows must have same size in both matrices");
            var resultMatrix = new ElementMatrix(Rows, Columns);

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {

                    resultMatrix[i, j] = this[i, j] - matrix[i, j];
                }
            }
            return resultMatrix;
        }

        public ElementMatrix ProductMatrix(ElementMatrix matrix)
        {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));

            if (Columns != matrix.Rows)
                throw new OperationCanceledException(
                    "Columns in main matrix must have same size as rows in given matrix");

            var resultMatrix = new ElementMatrix(Rows, matrix.Columns);
            var firstMatrix = this;
            var secondMatrix = matrix;

            for (var i = 0; i < firstMatrix.Rows; ++i)
            for (var j = 0; j < secondMatrix.Columns; ++j)
            for (var k = 0; k < firstMatrix.Columns; ++k)
                resultMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];


            return resultMatrix;
        }
    }
}
