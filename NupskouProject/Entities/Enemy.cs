using System;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Hitboxes;
using NupskouProject.Math;
using NupskouProject.Rendering;


namespace NupskouProject.Entities {

    public class Enemy : StdEntity {

        private readonly XY _p0;
        private readonly XY _v;
        private          XY _p;


        public override Hitbox EnemyHitbox => new CircleHitbox (_p, 10);


        public Enemy (XY p0, XY v) {
            _p = _p0 = p0;
            _v = v;
        }


        public override void OnStruck (Entity entity) {
            Despawn ();
        }


        protected override void Update (int t) {
            _p = _p0 + t * _v;
            if (t > 30 && !Geom.CircleOverBox (new Circle(_p, 15), World.Box)) {
                Despawn ();
            }
            var player = _.World.Player;
            if (t % 13 == 0 && player != null && !player.Despawned) {
                foreach (var v in Danmaku.Line ((player.P - _p).Normalized, 2, 4, 3)) {
                    _.World.Spawn (new LinearRoundBullet(_p, v, Color.Lime, Color.Green));
                }
            }
        }


        public override void Render () { 
            _.Renderer.TestForeground.Add (
                new SpriteInstance (_.Assets.Circle) {Position = _p, Color = Color.Lime, Scale = new Vector2 (10)}
            );
        }

    }

}