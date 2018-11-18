using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;


namespace NupskouProject.Raden.Airstrike {

    public class Bomb : PetalBullet {

        private XY _p0;
        private XY _v0;


        public Bomb (XY p0, XY v0) {
            _p0         = p0;
            _v0         = v0;
            MainColor   = Color.Yellow;
            BorderColor = Color.Red;
            R           = 4;
        }


        protected override void Update (int t) {
            V = _v0 + new XY (0, t * 0.025f);
            P = _p0 + t * _v0 + new XY (0, t * t * 0.025f);
            if (P.Y + R > World.Box.Bottom) {
                Despawn ();
            }
        }

    }

}