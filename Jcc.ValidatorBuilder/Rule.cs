namespace Jcc.ValidatorBuilder;

public readonly record struct Rule(
    string ruleName,
    bool isValid,
    string failedValidationMessage);