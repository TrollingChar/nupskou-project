using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Math;


namespace NupskouProject.Entities {

    public class LinearPetalBullet : PetalBullet {

        private readonly XY _p0;


        public LinearPetalBullet (XY p0, XY v, Color mainColor, Color borderColor, float r) {
            _p0         = p0;
            V         = v;
            MainColor   = mainColor;
            BorderColor = borderColor;
            R           = r;
        }


        protected override void Update (int t) {
            P = _p0 + t * V;
            if (t > 30 && !Geom.CircleOverBox (new Circle (P, R + 2), World.Box)) {
                Despawn ();
            }
        }

    }

}