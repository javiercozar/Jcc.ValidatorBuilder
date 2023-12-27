using System.Linq.Expressions;

namespace Jcc.ValidatorBuilder.Interfaces;

public interface IRulesValidatorBuilder<T> {
    IRulesValidatorBuilder<T> AddRule(
        string ruleName,
        Expression<Func<T, bool>> condition,
        string failedValidationMessage);

    IRulesValidator<T> Build();
}