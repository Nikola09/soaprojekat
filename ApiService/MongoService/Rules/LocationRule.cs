using DataCore.Model;
using MongoService.Models;
using NRules.Fluent.Dsl;

namespace MongoService.Rules
{
    public class LocationRule : Rule
    {
        public override void Define()
        {
            Location location = null;

            When()
              .Match<Location>(() => location, l => l.Accuracy < 20.0); //  very precise location accuracy
            Then()
              .Do(ctx => ctx.Insert(new MongodbLocation(location)));

        }
    }
}
