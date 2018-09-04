using Microsoft.Xna.Framework;
using NupskouProject.Math;


namespace NupskouProject {

    public class RoundBullet : StdEntity {

        private readonly XY _p0;
        private readonly XY _v;
        private          XY _p;


        public RoundBullet (XY p0, XY v) {
            _p = _p0 = p0;
            _v = v;

            BulletHitbox = () => new CircleHitbox (_p, 5);
        }


        protected override void Update (int t) {
            _p = _p0 + t * _v;
        }


        public override void Render () {
            _.Renderer.TestForeground.Add (
                new SpriteInstance (_.Assets.Circle) {Position = _p, Color = Color.Green, Scale = new Vector2 (6)}
            );
            _.Renderer.TestForeground.Add (
                new SpriteInstance (_.Assets.Circle) {Position = _p, Color = Color.Lime, Scale = new Vector2 (5.5f)}
            );
            _.Renderer.TestForeground.Add (
                new SpriteInstance (_.Assets.Circle) {Position = _p, Color = Color.White, Scale = new Vector2 (5)}
            );
        }

    }

}