using System;
using MatrixMathLib;
using static System.Text.Encoding;
using static MatrixMathLib.ExtensionMethods;


namespace PrjModule15
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Enter rows number: ");
            var rows = System.Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter columns number: ");
            var cols = System.Convert.ToInt32(Console.ReadLine());
            var matrix = new ElementMatrix(rows, cols);

            for (var i = 0; i < rows; i++)
                for (var j = 0; j < cols; j++)
                {
                    Console.Write($"Write value of element [{i},{j}]: ");
                    var value = System.Convert.ToInt32(Console.ReadLine());
                    if (value > 0)
                        matrix[i, j] = value;
                    else
                        Console.WriteLine($"Element {value} is negative and won't be proceed");
                }


            //Our Serialized Json
            var output = SerializeToStream(matrix);

            //Standard Input Processing Obsolete
            //var inputStream = Console.OpenStandardInput();
            //var bytes = new byte[json.Length];

            //inputStream.Write(bytes, 0, json.Length);

            //var chars = UTF8.GetChars(bytes, 0, json.Length);

            var bytesOut = UTF8.GetBytes(output.ToCharArray(), 0, output.Length);

            //Standard Output Processing
            if (System.Console.OpenStandardOutput().BeginWrite(bytesOut, 0,
                output.Length, null, null).AsyncWaitHandle.WaitOne())
            {
            }

            //Deserializing
            var deserializedProduct = DeserializeFromStream<ElementMatrix>(output);
            Console.WriteLine($"\nRows count {deserializedProduct.Rows}");
        }
    }
}