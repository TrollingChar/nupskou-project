using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;


namespace NupskouProject.Raden.Airstrike {

    public class Smoke : RoundBullet {

        private readonly XY _p0;
        private readonly XY _s;
        private float _r0;


        public Smoke (XY p0, XY s, float r0 = 30) {
            _p0         = p0 + s;
            _s          = s;
            MainColor   = Color.Silver;
            BorderColor = Color.Gray;
            _r0         = r0;
        }


        protected override void Update (int t) {
            R = _r0 - 0.5f * t;
            if (R <= 0) {
                Despawn ();
                return;
            }
            P = _p0 - _s * Mathf.Pow (0.9f, t);
        }

    }

}