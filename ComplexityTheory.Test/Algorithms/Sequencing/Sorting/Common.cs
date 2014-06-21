namespace ComplexityTheory.Test.Algorithms.Sequencing.Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using FluentAssertions;

    using Xunit;

    /// <summary>
    ///     http://blog.ploeh.dk/2009/04/03/CreatingNumbersWithAutoFixture/
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class Common
    {
        #region Public Methods and Operators

        /// <summary>
        ///     http://stackoverflow.com/questions/557340/c-sharp-generic-list-t-how-to-get-the-type-of-t
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Type GetEnumeratedType<T>(this IEnumerable<T> obj)
        {
            return typeof(T);
        }

        public static void GivenEndPointsReversedList(Type sortClassType)
        {
            var expectedList = new List<int> { 1, 2, 3, 5 };
            var unsortedList = new List<int> { 5, 2, 3, 1 };
            var actualList = new List<int>(unsortedList);

            RunSortOnCollection(sortClassType, actualList);

            actualList.Should().Equal(expectedList);
        }

        public static void GivenReversedList(Type sortClassType)
        {
            var expectedList = new List<int> { 1, 2 };
            var unsortedList = new List<int> { 2, 1 };
            var actualList = new List<int>(unsortedList);

            RunSortOnCollection(sortClassType, actualList);

            actualList.Should().Equal(expectedList);
        }

        public static void GivenSinglePopulationListExpectNoChange(Type sortClassType)
        {
            var expectedList = new List<int> { 1 };
            var actualList = new List<int>(expectedList);

            RunSortOnCollection(sortClassType, actualList);

            actualList.Should().Equal(expectedList);
        }

        public static void GivenSortedList(Type sortClassType)
        {
            var expectedList = new List<int> { 1, 2, 3, 5 };
            var actualList = new List<int>(expectedList);

            RunSortOnCollection(sortClassType, actualList);

            actualList.Should().Equal(expectedList);
        }

        public static void GivenUnSortedList(Type sortClassType)
        {
            var expectedList = new List<int> { 1, 2, 3, 5 };
            var unsortedList = new List<int> { 5, 1, 3, 2 };
            var actualList = new List<int>(unsortedList);

            RunSortOnCollection(sortClassType, actualList);

            actualList.Should().Equal(expectedList);
        }

        public static void GivenUnSortedListWithDuplicates(Type sortClassType)
        {
            var expectedList = new List<int> { 1, 2, 2, 3, 5, 10 };
            var unsortedList = new List<int> { 5, 1, 10, 2, 3, 2 };
            var actualList = new List<int>(unsortedList);

            RunSortOnCollection(sortClassType, actualList);

            actualList.Should().Equal(expectedList);
        }

        /// <summary>
        ///     http://stackoverflow.com/questions/6204326/calling-generic-method-using-reflection-in-net
        /// </summary>
        /// <param name="classType"></param>
        /// <param name="collection"></param>
        public static void RunSortOnCollection(Type classType, IList<int> collection)
        {
            MethodInfo methodInfo =
                classType.GetMethods(BindingFlags.Public | BindingFlags.Static)
                    .FirstOrDefault(
                        m => m.IsDefined(typeof(ExtensionAttribute), false) && m.GetParameters().Length == 1);

            Assert.NotNull(methodInfo);

            MethodInfo genericMethod = methodInfo.MakeGenericMethod(collection.GetEnumeratedType());

            genericMethod.Invoke(null, new object[] { collection });
        }

        #endregion
    }
}