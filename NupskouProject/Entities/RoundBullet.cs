using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Hitboxes;
using NupskouProject.Math;
using NupskouProject.Rendering;


namespace NupskouProject.Entities {

    public class RoundBullet : StdEntity {

        private readonly XY _p0;
        private readonly XY _v;
        private          XY _p;


        public override Hitbox PlayerDamagerHitbox => new CircleHitbox (_p, 5);


        public RoundBullet (XY p0, XY v) {
            _p = _p0 = p0;
            _v = v;
        }


        public override void OnStrike (Entity entity) => Despawn ();


        protected override void Update (int t) {
            _p = _p0 + t * _v;
            if (t > 30 && !Geom.CircleOverBox (new Circle(_p, 8), World.Box)) {
                Despawn ();
            }
        }


        public override void Render () {
            _.Renderer.TestForeground.Add (
                new SpriteInstance (_.Assets.Circle) {Position = _p, Color = Color.Green, Scale = new Vector2 (6)},
                new SpriteInstance (_.Assets.Circle) {Position = _p, Color = Color.Lime,  Scale = new Vector2 (5.5f)},
                new SpriteInstance (_.Assets.Circle) {Position = _p, Color = Color.White, Scale = new Vector2 (5)}
            );
        }

    }

}