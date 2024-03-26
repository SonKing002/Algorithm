namespace BubleSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"버블 정렬");

            int[] arr = { 5, 2, 6, 7, 4 ,8};

            Console.WriteLine($"정렬 전 : {String.Join(", ", arr)}");

            BubleSort(arr);

            Console.WriteLine($"정렬 후 : {String.Join(", ", arr)}");
            Console.ReadKey();
        }

        static void Swap<T>(ref T a,ref T b)
        {
            T temp = a;
            a = b; 
            b = temp;
        }

        static void BubleSort(int[] arr)
        { 
            //돌면서 하나씩 체크하는 것
            for (int i = 0; i < arr.Length - 1; i++) 
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j],ref arr[j + 1]);
                    }
                }
            }
        }
    }
}
