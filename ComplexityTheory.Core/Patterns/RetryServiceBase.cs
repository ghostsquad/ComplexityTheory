namespace ComplexityTheory.Core.Patterns {
    using System.Collections.Generic;
    using System.Linq;

    public abstract class RetryServiceBase {
        protected RetryServiceBase(RetryPolicyBase retryPolicyBase) {
            this.RetryPolicyBase = retryPolicyBase;
        }

        public RetryPolicyBase RetryPolicyBase { get; protected set; }

        public abstract void Execute(IRetryable retryable);
    }
}
