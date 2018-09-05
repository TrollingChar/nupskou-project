using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Hitboxes;
using NupskouProject.Math;
using NupskouProject.Rendering;


namespace NupskouProject.Entities {

    public class PlayerBullet : StdEntity {

        private readonly XY _p0;
        private readonly XY _v;
        private          XY _p;


        public override Hitbox EnemyDamagerHitbox => new CircleHitbox (_p, 5);


        public PlayerBullet (XY p0, XY v) {
            _p = _p0 = p0;
            _v = v;
        }


        protected override void Update (int t) {
            _p = _p0 + t * _v;
            if (t > 30 && !Geom.CircleOverBox (new Circle(_p, 6), World.Box)) {
                Despawn ();
            }
        }


        public override void Render () {
            _.Renderer.TestBackground.Add (
                new SpriteInstance (_.Assets.Circle) {Position = _p, Color = Color.Red * 0.25f, Scale = new Vector2 (4)}
            );
        }

    }

}