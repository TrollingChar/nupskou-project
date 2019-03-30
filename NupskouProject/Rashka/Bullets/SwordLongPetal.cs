using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;


namespace NupskouProject.Rashka.Bullets
{
    public class SwordLongPetal : PetalBeamBullet
    {
        private readonly XY _p0;

        private float _angle;
        private readonly int _magicnumber = 55;
        private readonly int _delay;



        public SwordLongPetal(XY p0, float angle, Color mainColor, Color borderColor, float r, int delay)
        {
            V = new XY(angle);
            _p0 = p0;
            _angle = angle - Mathf.PI / 2;
            MainColor = mainColor;
            BorderColor = borderColor;
            R = r;
            _delay = delay;
        }


        protected override void Update(int t)
        {
            if (t == _delay + 60)
            {
                Despawn();
            }


            P = new XY(_p0.X + Mathf.Cos(_angle) * _magicnumber, _p0.Y + Mathf.Sin(_angle) * _magicnumber);
            V = new XY(_angle);
            if (t > 60)
            {
                _angle = _angle + Mathf.PI / _delay;
            }
        }

    }
}