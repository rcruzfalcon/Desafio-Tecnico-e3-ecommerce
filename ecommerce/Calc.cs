using System;


namespace ecommerce
{
    public static class Calc
    {
        #region Public Methods

        /// <summary>
        /// Recuce two number to min expression.
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        /// <returns></returns>
        public static string Reduce(int numerator, int denominator)
        {
            try
            {
                // Div by zero
                if (denominator == 0)
                {
                    return null;
                }

                // zero
                if (numerator == 0)
                {
                    return "0";
                }

                // Si una fracción puede ser transformada en entero, también debe tenerse en cuenta
                if (numerator % denominator == 0)
                {
                    return (numerator / denominator).ToString();
                }

                // assign an integer to the gcd value
                int gcdNum = gcd(numerator, denominator);
                if (gcdNum != 0)
                {
                    numerator /= gcdNum;
                    denominator /= gcdNum;
                }

                if (denominator < 0)
                {
                    denominator *= -1;
                    numerator *= -1;
                }
            }
            catch (Exception exp)
            {
                throw new InvalidOperationException("Cannot reduce Fraction: " + exp.Message);
            }

            return $"{numerator}/{denominator}";
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Greatest Common Divisor
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        /// <returns></returns>
        private static int gcd(int numerator, int denominator)
        {
            // assigned x and y to the  Numerator/Denominator, as well as an  
            // empty integer, this is to make code more simple and easier to read
            int x = Math.Abs(numerator);
            int y = Math.Abs(denominator);
            int m;

            // check if numerator is greater than the denominator, 
            // make m equal to denominator if so
            if (x > y)
            {
                m = y;
            }
            else
            {
                // if not, make m equal to the numerator
                m = x;
            }

            // assign i to equal to m, make sure if i is greater
            // than or equal to 1, then take away from it
            for (int i = m; i >= 1; i--)
            {
                if (x % i == 0 && y % i == 0)
                {
                    //return the value of i
                    return i;
                }
            }

            return 1;
        }

        #endregion Private Methods
    }
}
