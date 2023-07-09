namespace Sortari
{
    class Selection
    {
        public static int[] SelectionSort(int[] vector)
        {
            for (int i = 0; i < vector.Length - 1; i++)
            {
                int min = vector[i], pozMin = i;

                for (int j = i+1; j < vector.Length; j++)
                    if (vector[j] < min)
                    {
                        min = vector[j];
                        pozMin = j;
                    }
                
                int aux = vector[i];
                vector[i] = vector[pozMin];
                vector[pozMin] = aux;
            }

            return vector;
        }
    }
}