using System;

namespace Product_of_Array_Except_Self
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 2, 3, 4, 5 };
            Console.WriteLine(string.Join(",", ProductExceptSelf(nums)));
        }

        // 2, 3, 4, 5 // answer = 60, 40, 30, 24
        // L = 1,2,6,24 // replace the left most element with 1 and for each next element multiply with the before element
        // R = 60,20,5,1 // replace the right most element with 1 and for each element before multiply with the next element
        // O = 60, 40, 30, 24 // multiply both L * R for the result
        static int[] ProductExceptSelf(int[] nums)
        {
            int length = nums.Length;
            int[] L = new int[length];
            int[] R = new int[length];
            L[0] = 1; // first element as 1.
            R[length - 1] = 1; // last element as 1.

            for (int i = 1; i < length; i++)
            {
                L[i] = nums[i - 1] * L[i - 1];
            }

            for (int i = length - 2; i >= 0; i--)
            {
                R[i] = R[i + 1] * nums[i + 1];
            }

            for (int i = 0; i < length; i++)
            {
                nums[i] = L[i] * R[i];
            }

            return nums;
        }

        static int[] ProductExceptSelf_OneArray(int[] nums)
        {
            int length = nums.Length;
            int[] answer = new int[length];

            answer[0] = 1;
            for (int i = 1; i < length; i++)
            {
                answer[i] = answer[i - 1] * nums[i - 1];
            }

            int right = 1;
            for(int i = length -1; i >= 0; i--)
            {
                answer[i] *= right;
                right *= nums[i];
            }

            return answer;
        }
    }
}
