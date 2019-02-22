using System;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Hitboxes;
using NupskouProject.Math;


namespace NupskouProject.Entities {

    public class LinearRoundBullet : RoundBullet {

        private readonly XY _p0;
        private readonly XY _v;




        public LinearRoundBullet (XY p0, XY v, Color mainColor, Color borderColor, float r = 5) {
            _p0         = p0;
            _v          = v;
            MainColor   = mainColor;
            BorderColor = borderColor;
            R           = r;
        }


        protected override void Update (int t) {
            P = _p0 + t * _v;
            if (t > 30 && !Geom.CircleOverBox (new Circle (P, R + 2), World.Box)) {
                Despawn ();
            }
        }

    }

}