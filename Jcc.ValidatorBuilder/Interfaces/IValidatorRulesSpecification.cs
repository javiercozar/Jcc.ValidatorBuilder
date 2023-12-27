namespace Jcc.ValidatorBuilder.Interfaces;

public interface IValidatorRulesSpecification<in T> {
    IRulesValidator<T> GetRulesValidator();
}