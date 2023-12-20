using Jcc.ValidatorBuilder.Interfaces;

namespace Jcc.ValidatorBuilder;

public class EntityValidatorRules(IEnumerable<Rule> rules) : IEntityValidatorRules {
    public EntityValidationRulesResult Validate() {
        var isValid = !rules.Any(rule => rule.isValid is false);

        var ruleErrorMessages = new RulesErrorMessages();
        foreach (var rule in rules) {
            ruleErrorMessages.TryAddRuleErrorMessage(rule.ruleName, rule.failedValidationMessage);
        }


        return new EntityValidationRulesResult(isValid, ruleErrorMessages);
    }
}