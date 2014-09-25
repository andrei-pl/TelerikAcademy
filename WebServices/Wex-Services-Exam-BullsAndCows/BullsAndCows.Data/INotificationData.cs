using BullsAndCows.Data.Repositories;
using BullsAndCows.Models;
using System;
namespace BullsAndCows.Data
{
    public interface INotificationData
    {
        IRepository<Notification> Notifications { get; }
    }
}
