using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Rashka.Bullets;
using NupskouProject.Util;


namespace NupskouProject.Rashka
{
    public class WormBlasterSpawner: StdEntity
    {
        private XY P;
        private Box _wormspawn = new Box(World.Box.Left,World.Box.Top,World.Box.Right,World.Box.Bottom*0.3f);



        public WormBlasterSpawner(XY p)
        {
            P = p;
        }
        

        protected override void Update(int t)
        {
            if (t % 30 == 0)
            {
                _.World.Spawn(
                    new CircularPetalBullet(
                        P,
                        new XY(0 + Mathf.PI/180*222 * t),
                        Mathf.PI / 360,
                        1f,
                        Color.Red,
                        Color.Red,
                        3f
                    )
                );
              
            }
            if (t % 30 == 0)
            {
                _.World.Spawn(
                    new CircularPetalBullet(
                        P,
                        new XY(0  + Mathf.PI/180*222 * t),
                        -Mathf.PI / 360,
                        1f,
                        Color.Red,
                        Color.Red,
                        3f
                    )
                );
                
            }

            if (t % 90 == 0)
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