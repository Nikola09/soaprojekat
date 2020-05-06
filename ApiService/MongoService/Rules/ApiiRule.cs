using DataCore.Model;
using MongoService.Models;
using NRules.Fluent.Dsl;

namespace MongoService.Rules
{
    public class ApiiRule : Rule
    {
        public override void Define()
        {
            Apii apii = null;

            When()
              .Match<Apii>(() => apii, a => 
              a.InVehicle > 80 || 
              a.OnBicycle > 80 || 
              a.OnFoot > 80 ||
              a.Running > 80 ||
              a.Walking > 80); // activity is known
            Then()
              .Do(ctx => ctx.Insert(new MongodbApii(apii)));

        }
    }
}
