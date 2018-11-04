using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Util;

namespace NupskouProject.Stages.Enemy
{
    public class DropperEnemyStage1Encounter3 : Entities.Enemy
    {
        private XY _p;
        private XY _v;
        private bool _shoot;
        private int n = _.Difficulty.Choose(2,3,4,5);


        public DropperEnemyStage1Encounter3(XY p, XY v)
        {
            HP = 10;
            _p = p;
            _v = v;
            _shoot = true;

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
                P = _p + _v * t;
            if (_shoot && P.X - _.Player.Position.X < 20 && P.X - _.Player.Position.X > -20)
            {
                Shoot(t);
                _shoot = false;
            }

        }

        private void Shoot(int t)
        {
            _.World.Spawn(new LinearPetalBullet(
                new XY(P.X,P.Y),
                XY.Down.WithLength (3), 
                Color.Yellow,
                Color.Yellow,
                2f
            ));
            for (int i = 1; i < n; i++)
            {
                _.World.Spawn(new LinearPetalBullet(
                    new XY(P.X+i*6,P.Y+i*6),
                    XY.Down.WithLength (3), 
                    Color.Yellow,
                    Color.Yellow,
                    4f
                ));
            }
            for (int i = 1; i < n; i++)
            {
                _.World.Spawn(new LinearPetalBullet(
                    new XY(P.X-i*6,P.Y+i*6),
                    XY.Down.WithLength (3), 
                    Color.Yellow,
                    Color.Yellow,
                    4f
                ));
            }


            }
            }


    }

