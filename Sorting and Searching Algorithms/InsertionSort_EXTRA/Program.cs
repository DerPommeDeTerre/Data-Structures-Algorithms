namespace InsertionSort_EXTRA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 9, 1, 8, 2, 7, 3, 6, 5, 4 };

            insertionSort(numbers);

            foreach(int element in numbers) {
                Console.Write(element + " ");
            }
        }
        static void insertionSort(int[] numbers) {
            for (int i = 1; i < numbers.Length; i++) {
                int temp = numbers[i];
                int j = i - 1;
                while (j >= 0 && numbers[j] > temp) {
                    numbers[j + 1] = numbers[j];
                    j--;
                }
                numbers[j + 1] = temp;
            }
        }
    }
}
