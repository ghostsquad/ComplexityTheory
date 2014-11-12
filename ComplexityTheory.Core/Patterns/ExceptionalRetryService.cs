namespace ComplexityTheory.Core.Patterns {
    using System;

    public class ExceptionalRetryService : RetryServiceBase {
        public ExceptionalRetryService(RetryPolicyBase retryPolicyBase)
            : base(retryPolicyBase) {
        }

        public override void Execute(IRetryable retryable) {
            var scenarioRetries = this.GetScenarioRetriesDictionary();

            IRetryScenario currentScenario = null;
            bool doRetry;

            do {
                try {
                    doRetry = false;
                    if (currentScenario != null) {
                        scenarioRetries.Increment(currentScenario);
                    }
                    retryable.ExecuteWithContext(currentScenario);
                }
                catch (Exception exception) {
                    retryable.HealWithContext(currentScenario);
                    doRetry = this.TrySetRetryScenario(exception, ref currentScenario);

                    if (!doRetry) {
                        throw;
                    }
                }
            }
            while (doRetry);
        }
    }
}
