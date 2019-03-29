using Microsoft.Xna.Framework;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Raden.Bullets;
using NupskouProject.Util;


namespace NupskouProject.Raden.Revolt {

    public class Revolt : StdEntity {

        private int   _dt;
        private float _v;
        private float _av;
        private float _leftSpawn;
        private float _rightSpawn;
        private float _ySpawn;


        /* пусть остается, раз уж нарисовал
         *    /\
         * --'  `--
         *  (>  <)
         *  / ^  \
         */
        public Revolt () {
            _dt         = 300;
            _v          = 1.5f;
            _av         = Mathf.PI / _dt;
            float dx    = _v * _dt * Mathf.Tan (Mathf.Deg2Rad * 36);
            _leftSpawn  = (World.Box.Left + World.Box.Right - dx) * 0.5f;
            _rightSpawn = _leftSpawn + dx;
            _ySpawn     = World.Box.Top - HugeStar.Size;
        }


        protected override void Update (int t) {
            t = t % (2 * _dt);
            if (t == 0) {
                SpawnLeftHugeStar ();
            }
            else if (t == _dt) {
                SpawnRightHugeStar ();
            }

//            10 easy 5 normal
//            if (t % 5 == 0) {
//                var spawnPoint = new XY (Mathf.Lerp (World.Box.Left, World.Box.Right, _.Random.Float ()), World.Box.Top);
//                _.World.Spawn (
//                    new LinearRoundBullet (
//                        spawnPoint,
//                        (_.Player.Position - spawnPoint).WithLength (3),
//                        Color.Red,
//                        Color.Red
//                    )
//                );
//            }
        }


        private void SpawnLeftHugeStar () {
            _.World.Spawn (new HugeStar (new XY (_leftSpawn, World.Box.Top - HugeStar.Size), new XY (0, _v), 0, _av));
        }


        // расстояние между звездами по X равно 470 - 30 - 70 - 70 = 300
        // а должно быть 450 * tg (pi/5) = 326 примерно
        // звезды спавнятся с интервалом 300 поэтому по Y расстояние будет 450
        // скорость вращения это 180 градусов поделить на t хм там как раз так и есть


        private void SpawnRightHugeStar () {
            _.World.Spawn (new HugeStar (new XY (_rightSpawn, _ySpawn), new XY (0, _v), 0, -_av));
        }

    }

}