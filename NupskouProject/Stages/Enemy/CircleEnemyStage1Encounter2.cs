using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Util;

namespace NupskouProject.Stages.Enemy
{
    public class CircleEnemyStage1Encounter2 : Entities.Enemy
    {
        private XY _p;
        private XY _v;
        private float _random;


        public CircleEnemyStage1Encounter2(XY p, XY v)
        {
            HP = 50;
            _p = p;
            _v = v;


        }


        public override void OnStruck(Entity entity)
        {
            HP = HP - 1;
            if (HP == 0) Despawn();
        }

        protected override void Update(int t)
        {
            if (t > 30 && !Geom.CircleOverBox (new Circle (P, 10 + 2), World.Box)) {
                Despawn ();
            }
            if (t < 60)
                P = _p + _v * t;
            if (t % 120 == 0)
                _random = _.Random.Float(0, 2 * Mathf.PI);
            if (t % 120 < 60 && t % _.Difficulty.Choose(30,20,15,10) == 0)
            {
                Shoot();
            }

            if (t == 479)
                _v =_v * -1;
            if (t > 480)
                P = _p  + _v * (t-540) ;

        }

        private void Shoot()
        {
            
                var circle = Danmaku.Ring(new XY(_random), _.Difficulty.Choose(8, 12, 18, 24));
                foreach (var v in circle)
                {
                    _.World.Spawn(
                        new LinearRoundBullet(
                            P,
                            v * _.Difficulty.Choose(2f, 2f, 2f, 3f),
                            Color.Blue,
                            Color.Blue
                        )
                    );
                }
            }

        }
    }
