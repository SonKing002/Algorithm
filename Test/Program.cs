namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 2, 8, 4, 1, };

            Console.WriteLine($"정렬 전 {string.Join(",", arr)}");
            Console.ReadKey();

            BubleSorting(arr);
            Console.WriteLine("\n");
            Console.ReadKey();

            Console.WriteLine($"버블 정렬 후 {string.Join(",", arr)} \n");
            Console.ReadKey();

            int[] arr2 = { 10, 9, 7, 21, 13, 20, 14, 7, 3, 4, 2, 6, 8, 10, 1, 9, 11, 15, 1, 2, 3 };
            Console.WriteLine($"퀵 정렬 전 : {string.Join(",", arr2)}");
            QuickSort(arr2,0,arr2.Length-1);
            Console.ReadKey();

            Console.WriteLine($"퀵 정렬 후 : {string.Join(",", arr2)}");
            Console.ReadKey();

        }

        /// <summary>
        /// 스왑하는 함수
        /// </summary>
        /// <typeparam name="T">실체가 없고, 함수를 호출할 때, 함수를 만들어준다. 복붙 하고 T 지우고-> 해당 자료형으로 추가</typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        //바로 옆과 스위칭
        #region 버블 소트
        /*
         * 최선의 경우 (이미 정렬된 경우) : O(n)
         * 평균과 최악의 경우 : O(n^2)
         */


        public static void BubleSorting(int[] arr)
        {
            if (arr == null)
            {
                Console.WriteLine("배열이 없습니다.");
                return;
            }

            int max = 0;
            for (int i = 0; i < arr.Length-1; i++)
            {
                for (int j = 0; j < arr.Length-1-i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\n정렬 알고리즘 : Bubble Sort \n");
            for (int i = 0; i < arr.Length; i++)
            { 
                Console.Write($"{arr[i]} ");
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        /// <summary>
        /// 강사님 답지 버블소트
        /// </summary>
        /// <param name="arr"></param>
        static void BubleSort(int[] arr)
        { 
            for(int i = 0;i < arr.Length - 1;i++)
            {
                for (int j = 0; j < arr.Length -1 - i; j++)
                {
                    if (arr[j] > arr[j + 1] == true)
                    { 
                        Swap(ref arr[i], ref arr[j +1]);
                    }
                }
            }
        }
        #endregion 

        //가장 최소 최댓갑과 스위칭
        #region 선택정렬

        public static void SelectSort(int[] arr)
        {
            int min;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    min = arr[i];
                    if (arr[i] < arr[j])
                    {
                        continue;
                    }
                    //크거나 같은 경우
                    arr[i] = arr[j];
                    arr[j] = min;
                }
            }
        }

        /// <summary>
        /// 강사님 답지
        /// </summary>
        /// <param name="arr"></param>
        static void SelectionSort(int[] arr)
        {
            //루프를 순회 하면서 현 비교 하는 리스트에서 
            //최소값 (또는 최댓값)을 가장자리로 정렬 시키는 과정
            for (int i = 0; i < arr.Length-1 ; i++) //하나 작은 것 까지
            {
                int minIndex = i;

                for (int j = i + 1; j < arr.Length; j++)// 다음 순서부터
                {
                    if (arr[j] < arr[minIndex] == true)
                    {
                        minIndex = j;
                    }
                }//순회만 함

                //전체 순회가 끝나면 최소값을 가장 왼쪽으로 설정
                Swap(ref arr[i], ref arr[minIndex]);
            }
        }
        #endregion 


        #region 삽입 정렬
        /*
        최선의 경우 (이미 정렬된 경우) : O(n)
        평균 최악의 경우 : O(n^2)
        */
        static void InsertSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                //정렬이 된 상태이므로 건너 뜀
                if (arr[i - 1] <= arr[i] == true)
                {
                    continue;
                }

                //정렬
                int keyValue = arr[i];//비교를 위해 현재 값 뽑기

                for(int j = i; j > 0; j--) 
                {
                    //왼쪽의 값이 크면 값 바꾸기
                    if (arr[j] > keyValue)
                    {
                        arr[j] = arr[j - 1];
                        arr[j - 1] = keyValue;
                    }
                    //이 작업은 정렬되지 않을 때까지만 반복
                    else
                    {
                        break;
                    }
                }
            }

        }


        #endregion

        #region 퀵 정렬 Quick Sort
        /* 평균적으로 가장 빠르다고 알려짐
         * stack 공간을 사용함 
         *군사에서 쓰는 작전방법으로 나옴, 작은 단위로 쪼개서 분할한 후 각 부분을 재귀적으로 정렬하여 전체를 리스트를 정렬하는 방식이다. 
         *
         *기준 값 : Pivot을 뽑은 다음, 좌우로 각각 정렬한다.
         *좌우에 랜덤으로 다시 기준을 뽑고 정렬
         *
         *기준 값이 중간이어야 최상의 성능을 낸다.
         *각 끝이면 최악임

         *중간 값을 위해 비용이 발생하지만 최악의 경우 수를 피할 수 있다.
         *1. 5개가 있으면 랜덤으로 뽑기 ( 난수 뽑는 계산은 성능을 잡아먹는다. bad)
         *2. 기계적으로 고정 값 뽑기
        */

         /* 과정
         *나눌 때 큰 값 오른 쪽 작은 값 왼쪽으로, 정렬이 안된 채로 보낸다.
         *오른 쪽 왼 쪽 나뉘면, 계속 나눈다.
         *더 이상 나눠지지 않은 순간, 스위칭이 완료 된다.
         
        퀵 정렬은
         트리구조와 비슷하고, 재귀를 사용하여 효과적으로 처리 할 수 있다.
         오류가 날 수 있음 (OutOfIndex)에 대한 에러처리를 해야하므로
         성능을 깎아먹을 수 있다.
         */

        /*
         * ->  <-
         * 기준값보다 큰 것을 찾는다. ( 찾으면 멈춤) : 바꿈
         * 기준값보다 작은 것을 찾는다 (찾으면 멈춤) : 바꿈 
         * 
         * 교차 지점에서 바뀌면 분기점으로 좌우 나뉨
         * 
         
         */

        public static void QuickSort(int[] arr,int left, int right)
        {
            if (left < right)
            { 
                //피봇의 기준으로 집합을 분할한다. //인덱스가 0 또는 마지막 걸릴 경우 outofindex
                int pivotIndex = Partition(arr, left, right);

                //PivotIndex 기준으로 나눠서 재귀 호출
                // (left ~  pivotIndex-1) pivotIndex (pivotIndex+1 ~ right)
                //왼쪽 데이터 집합에 대해 퀵 정렬 재귀 호출
                QuickSort(arr,left, pivotIndex -1);
                //오른쪽 데이터 집합에 대해 퀵 정렬 재귀 호출
                QuickSort(arr, pivotIndex + 1, right);
            }
        }

        static int Partition(int[] arr, int left, int right)
        {
            //전달된 부분 배열의 첫번째 요소를 비교 기준(피벗) 값으로 사용
            int first = left;
            int pivot = arr[first];

            //앞서 첫번째 요소를 기준 값으로 사용했기 떄문에 인덱스를증가한 후에 비교 진행
            ++left;

            while (left < right)
            {
                //왼쪽 데이터 영역에서 피벗 값보다 큰 값을 찾을 때까지left++; 루프
                while ((left <= arr.Length-1) && arr[left] <= pivot)//예외 처리 &&큰 값을 찾은 경우 멈춤
                {
                    ++left;
                }

                //그 다음, 데이터 영역에서 피벗 값보다 작은 값을 찾을 때까지 오른쪽에서 왼쪽으로 right 인덱스 감소 처리
                while ((right >= 0)&& arr[right] > pivot)//예외 처리 &&
                {
                    --right;
                }

                //left와 right가 서로 교차(만나는) 하지 않았다면, left 와 right 위치의 값을 서로 교환한다.
                if (left < right)
                {
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else// 서로 인덱스가 교차했다면, 이번 순서부터는 검색이 완료되었으므로, 탈출
                {
                    break;
                }
                // 배열의 범위가 넘어가는경우 ( -1, length ) 예외처리가 필요하다
            }

            //최종적으로 피벗과 왼쪽 데이터 집합의 마지막 요소(right)를 교환한다.
            if (arr[first] > arr[right])
            {
                int temp2 = arr[first];
                arr[first] = arr[right];
                arr[right] = temp2;
                first = right;
            }

            //피벗 값 반환.
            return first;
        }
        #endregion

    }
}
/*Array.Sort 
//16개 이하면 삽입정렬을 쓰고
//2 log 2^n 힙 정렬( 힙데이터가 아니라 이진트리) : 루트 (== 최대, 최소) -> 루트만 꺼내서 정렬시키는 알고리즘 : 항상 일정한 효율을 보여줌
//이외는 일반적으로 퀵정렬을 쓴다. (기준값을 잘 골라야 한다는 조건이 있음)
*/
