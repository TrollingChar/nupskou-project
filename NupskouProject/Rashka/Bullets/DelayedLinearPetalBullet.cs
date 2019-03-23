using System;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Math;


namespace NupskouProject.Entities {

    public class DelayedLinearPetalBullet : PetalBullet {
        private readonly XY _p0;
        private readonly int _delay;
        private readonly int _startup = 0;


        public DelayedLinearPetalBullet (XY p0, XY v, Color mainColor, Color borderColor, float r, int delay, int startup) {
            _p0         = p0;
            V           = v;
            MainColor   = mainColor;
            BorderColor = borderColor;
            R           = r;
            _delay = delay;
            _startup = startup;

        }
        public DelayedLinearPetalBullet (XY p0, XY v, Color mainColor, Color borderColor, float r, int delay) {
            _p0         = p0;
            V           = v;
            MainColor   = mainColor;
            BorderColor = borderColor;
            R           = r;
            _delay = delay;
        }



        protected override void Update (int t) {
            if (t < _startup)
            {P = _p0 + t * V;}

            if (t >= _startup)
            {P = _p0 + V * _startup;}

            if (t >= _delay)
            {
                P = _p0 + (t - _delay + _startup) * V;
            } 
            if (t > 30 && !Geom.CircleOverBox (new Circle (P, R + 2), World.Box)) {
                Despawn ();
            }
        }

    }

}