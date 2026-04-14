using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytm_genetyczny
{
    public class Generator
    {
        private readonly int[] solution;
        private readonly int[] instance;
        public Generator(int k, int maxLength, int minDistance, int errors)
        {
            int m = (1 + ((int)(Math.Sqrt(1 + 8 * k)))) / 2;
            if ((m * (m - 1)) / 2 != k)
            {
                throw new ArgumentException($"Wartość k={k} jest nieprawidłowa dla problemu PDP.");
            }

            int requiredLength = (m - 1) * minDistance;
            if (maxLength < requiredLength)
            {
                throw new ArgumentException($"maxLength jest zbyt małe. Potrzeba minimum {requiredLength}.");
            }

            if (errors > k)
            {
                throw new ArgumentException($"Zbyt duża ilość błędów. Można maksymalnie {k}.");
            }

            solution = new int[m];
            solution[0] = 0;
            instance = new int[k];
            int ins = 0;

            int freeSpace = maxLength - ((m - 1) * minDistance);

            int[] randomOffsets = new int[m - 1];
            for (int i = 0; i < m - 1; i++)
            {
                randomOffsets[i] = Random.Shared.Next(0, freeSpace + 1);
            }

            Array.Sort(randomOffsets);

            for (int i = 1; i < m; i++)
            {
                solution[i] = randomOffsets[i - 1] + (i * minDistance);
            }

            for (int i = 0; i < solution.Length; i++)
            {
                for (int j = i + 1; j < solution.Length; j++)
                {
                    instance[ins] = solution[j] - solution[i];
                    ins++;
                }
            }

            List<int> correct_instance = new List<int>(instance);

            int zajeteLiczby = correct_instance.Distinct().Count();
            int maxPossibleErrors = solution[m - 1] - zajeteLiczby;

            if (errors > maxPossibleErrors)
            {
                throw new ArgumentException($"Dla wylosowanej mapy cięć można wprowadzić maksymalnie {maxPossibleErrors} unikalnych błędów (zażądano {errors}).");
            }

            List<int> index_tab = new List<int>();

            for (int i = 0; i < errors; i++)
            {
                int replace_index = Random.Shared.Next(0, k);

                if (index_tab.Contains(replace_index))
                {
                    i--;
                    continue;
                }

                int change = Random.Shared.Next(1, solution[m - 1] + 1);

                if (correct_instance.Contains(change))
                {
                    i--;
                    continue;
                }

                instance[replace_index] = change;
                index_tab.Add(replace_index);
            }
            Array.Sort(instance);
        }

        public int[] Get_Instance()
        {
            return instance;
        }
        public int[] Get_Solution()
        {
            return solution;
        }
    }
}

