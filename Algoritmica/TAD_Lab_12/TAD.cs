namespace TAD_Lab_12
{
    public abstract class TAD
    {
        #region Values

        int[] values;
        int bufferSize;
        int k;

        #endregion

        #region Constructors

        public TAD(int bufferSize)
        {
            k = 0;
            values = new int[0];
            this.bufferSize = bufferSize;
        }
        
        #endregion

        #region Methods

        protected abstract void Push(int x);

        protected abstract int Pop();

        // -----------------------------------------------------------------------

        protected void PushBegin(int x)
        {
            if (k >= values.Length - 1)
            {
                int[] temp = new int[values.Length + bufferSize];

                for (int i = 0; i < k; i++)
                    temp[i + 1] = values[i];

                temp[0] = x;
                k++;
                values = temp;
            }
            else
            {
                for (int i = k; i >= 0; i--)
                    values[i + 1] = values[i];
                values[0] = x;
                k++;
            }
        }

        protected int PopBegin()
        {
            int toRet = values[0];
            k--;

            if (k == values.Length - bufferSize)
            {
                int[] temp = new int[values.Length - bufferSize];

                for (int i = 0; i < k; i++)
                    temp[i] = values[i + 1];
                values = temp;
            }
            else
            {
                for (int i = 0; i < k; i++)
                    values[i] = values[i + 1];
                values[k] = 0;
            }

            return toRet;
        }

        protected void PushEnd(int x)
        {
            if (k <= values.Length - 1)
            {
                values[k] = x;
                k++;
            }
            else
            {
                int[] temp = new int[values.Length + bufferSize];

                for (int i = 0; i < k; i++)
                    temp[i] = values[i];

                temp[k] = x;
                k++;
                values = temp;
            }
        }

        protected int PopEnd()
        {
            int toRet = values[k - 1];
            k--;

            if (k == values.Length - bufferSize)
            {
                int[] temp = new int[values.Length - bufferSize];

                for (int i = 0; i < k; i++)
                    temp[i] = values[i];

                values = temp;
            }
            else
            {
                values[k] = 0;
            }

            return toRet;
        }

        protected string View()
        {
            string toRet = "";

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < 9)
                    toRet += " " + values[i] + " ";
                else
                    toRet += values[i] + " ";
            }

            return toRet;
        }

        #endregion
    }
}