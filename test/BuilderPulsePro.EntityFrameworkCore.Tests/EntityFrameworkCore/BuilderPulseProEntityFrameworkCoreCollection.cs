using Xunit;

namespace BuilderPulsePro.EntityFrameworkCore;

[CollectionDefinition(BuilderPulseProTestConsts.CollectionDefinitionName)]
public class BuilderPulseProEntityFrameworkCoreCollection : ICollectionFixture<BuilderPulseProEntityFrameworkCoreFixture>
{

}
