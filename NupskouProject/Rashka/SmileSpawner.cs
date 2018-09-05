using NupskouProject.Core;
using NupskouProject.Util;
using NupskouProject.Rashka.Bullets;
using NupskouProject.Entities;
using NupskouProject.Math;
using Microsoft.Xna.Framework;


namespace NupskouProject.Rashka {

    public class SmileSpawner : StdEntity {

        protected override void Update (int t) {
            if (t % 30 == 0) {
                var box = World.Box;
                SpawnSmile (
                    new XY (_.Random.Float (box.Left , box.Right/2), -100),
                    5 * new XY (_.Random.SignedFloat () * Mathf.PI / 1.5f).Rotated90CCW (),
                    Color.Red
                );
                SpawnSmile(
                    new XY(_.Random.Float(box.Right/2, box.Right ), -100),
                    5 * new XY(_.Random.SignedFloat() * Mathf.PI / 1.5f).Rotated90CCW(),
                    Color.Red
                );

            }
        }


        private void SpawnSmile (XY p, XY v, Color color) {
            var w     = v.Normalized;
            var line  = Danmaku.Line (w, 0, 40, 5);
            var spray = Danmaku.Spray (90 * w, Mathf.PI / 3, 9);

            var world = _.World;
            foreach (var offset in line) {
                world.Spawn (new VerticalBounceRoundBullet (p + 20 * w.Rotated90CW () + offset, v, color));
                world.Spawn (new VerticalBounceRoundBullet (p - 20 * w.Rotated90CW () + offset, v, color));
            }
            foreach (var offset in spray) {
                world.Spawn (new VerticalBounceRoundBullet (p + offset, v, color));
            }
        }

    }

}