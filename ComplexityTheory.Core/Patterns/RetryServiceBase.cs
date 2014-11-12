namespace ComplexityTheory.Core.Patterns {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class RetryServiceBase {
        protected RetryServiceBase(RetryPolicyBase retryPolicy) {
            this.RetryPolicy = retryPolicy;
        }

        public RetryPolicyBase RetryPolicy { get; protected set; }

        public abstract void Execute(IRetryable retryable);

        protected bool TrySetRetryScenario<T>(T stateObject, ref IRetryScenario currentScenario) {
            currentScenario = null;
            if (this.RetryPolicy != null && this.RetryPolicy.Scenarios != null) {
                foreach (var scenario in this.RetryPolicy.Scenarios) {
                    if (scenario.IsProcessEligibleForRetry(stateObject)) {
                        currentScenario = scenario;
                        return true;
                    }
                }
            }

            return false;
        }

        protected IDictionary<IRetryScenario, int> GetScenarioRetriesDictionary() {
            var scenarioRetries = new Dictionary<IRetryScenario, int>();
            if (this.RetryPolicy != null && this.RetryPolicy.Scenarios != null) {
                foreach (var scenario in this.RetryPolicy.Scenarios) {
                    if (scenario != null) {
                        scenarioRetries.Add(scenario, 0);
                    }
                }
            }

            return scenarioRetries;
        }
    }
}
