using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Rashka.Bullets;
using NupskouProject.Util;

namespace NupskouProject.Rashka.Spells.WormBlasterSpawner
{
    public class WormBlasterSpawner: StdEntity
    {
        private XY P;
        private Box _wormspawn = new Box(World.Box.Left,World.Box.Top,World.Box.Right,World.Box.Bottom*0.3f);



        public WormBlasterSpawner(XY p)
        {
            P = p;
        }

        private void Shoot()
        {
            var w = (_.Player.Position - P).Normalized ;
            var n = 1;
            int _bullet;
            var spray  = Danmaku.Spray (w, Mathf.PI, 20);
            foreach (var v in spray)
            {
                if (n == 1 || n % _.Difficulty.Choose (4, 4, 4, 3) == 0)
                    _bullet = _.Difficulty.Choose (4, 6, 8, 12);
                else

                    _bullet = _.Difficulty.Choose (2, 3, 4, 4);
                
                var line = Danmaku.Line(v, 0.5f, 1f, _bullet);
                foreach (var v1 in line)
                {
                    _.World.Spawn(
                        new LinearRoundBullet( // вместо раундбуллета стрелки сделать
                            P,
                            2 * v1,
                            Color.Red,
                            Color.Red
                        )
                        );
                }

                n++;
                
            }
            
        }

        protected override void Update(int t)
        {
            if (t % 240 == 0)
            {
                Shoot();
            }


            if (t % _.Difficulty.Choose (120, 120, 120, 90) == 0)
            {
                _.World.Spawn(new WormBlaster(
                    _.Random.Point (_wormspawn),
                    0.01f,
                    (_.Player.Position - P).Normalized
                    ));
            }

 
        }
    }
}