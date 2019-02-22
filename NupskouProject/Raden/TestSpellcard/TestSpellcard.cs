using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;


namespace NupskouProject.Raden.TestSpellcard {

    public class TestSpellcard : StdEntity {

        protected override void Update (int t) {
            var v = new XY (t * Mathf.phiAngle);
            _.World.Spawn (
                new LinearRoundBullet (
                    World.BossPlace,
                    3 * v,
                    Color.Green,
                    Color.Lime,
                    8
                )
            );
            _.World.Spawn (
                new SqrtRoundBullet (
                    World.BossPlace,
                    30 * v,
                    Color.Blue,
                    Color.LightBlue,
                    8
                )
            );
            _.World.Spawn (
                new AcceleratingRoundBullet (
                    World.BossPlace,
                    0.3f * v,
                    Color.Maroon,
                    Color.Red,
                    8
                )
            );
        }

    }

}