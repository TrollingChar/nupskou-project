using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Math;


namespace NupskouProject.Entities {

    public class StoppingLinearRoundBullet : RoundBullet {

        private readonly XY _p0;
        private readonly XY _v;
        private readonly int _delay;


        public StoppingLinearRoundBullet (XY p0, XY v, Color mainColor, Color borderColor, float r, int delay) {
            _p0         = p0;
            _v          = v;
            MainColor   = mainColor;
            BorderColor = borderColor;
            R           = r;
            _delay = delay;
        }


        protected override void Update (int t) {
            if(t < _delay)
            {
            P = _p0 + t * _v;

                
            }
            if (t >= _delay)
            {
                P = _p0 + _delay * _v;
            }
        }

    }

}