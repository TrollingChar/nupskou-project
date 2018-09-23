using System;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;

namespace NupskouProject.Rashka.Bullets {

    public class SphericalRoundBullet : RoundBullet {

        private readonly float _v;

        private float _z;
        private readonly float _radius;
        private  XY _p;
        private readonly float _dir;
        private readonly float _period;
            


        public SphericalRoundBullet (XY p, float dir, float v, Color mainColor, Color borderColor, float r,float radius)
        {
            _p = p;
            _dir = dir;
            _v          = v;
            MainColor   = mainColor;
            BorderColor = borderColor;
            R           = r;

            _radius = radius;

            _period =  2 * Mathf.PI * _radius / v ;
        }


        protected override void Update (int t)
        {
 //          _angle1 = _angle1 + Mathf.Sin(_dir) * 2 * Mathf.PI / _period;
 //          _angle2 = _angle2 + Mathf.PI/180;
            P = _p;
            if (t > 30 && !Geom.CircleOverBox (new Circle (P, R + 2), World.Box)) {
                Despawn ();
            }
        }

    }

}