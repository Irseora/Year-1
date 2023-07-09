namespace Sortari
{
    class Insertion
    {
        public static int[] InsertionSort(int[] vector)
        {
            for (int i = 1; i < vector.Length; i++)
            {
                int aux = vector[i];
                int j = i - 1;

                while (j >= 0 && vector[j] > aux)
                {
                    vector[j + 1] = vector[j];
                    j--;
                }

                vector[j + 1] = aux;
            }

            return vector;
        }
    }
}