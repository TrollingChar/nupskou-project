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


        public Enemy (XY p0, XY v) {
            _p = _p0 = p0;
            _v = v;

            EnemyHitbox = () => new CircleHitbox (_p, 10);
        }


        public override void OnImpact (Entity entity) {
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
                    _.World.Spawn (new RoundBullet (_p, v));
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