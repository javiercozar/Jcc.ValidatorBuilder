namespace Jcc.ValidatorBuilder;

public readonly record struct Rule<T>(
    string ruleName,
    Func<T, bool> condition,
    string failedValidationMessage);