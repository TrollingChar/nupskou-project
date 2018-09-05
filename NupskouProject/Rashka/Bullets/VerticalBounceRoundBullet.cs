using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Hitboxes;
using NupskouProject.Math;
using NupskouProject.Rendering;

namespace NupskouProject.Rashka.Bullets {

    public class VerticalBounceRoundBullet : StdEntity {

        private readonly XY _p0;
        private readonly XY _v;
        private          XY _p;
        private Color _color;


        public override Hitbox PlayerDamagerHitbox => new CircleHitbox (_p, 4);


        public VerticalBounceRoundBullet (XY p0, XY v, Color color) {
            _p = _p0 = p0;
            _v = v;
            _color = color;
        }


        public override void OnStrike (Entity entity) => Despawn ();


        protected override void Update (int t) {
            _p   = _p0 + t * _v;
            _p.X = Mathf.PingPong (_p.X - 30, World.Box.Right) + 30;
            if (_p.Y > World.Box.Bottom + 6) {
                Despawn ();
            }
        }


        public override void Render () {
            _.Renderer.TestForeground.Add (
                new SpriteInstance (_.Assets.Circle) {Position = _p, Color = _color, Scale = new Vector2 (8)}
            );
            
            _.Renderer.TestForeground.Add (
                new SpriteInstance (_.Assets.Circle) {Position = _p, Color = Color.Black, Scale = new Vector2 (6)}
            );
            _.Renderer.TestForeground.Add (
                new SpriteInstance (_.Assets.Circle) {Position = _p, Color = Color.White, Scale = new Vector2 (4)}
            );
        }

    }

}