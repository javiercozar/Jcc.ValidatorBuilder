using Jcc.ValidatorBuilder.Interfaces;

namespace Jcc.ValidatorBuilder;

public sealed class RulesValidator<T>(IEnumerable<Rule<T>> rules) : IRulesValidator<T> {
    public ValidationRulesResult Validate(T entity) {
        var ruleResults = rules.Select(p => p.condition(entity)).ToArray();
        var isValid = ruleResults.Any(rule => rule is false);
        var ruleErrorMessages = getRulesErrorMessages();

        return new ValidationRulesResult(isValid, ruleErrorMessages);
    }

    private RulesErrorMessages getRulesErrorMessages() {
        var ruleErrorMessages = new RulesErrorMessages();

        foreach (var rule in rules) {
            ruleErrorMessages.TryAddRuleErrorMessage(
                ruleName: rule.ruleName,
                errorMessage: rule.failedValidationMessage);
        }

        return ruleErrorMessages;
    }
}