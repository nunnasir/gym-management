using GymManagement.Domain.Subscriptions;
using TestCommon.TestConstants;

namespace TestCommon.Subscriptions;

public static class SubscriptionFactory
{
    public static Subscription CreateSubscription(
        SubscriptionType? subscriptionType = null,
        Guid? adminId = null,
        Guid? id = null)
    {
        return new Subscription(
            subscriptionType: subscriptionType ?? Constant.Subscriptions.DefaultSubscriptionType,
            adminId ?? Constant.Admin.Id,
            id ?? Constant.Subscriptions.Id);
    }
}
