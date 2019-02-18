using System;
using System.Xml;
using NupskouProject.Core;
using NupskouProject.Entities.Bomb.Projectiles;
using NupskouProject.Math;
using NupskouProject.Rashka.Bullets;
using NupskouProject.Util;
using OpenAL;

namespace NupskouProject.Entities.Bomb
{
    public class DelayedExplosin: StdEntity
    {
        private int _r = 125;
        private int _n = 6;
        private XY[] coordinate = new XY[12];

        public DelayedExplosin()
        {
            var world = _.World;
            
            for (int i = 0; i < _n; i++)
            {
                coordinate[i] = new XY(-9000, -9000);
            }

            for (int i = 0; i < _n; i++)
            {
                bool g = false;
                int attempts = 0;
                while (g == false && attempts < 25)
                {
                    var a = _.Random.Point(World.Box);
                    g = Check(a, i);
                    attempts++;
                }

            }

            for (int j = 0; j < _n; j++)
            {
                world.Spawn(new DDEBullet(_.Player.Position,
                    new XY(XY.DirectionAngle(_.Player.Position, 
                        coordinate[j])).WithLength(XY.Distance(_.Player.Position, coordinate[j]))/60));
            }

        }

        protected override void Update(int t)
        {
            if (t == 1) Despawn();
        }

        private bool Check(XY a, int index)
        {
            for (int i = 0; i < _n; i++)
            {
                if (XY.Distance(a, coordinate[i]) < 1.5f * _r)
                {
                    return false;
                }
            }

            coordinate[index] = a;
            return true;

        }
    }
}
