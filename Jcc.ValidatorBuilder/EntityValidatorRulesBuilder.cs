using System.Linq.Expressions;
using Jcc.ValidatorBuilder.Interfaces;

namespace Jcc.ValidatorBuilder;

public class EntityValidatorRulesBuilder<T> : IValidatorRulesBuilder<T> {
    private readonly T entity;
    private readonly List<Rule> rules = [];

    private EntityValidatorRulesBuilder(T entity) {
        this.entity = entity;
    }

    public static EntityValidatorRulesBuilder<T> Create(T entity) => new(entity);

    public IValidatorRulesBuilder<T> AddRule(string ruleName,
                                             Expression<Func<T, bool>> predicate,
                                             string failedValidationMessage = "") {
        if (predicate.CanReduce)
            predicate = (Expression<Func<T, bool>>)predicate.Reduce();

        var predicatedCompiled = predicate.Compile();
        var isValid = predicatedCompiled(entity);

        rules.Add(item: new Rule(ruleName, isValid, failedValidationMessage));

        return this;
    }
    
    public IEntityValidatorRules Build() => new EntityValidatorRules(rules);
}