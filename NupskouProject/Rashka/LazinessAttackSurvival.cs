using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Rashka.Bullets;
using NupskouProject.Util;


namespace NupskouProject.Rashka

{
    public class LazinessAttackSurvival : StdEntity
    {
        private int _delay = 300;
        private int _bulletsize = 15;
        public LazinessAttackSurvival()
        {
            
        }

        protected override void Update(int t)
        {
            if (t == 1)
            {
            InicialiseArena();
            }

        }

        private void InicialiseArena()
        {
            
                for (int i = 0; i < 5; i++)
                {

                    var w = XY.Down.WithLength(World.Box.Bottom / _delay);
                    var line = Danmaku.Line(w, 0.083f, 1, 12);
                    foreach (var v in line)
                    {
                        _.World.Spawn(
                            new StoppingLinearRoundBullet(
                                new XY(0 + World.Box.Right / 5 * i, 0),
                                v,
                                Color.Blue,
                                Color.Blue,
                                _bulletsize,
                                _delay
                            ));

                    }
                }

                for (int i = 0; i < 6; i++)
                {
                    var w = XY.Right.WithLength(World.Box.Right / _delay);
                    var line = Danmaku.Line(w, 0.1f, 1, 10);
                    foreach (var v in line)
                    {
                        _.World.Spawn(
                            new StoppingLinearRoundBullet(
                                new XY(0, World.Box.Bottom / 12 + World.Box.Bottom / 6 * i),
                                v,
                                Color.Blue,
                                Color.Blue,
                                _bulletsize,
                                _delay
                            ));

                    }
                }

            }
    }
}