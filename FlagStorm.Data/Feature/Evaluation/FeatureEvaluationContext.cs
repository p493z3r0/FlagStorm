using FlagStorm.Data.Data;

namespace FlagStorm.Data.Feature.Evaluation;

public class FeatureEvaluationContext
{
    public required Actor Actor { get; init; }
    public required EnvironmentSnapshot Environment { get; init; }
}