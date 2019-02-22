using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;


namespace NupskouProject.Raden.TestSpellcard {

    public class TestSpellcard : StdEntity {

        protected override void Update (int t) {
            var v = new XY (t * Mathf.phiAngle / 2);
            foreach (var w in Danmaku.Ring (v, 2)) {
                _.World.Spawn (new LinearRoundBullet       (World.BossPlace,    3 * w, Color.Green,  Color.Lime));
                _.World.Spawn (new SqrtRoundBullet         (World.BossPlace,   30 * w, Color.Blue,   Color.LightBlue));
                _.World.Spawn (new AcceleratingRoundBullet (World.BossPlace, 0.3f * w, Color.Maroon, Color.Red));
            }
        }

    }

}