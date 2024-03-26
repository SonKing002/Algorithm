public class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 54, 23, 55, 15, 16, 1 };
        Console.WriteLine($"정렬 전 : {String.Join(",", arr)}");
        SelectionSort(arr);
        Console.WriteLine($"정렬 후 : {String.Join(",", arr)}");
    }

    static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b; 
        b = temp;
    }

    static void SelectionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length -1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[minIndex])
                { 
                    minIndex = j;
                }
            }
            Swap(ref arr[minIndex],ref arr[i]);
        }  
    }
}

