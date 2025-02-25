using GymManagement.Domain.Gyms;
using TestCommon.TestConstants;

namespace TestCommon.Gyms;

public static class GymFactory
{
    public static Gym CreateGym(
        string name = Constant.Gym.Name,
        int maxRooms = Constant.Subscriptions.MaxRoomsFreeTier,
        Guid? id = null)
    {
        return new Gym(
            name,
            maxRooms,
            subscriptionId: Constant.Subscriptions.Id,
            id: id ?? Constant.Gym.Id);
    }
}
