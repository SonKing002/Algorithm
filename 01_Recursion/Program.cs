using System;
using System.Runtime.InteropServices;

public class Program
{
    /// <summary>
    /// 팩토리얼을 구하는 재귀 함수
    /// </summary>
    /// <param name="number">들어가는 변수: 점점 줄어듦</param>
    /// <returns></returns>
    static int Factorial(int number)
    {
        //팩토리얼 정의에 따라 0인 경우 : 1 반환
        if (number == 0)
        {
            return 1;
        }
        Console.WriteLine(number);
        //팩토리얼 호출
        return number * Factorial(number - 1);
    }

    /// <summary>
    /// 실패 성공에 대한 정의
    /// </summary>
    public enum Result 
    { 
        Success, Fail
    }
    /// <summary>
    /// 이진 탐색 재귀 함수
    /// </summary>
    /// <param name="arr">데이터 컨테이너 (탐색하려는 값이 들어있는 배열 또는 리스트):정렬이 되어있어야 한다</param>
    /// <param name="searchTarget">탐색하려는 목표 값</param>
    /// <param name="low">하위 범위를 나타내는 수</param>
    /// <param name="high">상위 범위를 나타내는 수</param>
    /// <returns></returns>
    static int BinarySearch(int[] arr, int searchTarget, int low, int high, ref int count)
    {
        Console.WriteLine($" {++count}번 돌림");
        #region 지양
        //실패하는 경우
        if (low > high)
        {
            //오류 코드 반환
            return -1;
        }
        #endregion

        //중간 인덱스 구하기
        int mid = (low + high)/2;
        //갯수 따지고 중간
        //홀수 : 처음과 끝을 더한 인덱스의 나누기 2 한 인덱스
        

        //탐색에 성공하는 경우
        if (arr[mid] == searchTarget)
        {
            return mid;
        }
        //찾으려는 인덱스보다 작다면
        if (arr[mid] < searchTarget)
        {
            //작음 인덱스를 밀어준다.
            return BinarySearch(arr, searchTarget, mid + 1, high, ref count);
        }

        //크다면 큰 인덱스를 하나 밀어준다.
        return BinarySearch(arr, searchTarget, low, mid - 1, ref count);
    }

    static void Main(string[] args)//arguments 인자들 : 옛날부터 써 오던 명칭
    {
        Console.WriteLine("팩토리얼 알고리즘");
        #region 팩토리얼 예제코드
        //구하기
        int testNumber = 5;
        int result = Factorial(testNumber);

        //세번 확인 (짠거 확인 -> 구동 확인)
        Console.WriteLine($"{testNumber}의 팩토리얼 결과는 {result}");

        //종료 대기
        Console.ReadKey();
        #endregion

        Console.WriteLine("\n이진탐색 알고리즘");
        #region 이진 탐색 예제코드
        // 이진 탐색.
        int[] arr = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
        int target = 56;
        int  count = 0;
        int result2 = BinarySearch(arr, target, 0, arr.Length - 1, ref count);
        
        Console.WriteLine("배열 요소");
        for(int i = 0; i < arr.Length; i++) 
        {
            Console.Write( $"{i}요소 값 : {arr[i]}, " );
        }

        Console.WriteLine();
        Console.WriteLine($"{count}번 재귀하였습니다.");

        if (result != -1)
        {
            Console.WriteLine($"{target} found at index {result2}");
        }

        else
        {
            Console.WriteLine($"{target} not found");
        }

        Console.ReadKey();
        #endregion
    }


}

#region 알고리즘

/* 알고리즘 용어
 * 인도 실크로드 무역상들이  무역, 환율, 대출, 이자... 등 문제를 해결하는 단계를 정의했는데 지금까지 사용하는 것 
 */

/*
 * 
 * 
 */
#endregion