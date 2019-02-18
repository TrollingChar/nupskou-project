using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Math;
using NupskouProject.Rendering;

namespace NupskouProject.Entities.Bomb.Projectiles
{
    public class DDEBullet : StdEntity
    {

        private readonly XY _p0;
        private readonly XY _v;
        private XY _p;
        
        public DDEBullet (XY p0, XY v) {
            _p = _p0 = p0;
            _v = v;
        }


        
        protected override void Update (int t) {
            _p = _p0 + t * _v;
            if (t > 60)
            {
                _.World.Spawn(new DDE(_p, 100, 180));
                Despawn();
            }

        }


        public override void Render () {
            _.Renderer.TestBackground.Add (
                new SpriteInstance (_.Assets.Circle) {Position = _p, Color = Color.Red * 0.25f, Scale = new Vector2 (5)}
            );
        }

    }
}