using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Hitboxes;
using NupskouProject.Math;
using Sprite = NupskouProject.Rendering.SpriteInstance;


namespace NupskouProject.Entities {

    public abstract class RoundBullet : StdEntity {

//        private readonly XY _p0;
//        private readonly XY _v;

        protected XY    P;
        protected float R;
        protected Color MainColor, BorderColor;


        public override Hitbox PlayerDamagerHitbox => new CircleHitbox (P, R);


//        public RoundBullet (XY p0, XY v) {
//            P = _p0 = p0;
//            _v = v;
//            R = 5;
//        }


        public override void OnStrike (Entity entity) => Despawn ();


        protected override void Update (int t) {
//            P = _p0 + t * _v;
//            if (t > 30 && !Geom.CircleOverBox (new Circle(P, R + 2), World.Box)) {
//                Despawn ();
//            }
        }


        public override void Render () {
            _.Renderer.TestForeground.Add (
                new Sprite (_.Assets.Circle) {Position = P, Color = MainColor, Scale = new Vector2 (R + 1)},
                new Sprite (_.Assets.Circle) {Position = P, Color = BorderColor,  Scale = new Vector2 (R + 0.5f)},
                new Sprite (_.Assets.Circle) {Position = P, Color = Color.White, Scale = new Vector2 (R)}
            );
        }

    }

}