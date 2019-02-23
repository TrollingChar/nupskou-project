using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Raden.Bullets;
using NupskouProject.Util;


namespace NupskouProject.Raden.Revolt2 {

    public class Revolt2 : StdEntity {

        protected override void Update (int t) {
            var   o  = World.Box.Center;
            float av = Mathf.PI / _.Difficulty.Choose (1200, 800, 1200, 800);
            int dt = _.Difficulty.Choose (90, 90, 60, 60);
            if (t == 0) {
                _.World.Spawn (new HugeStar (new XY (o.X, World.Box.Top    + 20), XY.Zero, 0, av));
                _.World.Spawn (new HugeStar (new XY (o.X, World.Box.Bottom - 20), XY.Zero, 0, av));
            }
            if (t % dt == 0) {
                // ReSharper disable once PossibleLossOfFraction - так и было задумано!
                float angle = t / dt * Mathf.phiAngle / 30;
                foreach (var v in Danmaku.Ring (new XY (angle), 30)) {
                    _.World.Spawn (new LinearRoundBullet (new XY(World.Box.Left,  o.Y), v, Color.Red, Color.Red));
                    _.World.Spawn (new LinearRoundBullet (new XY(World.Box.Right, o.Y), v, Color.Red, Color.Red));
                }
            }
        }

    }

}