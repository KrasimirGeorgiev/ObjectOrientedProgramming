/* Problem 5. Generic class (Done) */
/* Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
 * Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
 * Implement methods for adding element, accessing element by index, removing element by index,
 * inserting element at given position, clearing the list, finding element by its value and ToString().
 * Check all input parameters to avoid accessing elements at invalid positions. */

/* Problem 6. Auto-grow (Done) */
/* Implement auto-grow functionality: when the internal array is full, create a new array 
 * of double size and move all elements to it. */

/* Problem 7. Min and Max (Done) */
/* Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal
 * element in the GenericList<T>.
 * You may need to add a generic constraints for the type T. */

namespace SuperLists
{
    using System;
    using ConsoleMio.ConsoleEnhancements;

    public class TestGenericList
    {
        private const ConsoleColor Info = ConsoleColor.DarkRed;
        private const ConsoleColor Result = ConsoleColor.DarkBlue;
        private const ConsoleColor Pause = ConsoleColor.Black;

        private static readonly ConsoleMio ConsoleMio = new ConsoleMio();

        private static void Main()
        {
            ConsoleMio.PrintHeading("Homework: Defining Classes Part 2 - Generic Class");

            GenericList<int> intList = CreateIntList();

            InitNumbers(intList);
            ChangeValue(intList, 5, 2000);
            AddNumbers(intList);
            TestInsertAt(intList, 2, -123);
            TestRemoveAt(intList, 0);
            ShowMax(intList);
            ShowMin(intList);
            TestIndexOf(intList, 100);
            TestIndexOf(intList, -100);
        }

        private static void PrintList<T>(GenericList<T> list) where T : IComparable<T>
        {
            ConsoleMio
                .Write("List size: ", color: Info)
                .WriteLine(list.Count, color: Result)
                .WriteLine(list, color: Result)
                .WriteLine();
        }

        private static void TestIndexOf<T>(GenericList<T> list, T value) where T : IComparable<T>
        {
            ConsoleMio
               .Format("Looking up index of {0}: ", color: Info, args: value)
               .WriteLine(list.IndexOf(value), color: Result)
               .WriteLine();

            PrintList(list);
            ConsoleMio.PromptToContinue(color: Pause);
        }

        private static void ShowMin<T>(GenericList<T> list) where T : IComparable<T>
        {
            ConsoleMio
                .Write("Min Value: ", color: Info)
                .WriteLine(list.Min(), color: Result)
                .WriteLine();

            PrintList(list);
            ConsoleMio.PromptToContinue(color: Pause);
        }

        private static void ShowMax<T>(GenericList<T> list) where T : IComparable<T>
        {
            ConsoleMio
                .Write("Max Value: ", color: Info)
                .WriteLine(list.Max(), color: Result)
                .WriteLine();

            PrintList(list);
            ConsoleMio.PromptToContinue(color: Pause);
        }

        private static void TestInsertAt<T>(GenericList<T> lsit, int index, T value) where T : IComparable<T>
        {
            ConsoleMio
                .Write("Inserting ", color: Info)
                .Write(value, color: Result)
                .Write(" at index ", color: Info)
                .WriteLine(index, color: Result)
                .WriteLine();

            lsit.InsertAt(2, value);
            PrintList(lsit);
            ConsoleMio.PromptToContinue(color: Pause);
        }

        private static void TestRemoveAt<T>(GenericList<T> intList, int index) where T : IComparable<T>
        {
            ConsoleMio
                .Write("Removing at index ", color: Info)
                .Write(index, color: Result)
                .WriteLine();

            intList.RemoveAt(index);
            PrintList(intList);
            ConsoleMio.PromptToContinue(color: Pause);
        }

        private static void AddNumbers(GenericList<int> intList)
        {
            intList.Add(90, 100, 101, 102);
            ConsoleMio
                .Write("Adding ", color: Info)
                .Write("90, 100, 101, 102", color: Result)
                .WriteLine(" To the list", color: Info)
                .Write("New size: ", color: Info)
                .WriteLine(intList.Count, color: Result)
                .WriteLine();

            PrintList(intList);
            ConsoleMio.PromptToContinue(color: Pause);
        }

        private static void ChangeValue<T>(GenericList<T> intList, int index, T value)
            where T : IComparable<T>
        {
            intList[index] = value;

            ConsoleMio
                .Write("Changing element value at index ", color: Info)
                .Write(index, color: Result)
                .Write(" to ", color: Info)
                .WriteLine(value, color: Result)
                .WriteLine();

            PrintList(intList);
            ConsoleMio.PromptToContinue(color: Pause);
        }

        private static GenericList<int> CreateIntList()
        {
            ConsoleMio
                .Write("Creating a new GenericList<", color: Info)
                .Write("int", color: Result)
                .WriteLine(">", color: Info)
                .WriteLine();

            var intList = new GenericList<int>();
            ConsoleMio
                .Write("Initial size: ", color: Info)
                .WriteLine(intList.Count, color: Result)
                .WriteLine();

            ConsoleMio.PromptToContinue(color: Pause);

            return intList;
        }

        private static void InitNumbers(GenericList<int> intList)
        {
            int[] numbers = { 5, 8, 23, 1, 45, 45, 46, 56 };
            intList.Add(numbers);
            ConsoleMio
                .Write("Adding elements [", color: Info)
                .Write(string.Join(", ", numbers), color: Result)
                .WriteLine("]", color: Info)
                .WriteLine();


            PrintList(intList);
            ConsoleMio.PromptToContinue(color: Pause);
        }
    }
}
