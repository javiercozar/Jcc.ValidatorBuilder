using System.Linq.Expressions;

namespace Jcc.ValidatorBuilder.Interfaces;

public interface IValidatorRulesBuilder<T> {
    IValidatorRulesBuilder<T> AddRule(
        string ruleName,
        Expression<Func<T, bool>> predicate,
        string failedValidationMessage);

    IEntityValidatorRules Build();
}