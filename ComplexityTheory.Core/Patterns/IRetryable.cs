namespace ComplexityTheory.Core.Patterns {
    using System.Collections.Generic;

    public interface IRetryable {
        #region Public Properties

        IDictionary<IRetryScenario, int> TriesUsing { get; set; }

        #endregion

        #region Public Methods and Operators

        void Cleanup(IRetryScenario scenario);

        void ExecuteWithContext(IRetryScenario scenario);

        #endregion
    }
}