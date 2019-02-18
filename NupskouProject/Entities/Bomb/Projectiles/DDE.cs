using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Hitboxes;
using NupskouProject.Math;
using NupskouProject.Rendering;

namespace NupskouProject.Entities.Bomb.Projectiles
{
    public class DDE: StdEntity
    {
        private readonly int _delay;
        private readonly int _t;
        private  XY    P;
        private float _r ;

        

        
        public DDE (XY p0, float r, int delay) {
            P         = p0;
            _r       = r;
            _delay      = delay;
        }
        
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