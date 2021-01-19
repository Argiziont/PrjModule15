using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

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

                if (currentNode.Previous == null)
                    list.AddFirst(element);
                else
                    list.AddAfter(currentNode.Previous!, element);
                list.Remove(currentNode);
                return currentNode;
            }

            throw new IndexOutOfRangeException();
        }

        public static string SerializeToStream<T>(T obj)=> JsonConvert.SerializeObject(obj);

        public static T DeserializeFromStream<T>(string stream)=> JsonConvert.DeserializeObject<T>(stream);

    }
}