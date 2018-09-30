using System.CodeDom;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Util;

namespace NupskouProject.Rashka.Bullets
{
    public class SphereBullets :StdEntity
    {
        private readonly XY  _p;
        private readonly float _r;
        private readonly int _n;
        private readonly float _dir;
        
        public SphereBullets(XY p, float r, int n, float dir) 
        {
            _p = p;
            _r = r;
            _n = n;
            _dir = dir;
        }

        protected override void Update(int t)
        {
            if (t == 0)
            {
                for (int i = 0; i < _n; i++)
                {
                    for (int j = 0; j < _n; j++)
                    {
                        _.World.Spawn(new SphericalRoundBullet(
                            new XY(_r * Mathf.Cos(i * 2 * Mathf.PI / _n)* Mathf.Sin(j * Mathf.PI / _n), _r * Mathf.Sin(i * 2 * Mathf.PI / _n)* Mathf.Sin(j * Mathf.PI / _n)) ,
                            _r * Mathf.Cos(j * Mathf.PI / _n),
                            _r,
                            new XY(_dir),
                            _p
                        ));
                        /*               new XY(_p.X+_r*Mathf.Cos(i * 2 * Mathf.PI / _n)*Mathf.Sin(j * Mathf.PI / _n), _p.Y+_r*Mathf.Sin(i * 2 * Mathf.PI / _n)*Mathf.Sin(j * Mathf.PI / _n)),
                                       _dir,
                                       1f,
                                       Color.Blue, 
                                       Color.BlueViolet,
                                       5f,
                                       _r 
                                   ));*/
                    }

                }

            }
        }
    }
}