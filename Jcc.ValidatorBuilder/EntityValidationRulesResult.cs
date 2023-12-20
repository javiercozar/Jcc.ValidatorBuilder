using System.Collections;

namespace Jcc.ValidatorBuilder;

public readonly record struct EntityValidationRulesResult(
    bool IsValid,
    RulesErrorMessages FailedErrorMessages);