using CommunityToolkit.Mvvm.Messaging.Messages;
using Volo.Abp.Identity;

namespace BuilderPulsePro.Maui.Messages;
public class IdentityUserCreateMessage : ValueChangedMessage<IdentityUserCreateDto>
{
    public IdentityUserCreateMessage(IdentityUserCreateDto value) : base(value)
    {
    }
}