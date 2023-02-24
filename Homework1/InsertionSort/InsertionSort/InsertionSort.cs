namespace InsertionSort
{
    using static System.Console;

    class Program
    {
        static void Swap(int[] array, int firstIndex, int secondIndex)
        {
            int tempValue = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = tempValue;
        }

        static void SortArrayByInsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && array[j - 1] > array[j])
                {
                    Swap(array, j - 1, j);
                    j--;
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
                int value;
                while (!int.TryParse(ReadLine(), out value))
                {
                    WriteLine("Wrong value");
                }

                array[i] = value;
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
