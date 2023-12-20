namespace Jcc.ValidatorBuilder;

public class RulesErrorMessages : Dictionary<string, string> {
    public void TryAddRuleErrorMessage(string ruleName, string errorMessage) => TryAdd(ruleName, errorMessage);
}