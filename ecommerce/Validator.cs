using System;
using System.Text.RegularExpressions;

namespace ecommerce
{
    public static class Validator
    {
        #region Consts

        private const string CAPITAL_LETTER_AND_DOT_PATTERN = @"^[A-Z]{1}[.]{1}$";
        private const string CAPITAL_WORD_WITHOUT_DOT_PATTERN = @"^[A-Z][a-z]{1,}(?!\.)$";

        #endregion Consts

        #region Public Methods

        /// <summary>
        /// Valid Names and LastName.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ValidName(string name)
        {
            try
            {
                if (name is null)
                {
                    return false;
                }

                string[] words = name.Split(" ");

                // Solo habrán 2 o 3 términos en el ingreso. Es decir, o dos nombres y un apellido o solo un nombre y un apellido
                if (words.Length <= 1 || words.Length > 3)
                {
                    return false;
                }

                string firstName = words[0];
                string secondName = words[1];
                string lastName = words[^1];

                // e) El apellido siempre debe ser una palabra completa
                if (!lastName.IsCapitalWordWithoutDot())
                {
                    return false;
                }

                // Solo un nombre y un apellido
                if (words.Length == 2 && (firstName.IsCapitalLetterWithDot() || firstName.IsCapitalWordWithoutDot()))
                {
                    return true;
                }

                // Si se ingresan dos nombres y un apellido, los dos primeros pueden ser iniciales, o solo el
                // segundo.Nunca puede ser una inicial el primer nombre y no el segundo
                if ((firstName.IsCapitalLetterWithDot() && secondName.IsCapitalLetterWithDot()) ||
                    (firstName.IsCapitalWordWithoutDot() && secondName.IsCapitalLetterWithDot()))
                {
                    return true;
                }

            }
            catch (Exception)
            {

                throw;
            }

            return false;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// b) Una inicial es solo un caracter mas un punto
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsCapitalLetterWithDot(this string value) => MatchPattern(value, CAPITAL_LETTER_AND_DOT_PATTERN);


        /// <summary>
        /// c) Una palabra se comprende de 2 o mas caracteres, sin punto.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsCapitalWordWithoutDot(this string value) => MatchPattern(value, CAPITAL_WORD_WITHOUT_DOT_PATTERN);


        /// <summary>
        /// Check if the value match with the pattern using Regex expression.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private static bool MatchPattern(string value, string pattern) => new Regex(pattern).IsMatch(value);

        #endregion Private Methods

    }
}
