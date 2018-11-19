using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;


namespace NupskouProject.Raden.SunflowerRockets {

    public class SunflowerSeed : PetalBullet {

        private readonly XY    _p0;
        private readonly XY    _v0;
        private readonly float _v1;
        private readonly float _v2;
        private readonly int   _t;


        public SunflowerSeed (XY p0, XY v0, float v1, float v2, int t) {
            _p0 = p0;
            V   = v0;
            _v1 = v1;
            _v2 = v2;
            _t  = t;
            MainColor = Color.Orange;
            BorderColor = Color.Brown;
            R = 3;
        }


        protected override void Update (int t) {
            if (t <= _t) {
                P = _p0 + Mathf.Sqrt (t) * _v1 * V;
            }
            else {
                P = _p0 + Mathf.Sqrt (_t) * _v1 * V + (t - _t) * _v2 * V;
            }
            
            if (t > 30 && !Geom.CircleOverBox (new Circle (P, R + 2), World.Box)) {
                Despawn ();
            }
        }

    }

}