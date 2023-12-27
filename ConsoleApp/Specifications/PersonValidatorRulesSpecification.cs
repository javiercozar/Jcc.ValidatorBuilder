using Jcc.ValidatorBuilder;
using Jcc.ValidatorBuilder.Interfaces;

namespace ConsoleApp.Specifications;

internal sealed class PersonValidatorRulesSpecification : IValidatorRulesSpecification<Person> {
    public IRulesValidator<Person> GetRulesValidator() {
        var entityValidatorRules = RulesValidatorBuilder<Person>
            .Create()
            .AddRule(
                ruleName: "NameStartWithJ",
                condition: person => person.Name.StartsWith($"j"),
                failedValidationMessage: "Person Name have to start with J")
            .AddRule(
                ruleName: "PersonLimitAge",
                condition: person => person.Age > 40,
                failedValidationMessage: "Age have to be more than 40")
            .Build();

        return entityValidatorRules;
    }
}