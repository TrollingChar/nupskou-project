using System;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Util;
using Un4seen.Bass.AddOn.DShow;
using Un4seen.Bass.Misc;

namespace NupskouProject.Rashka.Bullets {

    public class GrenadeBullet : RoundBullet {

        private readonly XY _p0;
        private readonly XY _v;
        private readonly int _delay;
        private float _random;

        public GrenadeBullet (XY p0, XY v, Color mainColor, Color borderColor, float r , int delay) {
            _p0         = p0;
            _v          = v;
            MainColor   = mainColor;
            BorderColor = borderColor;
            R           = r;
            _delay = delay;
        }


        protected override void Update (int t)
        {
            P = _p0 + t * _v;
            if (t > _delay)
            {
                _random = _.Random.Float(0, 2 * Mathf.PI);
                _.World.Spawn(new DemomanExplosion(P, 10, 120));
                var circle = Danmaku.Ring(new XY(_random), 5);
                foreach (var v in circle)
                {
                    _.World.Spawn(
                        new DelayedLinearPetalBullet(
                            new XY(P.X+v.X*7, P.Y+v.Y*7), 
                            v,
                            Color.DarkRed,
                            Color.Red,
                            3f,
                            120
                        ));
                }

                if (_.Difficulty >= Difficulty.Hard)
                {
                    circle = Danmaku.Ring(new XY(_random), _.Difficulty.Choose(0,0,3,5));
                    foreach (var v in circle)
                    {
                        _.World.Spawn(
                            new DelayedLinearPetalBullet(
                                new XY(P.X + v.X * 5, P.Y + v.Y * 5),
                                v,
                                Color.Yellow,
                                Color.Red,
                                3f,
                                30
                            ));
                    }
                }


                Despawn();
            }

            if (t > 30 && !Geom.CircleOverBox (new Circle (P, R + 2), World.Box)) {
                Despawn ();
            }
        }

    }

}