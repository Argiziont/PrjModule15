using MatrixMathLib;
using System;

namespace PrjModule15
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Enter rows number: ");
            var rows = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter columns number: ");
            var cols = Convert.ToInt32(Console.ReadLine());
            var matrix = new ElementMatrix(rows, cols);

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    Console.Write($"Write value of element [{i},{j}]: ");
                    var value = Convert.ToInt32(Console.ReadLine());
                    if (value>0)
                    {
                        matrix[i, j] = value;
                    }
                    else
                        Console.WriteLine($"Element {value} is negative and won't be proceed");

                }
            }


            // Serializing
            var buffer = ExtensionMethods.SerializeToStream(matrix);

            // De-Serializing
            var restoredMatrix = (ElementMatrix)ExtensionMethods.DeserializeFromStream(buffer);

            Console.WriteLine("De-Serialized");
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (restoredMatrix != null) Console.Write($"{restoredMatrix[i, j]}    ");
                }

                Console.WriteLine();

            }

        }



    }
}