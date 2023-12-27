using System.Collections;

namespace Jcc.ValidatorBuilder;

public readonly record struct ValidationRulesResult(
    bool IsValid,
    RulesErrorMessages FailedErrorMessages);