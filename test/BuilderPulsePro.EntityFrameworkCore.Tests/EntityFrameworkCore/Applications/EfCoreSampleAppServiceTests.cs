using BuilderPulsePro.Samples;
using Xunit;

namespace BuilderPulsePro.EntityFrameworkCore.Applications;

[Collection(BuilderPulseProTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<BuilderPulseProEntityFrameworkCoreTestModule>
{

}
