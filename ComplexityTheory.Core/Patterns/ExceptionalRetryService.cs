namespace ComplexityTheory.Core.Patterns {
    using System;
    using System.Collections.Generic;

    public class ExceptionalRetryService : RetryServiceBase {
        public ExceptionalRetryService(RetryPolicyBase retryPolicyBase)
            : base(retryPolicyBase) {
        }

        public override void Execute(IRetryable retryable) {
            retryable.TriesUsing = new Dictionary<IRetryScenario, int>();
            if (this.RetryPolicyBase != null && this.RetryPolicyBase.Scenarios != null) {
                foreach (var scenario in this.RetryPolicyBase.Scenarios) {
                    if (scenario != null) {
                        retryable.TriesUsing.Add(scenario, 0);
                    }
                }
            }

            IRetryScenario currentScenario = null;
            bool doRetry = false;

            do {
                try {
                    doRetry = false;
                    if (currentScenario != null) {
                        retryable.TriesUsing.Increment(currentScenario);
                    }
                    retryable.ExecuteWithContext(currentScenario);
                }
                catch (Exception exception) {
                    retryable.Cleanup(currentScenario);
                    if (this.RetryPolicyBase != null && this.RetryPolicyBase.Scenarios != null) {
                        foreach (var scenario in this.RetryPolicyBase.Scenarios) {
                            if (scenario.IsProcessEligibleForRetry(exception)) {
                                currentScenario = scenario;
                                doRetry = true;
                                break;
                            }
                        }
                    }

                    if (!doRetry) {
                        throw;
                    }
                }
            }
            while (doRetry);
        }
    }
}
