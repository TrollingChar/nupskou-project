using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Util;


namespace NupskouProject.Raden.Enemies {

    public class PurbleBlueShooter : Enemy {

        protected override void Update (int t) {
            if (t % 180 == 0) {
                foreach (var v in Danmaku.Ring (new XY(_.Random.Angle ()), 60)) {
                    _.World.Spawn (new LinearPetalBullet(P, v, Color.Magenta, Color.DarkMagenta, 3));
                }
            }
            if (t % 20 == 0 && _.Player != null && !_.Player.Despawned) {
                _.World.Spawn (
                    new LinearRoundBullet (
                        P,
                        (_.Player.P - P).WithLength (2).Rotated (_.Random.SignedFloat () * 0.2f),
                        Color.Blue,
                        Color.Blue,
                        10
                    )
                );
            }
        }

    }

}