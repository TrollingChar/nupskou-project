using System;
using System.CodeDom;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Util;
using Un4seen.Bass.Misc;

namespace NupskouProject.Rashka.Bullets
{
    public class DemomanCircle :StdEntity
    {
        
        private readonly XY  _p;
        private readonly float _r;
        private readonly int _n;
        private readonly int _delay;
        private readonly float _random;
        
        public DemomanCircle(XY p, float r, int n, int delay)
        {
            _p = p;
            _r = r;
            _n = n;
            _delay = delay;
            _random = _.Random.Float(0, 2 * Mathf.PI);

        }

        protected override void Update(int t)
        {
            if (t == 0)
            {
                for (int i = 0; i <= _n; i++)
                {
                    if (XY.Distance(_p, _.Player.Position) > 10){
                    _.World.Spawn(
                        new DelayedLinearRoundBullet(
                            new XY(_p.X+ Mathf.Cos(i * 2 * Mathf.PI/_n + _random) *_r, _p.Y+ Mathf.Sin(i * 2 * Mathf.PI/_n + _random)*_r),
                            new XY(Mathf.Cos(i * (2 * Mathf.PI/_n )+ _random),Mathf.Sin(i * (2 * Mathf.PI/_n) + _random))        , 
                            Color.Red,
                            Color.Red,
                            5,
                            _delay
                        )
                    );
                }
                    }

            }

            if (t == _delay)
            {
                _.World.Spawn(new DemomanExplosion(_p,_r,_delay));
                Despawn();
            }
        }
    }
}