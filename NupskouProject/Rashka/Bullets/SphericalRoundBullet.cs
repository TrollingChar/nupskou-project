using System;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;


namespace NupskouProject.Rashka.Bullets {

    public class SphericalRoundBullet : RoundBullet {

//        private readonly float _v;

//        private          float _z;
//        private readonly float _radius;
//        private          XY    _p;
//        private readonly float _dir;
//        private readonly float _period;


        private float __r, __angle0;
        private XY    __v, __offset;


        public SphericalRoundBullet (XY offset0, float z0, float r, XY v, XY o0) {
            __v            = v;
            __angle0       = Mathf.Atan2 (z0, offset0.X);
            var axisOffset = XY.Project (offset0, v.Rotated90CW ());
            __offset       = o0 + axisOffset;
            __r            = Mathf.Sqrt (r * r - axisOffset.SqrLength);
            BorderColor = Color.Red;
            MainColor = Color.Red;
            R = 5;
        }


//        void __Init () {
//            __angle0 = Mathf.Atan2 (__z0, __offset0.X);
//            __axisOffset = XY.Project (__offset0, __v.Rotated90CW ());
//            __r2 = Mathf.Sqrt (__r * __r - __axisOffset.SqrLength);
//        }


        void __Update (int t) {
            P = __offset + __v * t + __r * __v * Mathf.Cos (__angle0 + t / (Mathf.PI * 6));
        }


//        public SphericalRoundBullet (
//            XY p,
//            float dir,
//            float v,
//            Color mainColor,
//            Color borderColor,
//            float r,
//            float radius
//        ) {
//            _p          = p;
//            _dir        = dir;
//            _v          = v;
//            MainColor   = mainColor;
//            BorderColor = borderColor;
//            R           = r;

//            _radius = radius;

//            _period = 2 * Mathf.PI * _radius / v;
//        }


        protected override void Update (int t) {
            __Update (t);
            //          _angle1 = _angle1 + Mathf.Sin(_dir) * 2 * Mathf.PI / _period;
            //          _angle2 = _angle2 + Mathf.PI/180;
//            P = _p;
//            if (t > 30 && !Geom.CircleOverBox (new Circle (P, R + 2), World.Box)) {
//                Despawn ();
//            }
        }

    }

}