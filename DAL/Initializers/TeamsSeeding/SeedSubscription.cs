using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Initializers.TeamsSeeding
{
    public class SeedSubscription
    {
        Subscription free = new Subscription() { Name="free", Price=0};
        Subscription silver = new Subscription() { Name="free", Price=29.99};
        Subscription gold = new Subscription() { Name="free", Price=49.99};
    }
}
