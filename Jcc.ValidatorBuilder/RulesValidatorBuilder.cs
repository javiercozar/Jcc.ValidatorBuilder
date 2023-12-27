using System.Linq.Expressions;
using Jcc.ValidatorBuilder.Interfaces;

namespace Jcc.ValidatorBuilder;

public class RulesValidatorBuilder<T> : IRulesValidatorBuilder<T> {
    private readonly List<Rule<T>> rules = [];

    private RulesValidatorBuilder() { }
    public static RulesValidatorBuilder<T> Create() => new();

    public IRulesValidatorBuilder<T> AddRule(string ruleName,
                                                   Expression<Func<T, bool>> condition,
                                                   string failedValidationMessage = "") {
        if (condition.CanReduce)
            condition = (Expression<Func<T, bool>>)condition.Reduce();

        var conditionFunc = condition.Compile();

        rules.Add(item: new Rule<T>(ruleName, conditionFunc, failedValidationMessage));

        return this;
    }

    public IRulesValidator<T> Build() => new RulesValidator<T>(rules);
}