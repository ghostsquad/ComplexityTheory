namespace ComplexityTheory.Core.Misc
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    ///     The conversions.
    /// </summary>
    public static class Conversions
    {
        #region Static Fields

        /// <summary>
        ///     The regex decimal.
        /// </summary>
        private static readonly Regex RegexDecimal = new Regex(@"^-?\d+(\.\d+)?$");

        /// <summary>
        ///     The regex digits.
        /// </summary>
        private static readonly Regex RegexDigits = new Regex(@"^-?\d+$");

        #endregion

        #region Enums

        /// <summary>
        ///     The conversion methods.
        /// </summary>
        public enum ConversionMethods
        {
            /// <summary>
            ///     The individual integers conversion method.
            /// </summary>
            IndividualIntegers,

            /// <summary>
            ///     The rounded method.
            /// </summary>
            Rounded
        }

        /// <summary>
        /// The math operations.
        /// </summary>
        private enum MathOperations
        {
            /// <summary>
            /// The addition.
            /// </summary>
            Addition, 

            /// <summary>
            /// The subtraction.
            /// </summary>
            Subtraction
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The string to long.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="long"/>.
        /// </returns>
        public static long StringToLong(string value)
        {
            return StringToLong(value, ConversionMethods.IndividualIntegers);
        }

        /// <summary>
        /// The string to long.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="conversionMethod">
        /// The conversion type.
        /// </param>
        /// <returns>
        /// The <see cref="long"/>.
        /// </returns>
        public static long StringToLong(string value, ConversionMethods conversionMethod)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");    
            }

            switch (conversionMethod)
            {
                case ConversionMethods.IndividualIntegers:
                    {
                        return IndividualIntegers(value);
                    }

                case ConversionMethods.Rounded:
                    {
                        return Rounded(value);
                    }                

                default:
                    {
                        throw new NotImplementedException(
                            string.Format("{0} Conversion Method is Not Supported.", conversionMethod));
                    }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Walks each character of a string, converting to a integer, and adding it's representation together
        ///     finally returning a long.
        ///     Example:
        ///     "123"
        ///     becomes
        ///     100 + 20 + 3
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="long"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// When the value contains characters that aren't digits (or a starting minus sign).
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// When the value is larger or smaller than what can be contained by a long value type.
        /// </exception>
        private static long IndividualIntegers(string value)
        {
            if (!RegexDigits.IsMatch(value))
            {
                throw new ArgumentException("Value must contain only digits (minus sign optional)");
            }

            bool isNegative = value[0] == '-';            

            MathOperations operation = isNegative ? MathOperations.Subtraction : MathOperations.Addition;
            int startPosition = isNegative ? 1 : 0;

            long newLong = 0;

            for (int i = startPosition; i < value.Length; i++)
            {
                // http://www.alanwood.net/demos/ansi.html
                // char     ansi/unicode number
                // 0        48
                // 1        49
                // ...
                // 9        57
                // therefore
                // example:
                // "9" = 57 - 48 = 9
                // "0" = 48 - 48 = 0
                var digit = (int)value[i] - 48;
                try
                {
                    checked
                    {
                        var exponent = (value.Length - 1) - i;
                        long operand = digit * (long)Math.Pow(10, exponent);
                        newLong = PerformOperation(newLong, operand, operation);
                    }
                }
                catch (OverflowException)
                {
                    throw new ArgumentOutOfRangeException(
                        "value", 
                        value, 
                        "Value is larger or smaller than what can be stored as a long.");
                }
            }

            return newLong;
        }

        /// <summary>
        /// Given a string the is in the format of a positive or negative integer or decimal number,
        ///     truncates the decimal places and returns the long value type representation.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="long"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// When the value does not represent an equivalent format to a positive or negative integer or decimal number.
        /// </exception>
        private static long Rounded(string value)
        {
            if (!RegexDecimal.IsMatch(value))
            {
                throw new ArgumentException("Value is not in a format that can be rounded to a long.");
            }

            return IndividualIntegers(value.Split(new[] { '.' })[0]);
        }        

        /// <summary>
        /// The perform operation.
        /// </summary>
        /// <param name="num1">
        /// The num 1.
        /// </param>
        /// <param name="num2">
        /// The num 2.
        /// </param>
        /// <param name="operation">
        /// The operation.
        /// </param>
        /// <returns>
        /// The <see cref="long"/>.
        /// </returns>
        private static long PerformOperation(long num1, long num2, MathOperations operation)
        {
            checked
            {
                if (operation == MathOperations.Addition)
                {
                    return num1 + num2;
                }

                return num1 - num2;
            }        
        }

        #endregion
    }
}