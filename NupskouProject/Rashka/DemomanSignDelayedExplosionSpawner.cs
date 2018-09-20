using System.Data;
using System.Runtime.InteropServices.ComTypes;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Rashka.Bullets;
using NupskouProject.Util;

namespace NupskouProject.Rashka
{
    public class DemomanSignDelayedExplosionSpawner : StdEntity
    {

        private int _r = 75;
        private int _n = 12;
        private XY[] coordinate = new XY[12];



        protected override void Update(int t)
        {
            if (t % 240 == 0)
            {
                for (int i = 0; i < _n; i++)
                {
                    coordinate[i] = new XY(-9000, -9000);
                }

                for (int i = 0; i < _n; i++)
                {
                    bool g = false;
                    int attempts = 0;
                    while (g == false && attempts < 100)
                    {
                        var a = _.Random.Point(World.Box);
                        g = Check(a, i);
                        attempts++;
                    }

                }

                for (int j = 0; j < _n; j++)
                {
                    _.World.Spawn(new DemomanCircle(coordinate[j], _r, 15, 90));
                }
            }



        }

        private bool Check(XY a, int index)
        {
            for (int i = 0; i < _n; i++)
            {
                if (XY.Distance(a, coordinate[i]) < 2 * _r)
                {
                    return false;
                }
            }

            coordinate[index] = a;
            return true;

        }
    }
}