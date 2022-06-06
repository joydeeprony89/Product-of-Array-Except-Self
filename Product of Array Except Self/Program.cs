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

        static int[] ProductExceptSelf_OneArray(int[] nums)
        {
           // we can solve this in O(n) time using prefix and postfix array
          // eaxmple [1, 2, 3, 4]
          // prefix array = 1, 1, 2, 6 (prefix for any array no is previous all nos multiplications)
          // before 1 we dont have anything so consider it as 1
          // before 2 only 1 and 1 * 1 = 1
          // before 3 we have 2 * 1 = 2
          // for 4 we have 1* 2 * 3 = 6
          // now calculate postfix array = 24, 12, 4, 1
          // before 4 we dont have anything so consider it as 1
          // before 3 only 4 and 4 * 1 = 4
          // before 2 we have 3 * 4 = 12
          // for 1 we have 2 * 3 * 4 = 24
          // now product of array num except self would be, mult of prefix and postfix
          // but the only drawback  of the avobe approach is memory - we need two extra array and also the result array
          // to improve the memory issue, we can have use the result array to store the prefix initially and again loop nums from the end on the fly calculate the prefix * postfix and update the result
          int[] result = new int[nums.Length];
          // 1 we are initializing as there are no more nos present before first index no
          result[0] = 1;

          // generation of prefix
          for(int i = 1; i < nums.Length; i++){
            result[i] = nums[i - 1] * result[i -1];
          }

          // on the fly calculate the prefix * postfix and update the result

          // 1 because there are no more nos present after the last index element
          int postfix = 1;
          for(int i = nums.Length -1; i >=0; i--){
            result[i] = result[i] * postfix;
            // update the postfix
            postfix = postfix * nums[i];
          }

          return result;
        }
    }
}
