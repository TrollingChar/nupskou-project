using System;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Util;


namespace NupskouProject.Stages.Enemy {

    public class EnemyMastirStage1Encounter1 : Entities.Enemy {

        private          XY   _p;
        private readonly XY   _v;
        private readonly bool _shoot;
        private          int  _t;
        private          int  _side;
        private          int  _spindelay;


        public EnemyMastirStage1Encounter1 (XY p, XY v, bool shoot, int side) {
            HP         = 15;
            _p         = p;
            _v         = v;
            _shoot     = shoot;
            _t         = Convert.ToInt32 (World.Box.Right) / 2;
            _side      = side;
            _spindelay = 120;

        }


        public override void OnStruck (Entity entity) {
            HP = HP - 1;
            if (HP == 0) Despawn ();
        }


        protected override void Update (int t) {
            if (t < _t)
                P = _p + _v * t;
            if (t == _t) {
                _p = new XY (P.X,  P.Y + 100);
                P  = new XY (_p.X, _p.Y - 100);
            }
            if (t > _t)
                P = new XY (
                    _p.X + 100 * Mathf.Cos (-Mathf.PI / 2 - (t - _t) * Mathf.PI / _spindelay) * _side,
                    _p.Y + 100 * Mathf.Sin (-Mathf.PI / 2 - (t - _t) * Mathf.PI / _spindelay * _side)
                );

            if (t == _t + _spindelay) {
                _p = new XY (P.X, P.Y);
                P  = _p;
            }
            if (t > _t + _spindelay)
                P = _p - _v * (t - _t - _spindelay);

            if (_shoot && t % _.Difficulty.Choose(120, 60, 45, 45) == 0)
            {
                _.World.Spawn(
                    new LinearPetalBullet(
                        P,
                        _.Difficulty.Choose(2f, 2f, 3f, 4f) * new XY(XY.DirectionAngle(P, _.Player.Position)),
                        Color.Red,
                        Color.Orange,
                        3f
                    )
                );


            }

            if (_shoot == false && _.Difficulty >= Difficulty.Hard &&
                 t % _.Difficulty.Choose(9999, 9999, 180, 120) == 0)
                AlternateShoot(t);
            if (t > 30 && !Geom.CircleOverBox (new Circle (P, 10 + 2), World.Box)) {
                Despawn ();
            }

        }

        private void AlternateShoot(int t)
        {
        {
            var w = (_.Player.Position - P).Normalized ;
            var line  = Danmaku.Line (w, 1, 2, _.Difficulty.Choose(9999, 9999, 3, 4));
            foreach (var v in line) {
                _.World.Spawn(
                    new LinearRoundBullet(
                        P,
                        v,
                        Color.Blue,
                        Color.Blue
                    )
                );
            }
        }
        }

    }

}