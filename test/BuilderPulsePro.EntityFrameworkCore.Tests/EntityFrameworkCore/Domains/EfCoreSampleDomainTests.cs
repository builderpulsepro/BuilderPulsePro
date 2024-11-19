using BuilderPulsePro.Samples;
using Xunit;

namespace BuilderPulsePro.EntityFrameworkCore.Domains;

[Collection(BuilderPulseProTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<BuilderPulseProEntityFrameworkCoreTestModule>
{

}
