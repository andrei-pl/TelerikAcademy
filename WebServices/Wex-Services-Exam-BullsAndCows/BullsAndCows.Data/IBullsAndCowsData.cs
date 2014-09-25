using BullsAndCows.Data.Repositories;
using BullsAndCows.Models;
using System;
namespace BullsAndCows.Data
{
    public interface IBullsAndCowsData
    {
        IRepository<Game> Games { get; }

        IRepository<Guess> Guesses { get; }

        IRepository<User> Users { get; }

        void SaveChanges();
    }
}
