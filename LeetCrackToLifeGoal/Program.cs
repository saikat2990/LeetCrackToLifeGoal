namespace leetCrack
{

    public class Program
    {

        public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            var firstAvaiable = new List<int>();
            var answer = new List<List<int>>();
            foreach (var range in firstList)
            {
                for (int i = range[0]; i <= range[1]; i++)
                {
                    firstAvaiable.Add(i);
                }
            }
            var createRange = new List<int>();
            foreach (var range in secondList)
            {
                for (int i = range[0]; i <= range[1]; i++)
                {
                    if (firstAvaiable.Contains(i) && createRange.Count == 0)
                    {
                       createRange.Add(i);
                    }

                    if (!firstAvaiable.Contains(i) && createRange.Count > 0)
                    {
                        createRange.Add(i-1);
                        var newArr = new List<int>();
                        createRange.ForEach(x=>newArr.Add(x));
                        answer.Add(newArr);
                        createRange.Clear();
                    }
                }

                if (createRange.Count == 1)
                {
                    createRange.Add(createRange[0]);
                    var newArr = new List<int>();
                    createRange.ForEach(x => newArr.Add(x));
                    answer.Add(newArr);
                    createRange.Clear();
                }
            }
            var answerData = new int[answer.Count][];
            for (int i = 0; i < answer.Count; i++)
            {
                answerData[i] = answer[i].ToArray();
            }

            return answerData;
        }
        public static void Main(string[] args)
        {

           
        }

       
    }
   
}