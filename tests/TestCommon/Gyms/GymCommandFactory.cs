using GymManagement.Application.Gyms.Commands.CreateGym;
using TestCommon.TestConstants;

namespace TestCommon.Gyms;

public static class GymCommandFactory
{
    public static CreateGymCommand CreateCreateGymCommand(
        string name = Constant.Gym.Name,
        Guid? subscriptionId = null)
    {
        return new CreateGymCommand(
            Name: name,
            SubscriptionId: subscriptionId ?? Constant.Subscriptions.Id);
    }
}
