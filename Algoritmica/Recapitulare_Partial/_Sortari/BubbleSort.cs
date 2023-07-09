namespace Sortari
{
    class Bubble
    {
        public static int[] BubbleSort(int[] vector)
        {
            int passes = 0;
            bool done;

            do
            {
                done = true;

                for (int i = 0; i < vector.Length - 1 - passes; i++)
                {
                    if (vector[i] > vector[i + 1])
                    {
                        int aux = vector[i];
                        vector[i] = vector[i + 1];
                        vector[i + 1] = aux;

                        done = false;
                    }
                }

                passes++;
            }while (!done);

            return vector;
        }
    }
}