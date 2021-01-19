using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMathLib
{
    public static class ExtensionMethods
    {
        public static LinkedListNode<T> RemoveAt<T>(this LinkedList<T> list, int index)
        {
            var currentNode = list.First;
            for (var i = 0; i <= index && currentNode != null; i++)
            {
                if (i != index)
                {
                    currentNode = currentNode.Next;
                    continue;
                }

                list.Remove(currentNode);
                return currentNode;
            }

            throw new IndexOutOfRangeException();
        }

        public static LinkedListNode<T> ChangeAt<T>(this LinkedList<T> list, int index, T element)
        {
            var currentNode = list.First;
            for (var i = 0; i <= index && currentNode != null; i++)
            {
                if (i != index)
                {
                    currentNode = currentNode.Next;
                    continue;
                }

                if (currentNode.Previous==null)
                {
                    list.AddFirst(element);
                }
                else
                {
                    list.AddAfter(currentNode.Previous!, element);
                }
                list.Remove(currentNode);
                return currentNode;
            }

            throw new IndexOutOfRangeException();
        }

        public static MemoryStream SerializeToStream(object obj)
        {
            var stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream;
        }

        public static object DeserializeFromStream(MemoryStream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);
            var obj = formatter.Deserialize(stream);
            return obj;
        }
    }
}
