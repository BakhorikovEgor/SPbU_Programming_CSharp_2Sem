using static System.Console;

namespace InsertionSort
{
    class Program
    {
        static void Swap(ref int firstElement, ref int secondElement)
        {
            int tempElement = firstElement;
            firstElement = secondElement;
            secondElement = tempElement;
        }

        static void SortArrayByInsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; ++i)
            {
                int j = i;
                while (j > 0 && array[j - 1] > array[j])
                {
                    Swap(ref array[j - 1], ref array[j]);
                    --j;
                }
            }
        }

        static void Main()
        {
            Write("Enter the size of array (positive number): ");
            int size = -1;
            while (!int.TryParse(ReadLine(), out size) || size <= 0)
            {
                WriteLine("Wrong size. Must be a positive number.");
                Write("Enter the size of array (positive number): ");
            }

            WriteLine("Enter array elements one by one (integer numbers). ");

            int[] array = new int[size];
            for (int i = 0; i < size; ++i)
            {
                while (!int.TryParse(ReadLine(), out array[i]))
                {
                    WriteLine("Wrong value");
                }
            }

            SortArrayByInsertionSort(array);

            Write("Sorted array: ");

            for (int i = 0; i < size; ++i)
            {
                Write($"{array[i]} ");
            }
        }
    }
}
