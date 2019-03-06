using System;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Math;


namespace NupskouProject.Entities {

    public class CircularPetalBullet : PetalBullet {

        private readonly XY _p0;
        private float _deltaAngle, _progressiveSpeed, _angle;



        public CircularPetalBullet (XY p0, XY v, float deltaAngle, float progressiveSpeed, Color mainColor, Color borderColor, float r) {
            _p0         = p0;
            V           = v;
            _deltaAngle = deltaAngle;
            _progressiveSpeed = progressiveSpeed;
            MainColor   = mainColor;
            BorderColor = borderColor;
            R           = r;
            _angle = v.Angle;
        }


        protected override void Update (int t)
        {
            _angle = _angle + _deltaAngle;
            V = new XY(_angle).Rotated90CCW() + new XY(_angle).WithLength(_progressiveSpeed); 
            P = _p0 + new XY(Mathf.Cos(_angle), Mathf.Sin(_angle)) * _progressiveSpeed * t;
            if (t > 30 && (_p0 - P).Length > 666) {
                Despawn ();
            }
        }

    }

}