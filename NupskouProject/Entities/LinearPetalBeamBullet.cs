using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Math;

namespace NupskouProject.Entities
{
    public class LinearPetalBeamBullet : PetalBeamBullet
    {
        private readonly XY _p0;


        public LinearPetalBeamBullet (XY p0, XY v, Color mainColor, Color borderColor, float r) {
            _p0         = p0;
            V         = v;
            MainColor   = mainColor;
            BorderColor = borderColor;
            R           = r;
        }


        protected override void Update (int t) {
            P = _p0 + t * V;
            if (t > 30 && !Geom.CircleOverBox (new Circle (P, R + 50), World.Box)) {
                Despawn ();
            }
        }

    }
}
