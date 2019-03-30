using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Rashka.Bullets;
using NupskouProject.Util;

namespace NupskouProject.Rashka.Spells.FlashSignBlastRain
{
    public class LinearBlaster : Bullet
    {
        private readonly XY V, _p;
        private XY P;
        public LinearBlaster (XY p0, XY v) {
            _p = p0;
            V = v;
        }
        protected override void Update (int t)
        {
            P = _p + V*t;
            if (t % 3 == 0)
            {
                _.World.Spawn(new Blast
                (
                    P+P.Rotated90CW().Normalized*_.Random.Float(-6,6),
                    _.Random.Float(2,9),
                    15));
            }
            if (t > 30 && !Geom.CircleOverBox (new Circle (P, 2), World.Box)) {
                Despawn ();
            }
            
        
        }
    }
}