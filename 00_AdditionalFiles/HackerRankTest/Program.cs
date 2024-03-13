namespace HackerRankTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var result = deleteProducts([1, 1, 5, 5], 2);
            //var result = deleteProducts([1, 2, 3, 1, 2, 2, 1], 2);



            Console.WriteLine(firstOccurrence("juliasamanthantjulia", "ant"));

            Console.ReadKey();
        }

        public static int deleteProducts(List<int> ids, int m)
        {
            var freqOfIDsMap = new Dictionary<int, int>();

            foreach (var id in ids)
            {
                if (freqOfIDsMap.ContainsKey(id))
                {
                    freqOfIDsMap[id]++;
                }
                else
                {
                    freqOfIDsMap[id] = 1;
                }
            }

            var sortedList = freqOfIDsMap.Values.OrderBy(x => x).ToList();

            var deletetion = 0;
            var idsDeleted = 0;
            foreach (var freq in sortedList)
            {
                if (deletetion + freq <= m)
                {
                    deletetion += freq;
                    idsDeleted++;
                }
                else
                {
                    break;
                }
            }

            return freqOfIDsMap.Count - idsDeleted;
        }


        public static int getMaxDeletions(string s)
        {
            int uCount = 0, dCount = 0, lCount = 0, rCount = 0;

            foreach (var instr in s)
            {
                switch (instr)
                {
                    case 'U':
                        uCount++;
                        break;
                    case 'D':
                        dCount++;
                        break;
                    case 'L':
                        lCount++;
                        break;
                    case 'R':
                        rCount++;
                        break;
                }
            }

            var minOfPossibleDeletetionUD = Math.Min(uCount, dCount);
            var minOfPossibleDeletetionLR = Math.Min(lCount, rCount);

            var totalDeletable = minOfPossibleDeletetionUD * 2 + minOfPossibleDeletetionLR * 2;

            return totalDeletable;
        }

        public static int firstOccurrence(string s, string x)
        {
            for (int i = 0; i <= s.Length - x.Length; i++)
            {
                var isMatch = true;

                for (int j = 0; j < x.Length; j++)
                {
                    if (x[j] != s[i + j] && x[j] != '*')
                    {
                        isMatch = false;
                        break;
                    }
                }

                if (isMatch)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
