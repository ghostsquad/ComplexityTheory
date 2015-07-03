namespace ComplexityTheory.Test.MoqHelpers {
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Moq.Language.Flow;

    public static class MoqExtensions {
        #region Public Methods and Operators

        public static void ReturnsInOrder<T, TResult>(this ISetup<T, TResult> setup, params TResult[] results)
            where T : class {
            setup.Returns(new Queue<TResult>(results).Dequeue);
        }

        public static void ReturnsInOrder<T, TResult>(this ISetup<T, TResult> setup, params object[] results)
            where T : class {
            var queue = new Queue(results);
            setup.Returns(
                () => {
                    var result = queue.Dequeue();
                    if (result is Exception) {
                        throw result as Exception;
                    }

                    return (TResult)result;
                });
        }

        #endregion
    }
}