namespace GymManagement.Contracts.Subscriptions;

public record SubscriptionResponse(
    Guid Id,
    Guid AdminId,
    SubscriptionType SubscriptionType);
