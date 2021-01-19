using System.IO;

namespace MatrixMathLib.Interfaces
{
    public interface IMemorizable
    {
        public void GetMemoryStream(BinaryWriter stream, out Stream negativeNumbersStream);
    }
}