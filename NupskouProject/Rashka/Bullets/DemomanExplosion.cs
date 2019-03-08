using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Hitboxes;
using NupskouProject.Math;
using NupskouProject.Rendering;
using Un4seen.Bass.Misc;

namespace NupskouProject.Rashka.Bullets
{
    public class DemomanExplosion : StdEntity
    {
        private readonly int _delay;
        private  XY    P;
        private float _r ;

        

        
        public DemomanExplosion (XY p0, float r, int delay) {
            P         = p0;
            _r       = r;
            _delay      = delay;
        }
        public override Hitbox PlayerDamagerHitbox => new CircleHitbox (P, _r);

        
        protected override void Update (int t) {

            if (t == _delay)
            {
                Despawn();
            }

        }
        public override void Render () {
            _.Renderer.TestBackground.Add (
                new SpriteInstance (_.Assets.Circle) {Position = P, Color = Color.White, Scale = new Vector2 (_r)}
            );
        }

    }
    
}