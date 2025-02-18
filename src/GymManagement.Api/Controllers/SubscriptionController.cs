using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Application.Subscriptions.Commands.DeleteSubscription;
using GymManagement.Application.Subscriptions.Queries.GetSubscription;
using GymManagement.Application.Subscriptions.Queries.ListSubscription;
using GymManagement.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DomainSubscriptionsType = GymManagement.Domain.Subscriptions.SubscriptionType;

namespace GymManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionController : ApiController
{
    private readonly ISender _mediatR;

    public SubscriptionController(ISender mediator)
    {
        _mediatR = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
    {
        if (!DomainSubscriptionsType.TryFromName(
            request.SubscriptionType.ToString(),
            out var subscriptionType))
        {
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                detail: "Invalid subscription type");
        }

        var command = new CreateSubscriptionCommand(
            subscriptionType,
            request.AdminId);

        var createSubscriptionResult = await _mediatR.Send(command);

        return createSubscriptionResult.Match(
            subscription => CreatedAtAction(
                nameof(GetSubscription),
                new { subscriptionId = subscription.Id },
                new SubscriptionResponse(
                    subscription.Id,
                    subscription.AdminId,
                    ToDto(subscription.SubscriptionType))),
            Problem);
    }

    [HttpGet("{subscriptionId:guid}")]
    public async Task<IActionResult> GetSubscription(Guid subscriptionId)
    {
        var query = new GetSubscriptionQuery(subscriptionId);

        var getSubscriptionResult = await _mediatR.Send(query);

        return getSubscriptionResult.Match(
            subscription => Ok(new SubscriptionResponse(
                subscription.Id,
                subscription.AdminId,
                ToDto(subscription.SubscriptionType))),
            Problem);
    }

    [HttpDelete("{subscriptionId:guid}")]
    public async Task<IActionResult> DeleteSubscription(Guid subscriptionId)
    {
        var command = new DeleteSubscriptionCommand(subscriptionId);

        var createSubscriptionResult = await _mediatR.Send(command);

        return createSubscriptionResult.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> ListSubscriptions()
    {
        var query = new ListSubscriptionQuery();

        var listSubscriptionsResult = await _mediatR.Send(query);

        return listSubscriptionsResult.Match(
            subscriptions => Ok(subscriptions.ConvertAll(
                subscription => new SubscriptionResponse(
                    subscription.Id, 
                    subscription.AdminId,
                    ToDto(subscription.SubscriptionType))
                )),
            Problem);
    }

    private static SubscriptionType ToDto(DomainSubscriptionsType subscriptionType)
    {
        return subscriptionType.Name switch
        {
            nameof(DomainSubscriptionsType.Free) => SubscriptionType.Free,
            nameof(DomainSubscriptionsType.Starter) => SubscriptionType.Starter,
            nameof(DomainSubscriptionsType.Pro) => SubscriptionType.Pro,
            _ => throw new InvalidOperationException(),
        };
    }
}
