using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using Un4seen.Bass.Misc;

namespace NupskouProject.Rashka.Bullets {

    public class DelayedLinearRoundBullet : RoundBullet {

        private readonly XY _p0;
        private readonly XY _v;
        private readonly int _delay;

        public DelayedLinearRoundBullet (XY p0, XY v, Color mainColor, Color borderColor, float r , int delay) {
            _p0         = p0;
            _v          = v;
            MainColor   = mainColor;
            BorderColor = borderColor;
            R           = r;
            _delay = delay;
        }


        protected override void Update (int t)
        {
            if (t == 0){P = _p0;}
            if (t >= _delay)
            {
                P = _p0 + (t - _delay) * _v;
            } 

            if (t > 30 && !Geom.CircleOverBox (new Circle (P, R + 2), World.Box)) {
                Despawn ();
            }
        }

    }

}