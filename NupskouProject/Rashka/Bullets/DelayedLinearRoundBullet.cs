using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using Un4seen.Bass.AddOn.DShow;
using Un4seen.Bass.Misc;

namespace NupskouProject.Rashka.Bullets {

    public class DelayedLinearRoundBullet : RoundBullet {

        private readonly XY _p0;
        private readonly XY _v;
        private readonly int _delay;
        private readonly int _startup = 0;

        public DelayedLinearRoundBullet (XY p0, XY v, Color mainColor, Color borderColor, float r , int delay) {
            _p0         = p0;
            _v          = v;
            MainColor   = mainColor;
            BorderColor = borderColor;
            R           = r;
            _delay = delay;
        }
        public DelayedLinearRoundBullet (XY p0, XY v, Color mainColor, Color borderColor, float r , int delay, int startup) {
            _p0         = p0;
            _v          = v;
            MainColor   = mainColor;
            BorderColor = borderColor;
            R           = r;
            _delay = delay;
            _startup = startup;
        }


        protected override void Update (int t)
        {
            if (t < _startup)
            {P = _p0 + t * _v;}

            if (t >= _startup)
            {P = _p0 + _v * _startup;}

            if (t == _delay)
            {
                MainColor = Color.Red;
                BorderColor = Color.Red;
            }
            if (t >= _delay)
            {
                P = _p0 + (t - _delay + _startup) * _v;
            } 

            if (t > 30 && !Geom.CircleOverBox (new Circle (P, R + 2), World.Box)) {
                Despawn ();
            }
        }

    }

}