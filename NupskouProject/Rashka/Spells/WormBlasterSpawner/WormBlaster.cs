using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Rashka.Bullets;
using NupskouProject.Util;

namespace NupskouProject.Rashka.Spells.WormBlasterSpawner
{
    public class WormBlaster : StdEntity
    {
        private  XY    P, _v, _p;
        private float A;
        public WormBlaster (XY p0, float a, XY v) {
            P = p0;
            _p = p0;
            _v = v;
            A = a;
        }
        protected override void Update (int t)
        {
            P = P + _v*(1+A*t);
            if ( XY.Distance(P,_p) < XY.Distance(_.Player.Position,_p))
            _v = new XY((_.Player.Position -_p).Angle);
            if (t % 3 == 0)
            {
                _.World.Spawn(new DemomanExplosion
                    (
                    P+P.Rotated90CW().Normalized*_.Random.Float(-35,35),
                    _.Random.Float(3,10),
                    120));
            }
            if (t > 30 && !Geom.CircleOverBox (new Circle (P, 1), World.Box)) {
                Despawn ();
            }
        }
    }
}