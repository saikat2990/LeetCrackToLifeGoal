namespace leetCrack
{

    public class Program
    {
        public static int NumSubarrayProductLessThanK(int[] nums, int k)
        {
           
            var right = 0;
            int count = 0;
            var added = new Queue<int>();
            var product = 1;
            while (right < nums.Length)
            {
                if (nums[right] < k)
                {
                    
                    count++;
                    added.Enqueue(nums[right]);
                    product *= nums[right];
                    while (product >= k)
                    {
                        product = product/added.Peek();
                        added.Dequeue();
                    }

                   
                    if(added.Count>2)
                        count += ((added.Count-1));
                    else if (added.Count == 2 && product<k) count++;
                }
                else
                {
                    added.Clear();
                    product = 1;
                }
                right++;
            }
            return count;
        }
        public static void Main(string[] args)
        {

            NumSubarrayProductLessThanK(new int[] { 10, 2, 2, 5, 4, 4, 4, 3, 7, 7 }, 289);
        }

       
    }
   
}