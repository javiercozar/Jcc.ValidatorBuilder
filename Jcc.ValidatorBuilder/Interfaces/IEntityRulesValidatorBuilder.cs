using System.Linq.Expressions;

namespace Jcc.ValidatorBuilder.Interfaces;

public interface IEntityRulesValidatorBuilder<T> {
    IEntityRulesValidatorBuilder<T> AddRule(
        string ruleName,
        Expression<Func<T, bool>> condition,
        string failedValidationMessage);

    IEntityRulesValidator<T> Build();
}