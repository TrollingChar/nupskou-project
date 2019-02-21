using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Math;

namespace NupskouProject.Entities
{
    public class SwordLongPetal : PetalBeamBullet
    {
        private readonly XY _p0;

        private float _angle;
        private int _magicnumber = 50;
        
        public override void OnGrazed(Entity entity)
        {
            if (grazed == false)
            {
                grazed = true;
                _.Graze++;
            }
        }


        public SwordLongPetal (XY p0, float angle, Color mainColor, Color borderColor, float r) {
            V         = new XY(angle);
            _p0         = p0;
            _angle = angle+Mathf.PI/2;
            MainColor   = mainColor;
            BorderColor = borderColor;
            R           = r;
        }


        protected override void Update (int t)
        {
            P = new XY(_p0.X + Mathf.Cos(_angle) * _magicnumber, _p0.Y + Mathf.Sin(_angle) * _magicnumber);
            V = new XY(_angle);
            _angle = _angle +0.01f;
            if (t > 30 && !Geom.CircleOverBox (new Circle (P, R + 50), World.Box)) {
                Despawn ();
            }
        }

    }
}
