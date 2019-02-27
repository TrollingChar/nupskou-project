using System;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Math;


namespace NupskouProject.Entities {

    public class DelayedLinearPetalBullet : PetalBullet {
        private readonly XY _p0;
        private readonly int _delay;


        public DelayedLinearPetalBullet (XY p0, XY v, Color mainColor, Color borderColor, float r, int delay) {
            _p0         = p0;
            V           = v;
            MainColor   = mainColor;
            BorderColor = borderColor;
            R           = r;
            _delay = delay;
        }


        protected override void Update (int t) {
            if (t == 0){P = _p0;}
            if (t >= _delay)
            {
                P = _p0 + (t - _delay) * V;
            } 
            if (t > 30 && !Geom.CircleOverBox (new Circle (P, R + 2), World.Box)) {
                Despawn ();
            }
        }

    }

}