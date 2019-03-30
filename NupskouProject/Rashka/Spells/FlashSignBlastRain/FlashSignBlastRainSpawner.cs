using System;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Util;

namespace NupskouProject.Rashka.Spells.FlashSignBlastRain
{
    public class FlashSignBlastRainSpawner: StdEntity
    {
        private Box _rainSpawnBox = new Box(World.Box.Left,World.Box.Top,World.Box.Right,World.Box.Bottom*0.1f);

        public FlashSignBlastRainSpawner()
        {

        }
        protected override void Update (int t) {
            if (t % 5 == 0)
            {
                _.World.Spawn(new LinearBlaster(
                    _.Random.Point (_rainSpawnBox),
                    3*new XY(Mathf.PI/2+_.Random.Float(-Mathf.PI/18,Mathf.PI/18))
                ));
            }
        }
    }
}