using ConsoleApp.Specifications;
using Jcc.ValidatorBuilder.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddScoped<IValidatorRulesSpecification<Person>, PersonValidatorRulesSpecification>()
    .BuildServiceProvider();

var service = serviceProvider.GetService<IValidatorRulesSpecification<Person>>();
var validator = service?.GetRulesValidator();

Person[] persons = [
    new Person("javier", 41, "street example"),
    new Person("Pepe", 30, "street example2"),
    new Person("Pepe", 30, "street example2")
];

foreach (var person in persons) {
    if (validator is null)
        continue;

    var personValidation = validator.Validate(person);
    Console.WriteLine($" person with name: ${person.Name} - Validatiion {personValidation.IsValid}");

    foreach (var rulesErrorMessage in personValidation.FailedErrorMessages) {
        Console.WriteLine($" \t rule name: {rulesErrorMessage.Key} - ruleErrorMessage: {rulesErrorMessage.Value}");
    }
}

Console.Read();

public record Person(string Name, int Age, string Address);