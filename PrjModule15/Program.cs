using System;
using System.Collections.Generic;
using System.IO;
using MatrixMathLib;
using static MatrixMathLib.ExtensionMethods;
using static System.Text.Encoding;
using Convert = System.Convert;


namespace PrjModule15
{
    internal static class Program
    {
        private static void Main()
        {
            var matrix = new ElementMatrix();

            using var consoleStream = new MemoryStream();
            using var consoleWriter = new BinaryWriter(consoleStream);

            Console.Write("Enter rows number: ");
            var rows = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter columns number: ");
            var cols = Convert.ToInt32(Console.ReadLine());

            consoleWriter.Write(rows);
            consoleWriter.Write(cols);

            for (var i = 0; i < rows; i++)
            for (var j = 0; j < cols; j++)
            {
                Console.Write($"Write value of element [{i},{j}]: ");
                consoleWriter.Write(Convert.ToInt32(Console.ReadLine()));
            }

            StreamMatrixCreator.CreateMatrix(consoleStream, matrix);

            //Our Serialized Json
            var output = SerializeToStream(matrix);

            var bytesOut = UTF8.GetBytes(output.ToCharArray(), 0, output.Length);

            //Standard Output Processing
            if (Console.OpenStandardOutput().BeginWrite(bytesOut, 0,
                output.Length, null, null).AsyncWaitHandle.WaitOne())
            {
            }

            //Deserializing
            var deserializedProduct = DeserializeFromStream<ElementMatrix>(output);
            Console.WriteLine($"\nRows count {deserializedProduct.Rows}");

            using var stream = new MemoryStream();
            using var resultStream = new BinaryWriter(stream);

            deserializedProduct.GetMemoryStream(resultStream, out _);

            var intList = new List<int>();

            stream.Position = 0;

            using var reader = new BinaryReader(stream);
            for (var i = 0; i < deserializedProduct.Columns * deserializedProduct.Rows; i++)
                intList.Add(reader.ReadInt32());
            Console.WriteLine("\nRestored matrix");
            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++) Console.Write(intList[i * matrix.Columns + j] + "   ");
                Console.WriteLine();
            }
        }
    }
}