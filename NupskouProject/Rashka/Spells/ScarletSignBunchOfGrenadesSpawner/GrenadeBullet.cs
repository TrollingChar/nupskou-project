using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Rashka.Bullets;
using NupskouProject.Util;

namespace NupskouProject.Rashka.Spells.ScarletSignBunchOfGrenadesSpawner {

    public class GrenadeBullet : RoundBullet {

        private readonly XY    _p0;
        private readonly XY    _v;
        private readonly int   _delay;
        private          float _random;


        public GrenadeBullet (XY p0, XY v, Color mainColor, Color borderColor, float r, int delay) {
            _p0         = p0;
            _v          = v;
            MainColor   = mainColor;
            BorderColor = borderColor;
            R           = r;
            _delay      = delay;
        }


        protected override void Update (int t) {
            P = _p0 + t * _v;
            if (t < _delay) return;

            _random = _.Random.Angle ();

            _.World.Spawn (new DemomanExplosion (P, 10, 120));

            foreach (var v in Danmaku.Ring (new XY (_random), _.Difficulty.Choose (5, 7, 5, 7))) {
                _.World.Spawn (
                    new DelayedLinearPetalBullet (
                        new XY (P.X, P.Y),
                        v*0.75f,
                        Color.DarkRed,
                        Color.Red,
                        3f,
                        120,
                        21
                    )
                );
            }
            foreach (var v in Danmaku.Ring (new XY (_random + Mathf.PI/_.Difficulty.Choose (0, 0, 5, 7)), _.Difficulty.Choose (0, 0, 5, 7))) {
                _.World.Spawn (
                    new DelayedLinearPetalBullet (
                        new XY (P.X + v.X * 5, P.Y + v.Y * 5),
                        v*0.75f,
                        Color.Yellow,
                        Color.Red,
                        3f,
                        120
                    )
                );
            }
            Despawn ();
        }

    }

}