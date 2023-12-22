using Jcc.ValidatorBuilder;

Person[] persons = [
    new Person("javier", 41, "street example"),
    new Person("Pepe", 30, "street example2"),
    new Person("Pepe", 30, "street example2")
];


var entityValidatorRules = EntityEntityRulesValidatorBuilder<Person>
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


foreach (var person in persons) {
    var personValidation = entityValidatorRules.Validate(person);
    Console.WriteLine($" person with name: ${person.Name} - Validatiion {personValidation.IsValid}");
    foreach (var rulesErrorMessage in personValidation.FailedErrorMessages) {
        Console.WriteLine($" \t rule name: {rulesErrorMessage.Key} - ruleErrorMessage: {rulesErrorMessage.Value}");
    }
}

Console.Read();

public record Person(string Name, int Age, string Address);