namespace ComplexityTheory.Core.Patterns {
    public interface IRetryable {
        #region Public Methods and Operators

        void HealWithContext(IRetryScenario scenario);

        void ExecuteWithContext(IRetryScenario scenario);

        #endregion
    }
}