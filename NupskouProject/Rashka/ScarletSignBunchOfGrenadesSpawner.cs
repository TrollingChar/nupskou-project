using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Rashka.Bullets;
using NupskouProject.Util;

namespace NupskouProject.Rashka
{
    public class ScarletSignBunchOfGrenadesSpawner : StdEntity
    {
        private int N = _.Difficulty.Choose(18,30,30,42);
        private XY[] coordinate = new XY[_.Difficulty.Choose(18,30,30,42)];
        private XY _p;


        public ScarletSignBunchOfGrenadesSpawner(XY p)
        {
            _p = p;
        }



        protected override void Update(int t)
        {
            var world = _.World;
            if (t % 360 == 0)
            {
                for (int i = 0; i < N; i++)
                {
                    coordinate[i] = new XY(-9000, -9000);
                }

                for (int i = 0; i < N; i++)
                {
                    bool g = false;
                    int attempts = 0;
                    while (g == false && attempts < 10)
                    {
                        var a = _.Random.Point(World.Box);
                        g = Check(a, i);
                        attempts++;
                    }

                }

                for (int j = 0; j < N; j++)
                {
                    world.Spawn(new GrenadeBullet(
                        _p,
                        new XY(XY.DirectionAngle(_p, coordinate[j])).WithLength(XY.Distance(_p, coordinate[j]) / 150),
                        Color.Red,
                        Color.Red,
                        5f,
                        150)
                    );
                }
            }



        }

        private bool Check(XY a, int index)
        {
            for (int i = 0; i < N; i++)
            {
                if (XY.Distance(a, coordinate[i]) < 15)
                {
                    return false;
                }
            }

            coordinate[index] = a;
            return true;

        }
    }
}

