namespace Jcc.ValidatorBuilder.Interfaces;

public interface IEntityRulesValidator<in T> {
    EntityValidationRulesResult Validate(T entity);
}