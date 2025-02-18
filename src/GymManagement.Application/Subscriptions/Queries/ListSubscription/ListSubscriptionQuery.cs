using ErrorOr;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Queries.ListSubscription;

public record ListSubscriptionQuery : IRequest<ErrorOr<List<Subscription>>>;

