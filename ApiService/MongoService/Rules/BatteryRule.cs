using DataCore.Model;
using MongoService.Models;
using NRules.Fluent.Dsl;

namespace MongoService.Rules
{
    public class BatteryRule : Rule
    {
        public override void Define()
        {
            Battery battery = null;

            When()
              .Match<Battery>(() => battery, b => b.Level < 16); // low battery level
            Then()
              .Do(ctx => ctx.Insert(new MongodbBattery(battery)));

        }

    }
}
