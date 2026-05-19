using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algorytm_genetyczny
{
    public class Individual
    {
        private int[] chromosome;
        private int value;
        public Individual(int[] solution, int[] instancja)
        {
            chromosome = solution;
            int m = chromosome.Length;
            int k = instancja.Length;
            int[] currentInstance = new int[k];
            int idx = 0;

            // Wyliczanie wszystkie odległości (D') z rozwiązania
            for (int i = 0; i < m; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    currentInstance[idx] = chromosome[j] - chromosome[i];
                    idx++;
                }
            }

            Array.Sort(currentInstance);

            // liczenie część wspólną multizbiorów
            int score = 0;
            int pTarget = 0;  // Wskaźnik na instancję z generatora
            int pCurrent = 0; // Wskaźnik na instancję osobnika

            while (pTarget < k && pCurrent < k)
            {
                if (instancja[pTarget] == currentInstance[pCurrent])
                {
                    // Dopasowanie znalezione
                    score++;
                    pTarget++;
                    pCurrent++;
                }
                else if (instancja[pTarget] < currentInstance[pCurrent])
                {
                    // Wartość z generatora jest mniejsza, więc przesuwamy wskaźnik docelowy
                    pTarget++;
                }
                else
                {
                    // Wartość z chromosomu jest mniejsza, więc przesuwamy wskaźnik chromosomu
                    pCurrent++;
                }
            }

            value = score; // maksymalnie k
        }
        public int Value
        {
            get { return value; }
        }
        public int[] Chromosome
        {
            get { return chromosome; }
        }
    }
    public class Metaheuristics
    {
        private int[] instance;
        private Individual? best_individual;
        private int m;
        public Metaheuristics(int[] current_instance)
        {
            instance = current_instance;
            int k = current_instance.Length;
            m = (1 + ((int)(Math.Sqrt(1 + 8 * k)))) / 2;
        }

        private Individual[] First_population(int population_size, int c_random, int i_random)
        {
            if (c_random + i_random > 100 || c_random < 0 || i_random < 0)
            {
                throw new ArgumentException("Składowe losowe (całkowicie losowe i losowane z instancji) muszą być w przedziale 0-100 i ich suma nie może przekroczyć 100%.");
            }
            if (population_size < 0)
            {
                throw new ArgumentException("Wielkość populacji musi być większa od 0");
            }
            int completely_random = (int)Math.Round((c_random / 100.0) * population_size, MidpointRounding.AwayFromZero);
            int instance_random = (int)Math.Round((i_random / 100.0) * population_size, MidpointRounding.AwayFromZero);
            int greedy = population_size - completely_random - instance_random;

            Individual[] population = new Individual[population_size];
            int maxLength = instance[instance.Length - 1];
            // wyznaczanie całkowicie losowej części populacji
            for (int i = 0; i < completely_random; i++)
            {
                int[] solution = new int[m];
                solution[0] = 0;

                List<int> sol_tab = new List<int>();
                for (int j = 1; j < m; j++)
                {
                    int sol = Random.Shared.Next(1, maxLength + 1); // zakres od 1 do największej odległości w instancji
                    if (sol_tab.Contains(sol))
                    {
                        j--;
                        continue;
                    }
                    solution[j] = sol;
                    sol_tab.Add(sol);
                }
                Array.Sort(solution);
                population[i] = new Individual(solution, instance);
            }

            // wyznaczanie osobników losowanych z wartości z instancji
            for(int i = completely_random; i < completely_random + instance_random; i++)
            {
                int[] solution = new int[m];
                solution[0] = 0;
                solution[m-1] = maxLength;

                List<int> sol_tab = new List<int> { 0, maxLength };
                List<int> index_tab = new List<int>();

                int no_unique = 0; //licznik nieudanych losowań unikalnych wartości
                bool unique = true; 
                for (int j = 1; j < m-1; j++)
                {
                    //gdy w instancji niewystarczająco unikatowych wartości - całkowicie losowe
                    if (no_unique > instance.Length)
                    {
                        unique = false;
                    }

                    int sol;

                    if (unique)
                    {
                        int index = Random.Shared.Next(0, instance.Length);
                        if(index_tab.Contains(index)) //czy indeks już wylosowany
                        {
                            j--;
                            no_unique++;
                            continue;
                        }
                        sol = instance[index];
                        index_tab.Add(index);
                    }
                    else
                    {
                        sol = Random.Shared.Next(1, maxLength + 1);
                    }

                    if (sol_tab.Contains(sol)) //sprawdzanie unikalności
                    {
                        j--;
                        no_unique++;
                        continue;
                    }

                    solution[j] = sol;
                    sol_tab.Add(sol);
                    no_unique = 0;
                }
                Array.Sort(solution);
                population[i] = new Individual(solution, instance);
            }

            //wyznaczanie zachłannej części populacji 
            for(int i = completely_random + instance_random; i < population_size; i++)
            {
                int[] solution = new int[m];
                solution[0] = 0;
                solution[m - 1] = maxLength;

                List<int> sol_tab = new List<int> { 0, maxLength };
                List<int> index_tab = new List<int>();

                int no_unique = 0; //licznik nieudanych losowań unikalnych wartości
                bool unique = true;

                List<int> noValids = new List<int>();
                int validCounter = 0;

                for (int j = 1; j < m - 1; j++)
                {
                    //gdy w instancji niewystarczająco unikatowych wartości - całkowicie losowe
                    if (no_unique > instance.Length)
                    {
                        unique = false;
                    }

                    int sol;

                    if (unique)
                    {
                        int index = Random.Shared.Next(0, instance.Length);
                        if (index_tab.Contains(index)) //czy indeks już wylosowany
                        {
                            j--;
                            no_unique++;
                            continue;
                        }
                        sol = instance[index];
                        index_tab.Add(index);
                    }
                    else
                    {
                        sol = Random.Shared.Next(1, maxLength + 1);
                    }

                    if (sol_tab.Contains(sol)) //sprawdzanie unikalności
                    {
                        j--;
                        no_unique++;
                        continue;
                    }

                    //sprawdzanie czy odległości istnieją w instancji
                    if (unique)
                    {
                        bool isValid = true;

                        //sprawdzamy odległości do wszystkich już wstawionych punktów (od 0 do j-1)
                        for (int k = 0; k < j; k++)
                        {
                            int distance = Math.Abs(sol - solution[k]);

                            // Array.BinarySearch jest szybkie. Zwraca wartość < 0, jeśli nie ma elementu
                            if (Array.BinarySearch(instance, distance) < 0)
                            {
                                isValid = false;
                                break;
                            }
                        }

                        //sprawdzamy odległość do maxLength (koniec)
                        if (isValid)
                        {
                            int distanceToMax = Math.Abs(maxLength - sol);
                            if (Array.BinarySearch(instance, distanceToMax) < 0)
                            {
                                isValid = false;
                            }
                        }

                        if (!isValid)
                        {

                            if (validCounter <= instance.Length)
                            {
                                noValids.Add(sol);
                                validCounter++;
                                j--;
                                continue;
                            }
                            else
                            {
                                noValids.RemoveAll(x => sol_tab.Contains(x)); //jeśli już jest taki to usuwamy (unikalne wartości w tablicy)
                                if (noValids.Count > 0)
                                {
                                    int randomIndex = Random.Shared.Next(0, noValids.Count);
                                    sol = noValids[randomIndex];
                                    noValids.RemoveAt(randomIndex);

                                }
                            }
                        }
                    }

                    solution[j] = sol;
                    sol_tab.Add(sol);
                    no_unique = 0;
                    validCounter = 0;
                }

                Array.Sort(solution);
                population[i] = new Individual(solution, instance);
            }

            return population;
        }
        private Individual Crossover(Individual parent1, Individual parent2)
        {
            int[] cross1 = parent1.Chromosome;
            int[] cross2 = parent2.Chromosome;
            int[] hybrid = new int[m];
            hybrid[0] = 0;

            HashSet<int> common_genes = new HashSet<int>();
            HashSet<int> rest_genes = new HashSet<int>();
            for (int i = 1; i < m; i++)
            {
                common_genes.Add(cross1[i]);
                rest_genes.Add(cross1[i]);
            }

            common_genes.IntersectWith(cross2); // część wspólna zbiorów
            rest_genes.SymmetricExceptWith(cross2); // elementy nie wspólne
            rest_genes.Remove(0); // usunięcie 0 pochodzącego z cross2

            // konwersja HaschSet do listy aby losować
            List<int> rest_genes_list = rest_genes.ToList();

            int currentIndex = 1;

            // Bezpośrednie wstawienie
            foreach (int gene in common_genes)
            {
                hybrid[currentIndex] = gene;
                currentIndex++;
            }
            while (currentIndex < m)
            {
                int randomIndex = Random.Shared.Next(0, rest_genes_list.Count);
                hybrid[currentIndex] = rest_genes_list[randomIndex];

                // zamist rest_genes_list.RemoveAt(randomIndex);
                int lastIndex = rest_genes_list.Count - 1;
                rest_genes_list[randomIndex] = rest_genes_list[lastIndex];
                rest_genes_list.RemoveAt(lastIndex);

                currentIndex++;
            }

            Array.Sort(hybrid);

            Individual child = new Individual(hybrid, instance);
            return child;
        }
        private Individual Mutate(Individual individual, int random_mutation)
        {
            int[] mutated_chromosome = (int[])individual.Chromosome.Clone();
            HashSet<int> hash_chromosome = new HashSet<int>(mutated_chromosome);
            int mutate_index = Random.Shared.Next(1, m);

            bool mutation_success = false;


            int type_draw = Random.Shared.Next(0, 100);

            if (type_draw >= random_mutation)
            {
                int startIdx = Random.Shared.Next(0, instance.Length);
                for (int i = 0; i < instance.Length; i++)
                {
                    // Przeszukiwanie liniowe z zawijaniem (modulo) - sprawdza całą tablicę raz
                    int currentIdx = (startIdx + i) % instance.Length;
                    int candidate = instance[currentIdx];

                    // Omijamy zero i geny już obecne w chromosomie
                    if (candidate != 0 && !hash_chromosome.Contains(candidate))
                    {
                        mutated_chromosome[mutate_index] = candidate;
                        mutation_success = true;
                        break;
                    }
                }
            }

            if (!mutation_success || type_draw < random_mutation)
            {
                int maxVal = instance[instance.Length - 1];
                int startVal = Random.Shared.Next(1, maxVal + 1);

                for (int i = 0; i < maxVal; i++)
                {
                    // Przeszukiwanie liniowe od losowego punktu w całym dopuszczalnym zakresie
                    int candidate = 1 + (startVal + i - 1) % maxVal;

                    if (!hash_chromosome.Contains(candidate))
                    {
                        mutated_chromosome[mutate_index] = candidate;
                        mutation_success = true;
                        break;
                    }
                }
            }
            // jeśli mutacja niemożliwa, zwracany chromosom bez zmian

            if (mutation_success)
            {
                Array.Sort(mutated_chromosome);
            }

            Individual mutated_individual = new Individual(mutated_chromosome, instance);
            return mutated_individual;
        }
        private Individual Tournament(Individual[] population, int tournament_size)
        {
            Individual bestCandidate = population[Random.Shared.Next(0, population.Length)];

            for (int i = 1; i < tournament_size; i++)
            {
                int randomIndex = Random.Shared.Next(0, population.Length);
                Individual challenger = population[randomIndex];

                if (challenger.Value > bestCandidate.Value)
                {
                    bestCandidate = challenger;
                }
            }

            return bestCandidate;
        }
        public Individual Evolve(int population_size, int c_random, int i_random, int random_mutation, int mutation_chance, int tournament_size, int time, Func<bool> isPaused, Func<bool> isStopped, Action<int, int> reportProgress)
        {
            Individual[] population = First_population(population_size, c_random, i_random);

            best_individual = population[0];
            for (int i = 1; i < population_size; i++)
            {
                if (population[i].Value > best_individual.Value)
                {
                    Individual new_best = population[i];
                    population[i] = population[0];
                    population[0] = new_best;
                    best_individual = new_best;
                }
            }

            Stopwatch sw = Stopwatch.StartNew();
            TimeSpan limit = TimeSpan.FromSeconds(time);

            while (sw.Elapsed < limit)
            {
                if (isStopped != null && isStopped())
                {
                    sw.Stop();
                    return best_individual;
                }

                if (isPaused != null && isPaused())
                {
                    sw.Stop();
                    while (isPaused())
                    {
                        Thread.Sleep(100);
                    }
                    sw.Start();
                }

                Individual[] new_population = new Individual[population_size];
                new_population[0] = best_individual;
                for (int i = 1; i < population_size; i++)
                {
                    Individual parent1 = Tournament(population, tournament_size);
                    Individual parent2 = Tournament(population, tournament_size);
                    Individual child = Crossover(parent1, parent2);
                    new_population[i] = child;

                    if (new_population[i].Value > best_individual.Value)
                    {
                        new_population[i] = new_population[0];
                        new_population[0] = child;
                        best_individual = child;
                    }
                }

                for (int i = 0; i < (int)Math.Round(population_size * mutation_chance / 100.0); i++)
                {
                    int randomIndex = Random.Shared.Next(1, population_size);
                    new_population[randomIndex] = Mutate(new_population[randomIndex], random_mutation);

                    if (new_population[randomIndex].Value > best_individual.Value)
                    {
                        Individual new_best = new_population[randomIndex];
                        new_population[randomIndex] = new_population[0];
                        new_population[0] = new_best;
                        best_individual = new_best;
                    }
                }

                population = new_population;

                if (reportProgress != null)
                {
                    int elapseTime = (int)sw.Elapsed.TotalSeconds;
                    reportProgress(elapseTime, best_individual.Value);
                }

                if (best_individual.Value == instance.Length)
                {
                    sw.Stop();
                    return best_individual;
                }
            }
            sw.Stop();

            return best_individual;
        }

        public int GetInstanceLength()
        {
            return instance.Length;
        }
    }
}
