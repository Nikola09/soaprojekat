using DataCore.Model;
using MongoService.Models;
using NRules.Fluent.Dsl;

namespace MongoService.Rules
{
    public class AmbientRule : Rule
    {
        public override void Define()
        {
            Ambient ambient = null;

            When()
              .Match<Ambient>(() => ambient, a => a.Lumix > 10.0); // highly eluminated area
            Then()
              .Do(ctx => ctx.Insert(new MongodbAmbient(ambient)));

        }
    }
}
