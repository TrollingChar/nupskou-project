using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Util;

namespace NupskouProject.Stages.Enemy
{
    public class SpreadingEnemyStage1Encounter2 : Entities.Enemy
    {
        private XY _p;
        private XY _v;
        private float _random;


        public SpreadingEnemyStage1Encounter2(XY p, XY v)
        {
            HP = 30;
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
            
            var shotgun = Danmaku.Shotgun((_.Player.Position - P).Normalized,1,0.5f,1, _.Difficulty.Choose(4, 8, 15, 20));
            foreach (var v in shotgun)
            {
                _.World.Spawn(
                    new LinearRoundBullet(
                        P,
                        v * _.Difficulty.Choose(2f, 2f, 2f, 3f),
                        Color.Yellow,
                        Color.Yellow
                    )
                );
            }
        }

    }
}
