using System.Data;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Rashka.Bullets;
using NupskouProject.Util;

namespace NupskouProject.Rashka
{
    public class DemomanSignDelayedExplosionSpawner : StdEntity
    {
        private XY _prevSpawn = new XY(250, 500);

        protected override void Update(int t)
        {
            if (t % 240 == 0) {
                for (int i = 0; i < 8; i++)
                {
                    var a = _.Random.Point (World.Box);
                    var b = _.Random.Point (World.Box);
                    _prevSpawn = XY.SqrDistance (a, _prevSpawn) > XY.SqrDistance (b, _prevSpawn) ? a : b;
                    _.World.Spawn (new DemomanCircle (_prevSpawn, 100,10,90));
                }

            }
        }
    }
}