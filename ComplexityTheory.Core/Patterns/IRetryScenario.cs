namespace ComplexityTheory.Core.Patterns {
    public interface IRetryScenario {
        #region Public Properties

        int MaxTries { get; set; }

        #endregion

        #region Public Methods and Operators

        bool IsProcessEligibleForRetry<T>(T stateObject);

        #endregion
    }
}