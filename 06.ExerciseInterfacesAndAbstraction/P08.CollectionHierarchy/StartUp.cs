﻿using CollectionHierarchy.Interfaces;
using System;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split();
            int removeOpCnt = int.Parse(Console.ReadLine());

            IAddCollection<string> addCollection = new AddCollection<string>();
            IAddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            IMyList<string> myList = new MyList<string>();

            AddToAnyCollection(words, addCollection);
            AddToAnyCollection(words, addRemoveCollection);
            AddToAnyCollection(words, myList);

            RemoveToAnyCollection(removeOpCnt, addRemoveCollection);
            RemoveToAnyCollection(removeOpCnt, myList);
        }

        private static void RemoveToAnyCollection(int removeOpCnt, 
            IAddRemoveCollection<string> collection)
        {
            for (int i = 0; i < removeOpCnt; i++)
            {
                Console.Write(collection.Remove() + " ");
            }
            Console.WriteLine();
        }

        private static void AddToAnyCollection(string[] words, IAddCollection<string> collection)
        {
            foreach (string word in words)
            {
                Console.Write(collection.Add(word) + " ");
            }
            Console.WriteLine();
        }
    }
}
