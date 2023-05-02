using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    internal class Average
    {
        public double Averages(int[] salary)
        {
            double data = 0.0;
            Array.Sort(salary);
            for (int i = 1; i < salary.Length - 1; i++)
            {
                data += salary[i];
            }

            data = data / (salary.Length - 2);
            return data;
        }
    }
}
