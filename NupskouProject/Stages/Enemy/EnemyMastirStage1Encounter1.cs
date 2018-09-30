using System;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;


namespace NupskouProject.Stages.Enemy {

    public class EnemyMastirStage1Encounter1 : Entities.Enemy {

        private          XY   _p;
        private readonly XY   _v;
        private readonly bool _shoot;
        private          int  _t;
        private          int  _side;
        private          int  _spindelay;


        public EnemyMastirStage1Encounter1 (XY p, XY v, bool shoot, int side) {
            HP         = 20;
            _p         = p;
            _v         = v;
            _shoot     = shoot;
            _t         = Convert.ToInt32 (World.Box.Right) / 2;
            _side      = side;
            _spindelay = 90;

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

            if (_shoot && t % 90 == 0) {
                _.World.Spawn (
                    new LinearRoundBullet (
                        P,
                        new XY (XY.DirectionAngle (P, _.Player.Position)),
                        Color.Red,
                        Color.Orange,
                        5
                    )
                );

            }

        }

    }

}