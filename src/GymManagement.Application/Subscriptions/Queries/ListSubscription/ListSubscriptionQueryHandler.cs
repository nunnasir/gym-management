using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Queries.ListSubscription;

public class ListSubscriptionQueryHandler : IRequestHandler<ListSubscriptionQuery, ErrorOr<List<Subscription>>>
{
    private readonly ISubscriptionsRepository _subscriptionsRepository;

    public ListSubscriptionQueryHandler(ISubscriptionsRepository subscriptionsRepository)
    {
        _subscriptionsRepository = subscriptionsRepository;
    }

    public async Task<ErrorOr<List<Subscription>>> Handle(ListSubscriptionQuery request, CancellationToken cancellationToken)
    {
        return await _subscriptionsRepository.ListAsync();
    }
}
