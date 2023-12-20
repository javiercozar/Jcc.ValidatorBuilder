using Jcc.ValidatorBuilder;

var personOne = new Person("javier", 41, "Pasaje cala figuera");

var entityValidatorRules = EntityValidatorRulesBuilder<Person>
    .Create(personOne)
    .AddRule(
        ruleName: "NameStartWithJ",
        predicate: person => person.Name.StartsWith($"j"),
        failedValidationMessage: "Person Name have to start with J")
    .AddRule(
        ruleName: "PersonLimitAge",
        predicate: person => person.Age > 40,
        failedValidationMessage: "Age have to be more than 40")
    .Build();

var validationResult = entityValidatorRules.Validate();

Console.WriteLine($"Validation is valid {validationResult.IsValid}");
Console.Read();

public record Person(string Name, int Age, string Address);