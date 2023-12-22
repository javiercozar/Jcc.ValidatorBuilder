using System.Linq.Expressions;
using Jcc.ValidatorBuilder.Interfaces;

namespace Jcc.ValidatorBuilder;

public class EntityEntityRulesValidatorBuilder<T> : IEntityRulesValidatorBuilder<T> {
    private readonly List<Rule<T>> rules = [];

    private EntityEntityRulesValidatorBuilder() { }
    public static EntityEntityRulesValidatorBuilder<T> Create() => new();

    public IEntityRulesValidatorBuilder<T> AddRule(string ruleName,
                                                   Expression<Func<T, bool>> condition,
                                                   string failedValidationMessage = "") {
        if (condition.CanReduce)
            condition = (Expression<Func<T, bool>>)condition.Reduce();

        var conditionFunc = condition.Compile();

        rules.Add(item: new Rule<T>(ruleName, conditionFunc, failedValidationMessage));

        return this;
    }

    public IEntityRulesValidator<T> Build() => new EntityRulesValidator<T>(rules);
}