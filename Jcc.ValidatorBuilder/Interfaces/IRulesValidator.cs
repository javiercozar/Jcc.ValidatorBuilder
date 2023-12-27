namespace Jcc.ValidatorBuilder.Interfaces;

public interface IRulesValidator<in T> {
    ValidationRulesResult Validate(T entity);
}