using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Util;


namespace NupskouProject.Raden.Revolt {

    public class Revolt : StdEntity {

        /* пусть остается, раз уж нарисовал
         *    /\
         * --'  `--
         *  (>  <)
         *  / ^  \
         */


        protected override void Update (int t) {
            switch (t % 600) {
                case 0:
                    SpawnLeftHugeStar ();
                    break;
                case 300:
                    SpawnRightHugeStar ();
                    break;
            }
//            if (t % 180 == 0) {
//                SpawnHugeStars ();
//            }
        }


        private void SpawnLeftHugeStar () {
            _.World.Spawn (
                new HugeStar (
                    new XY (World.Box.Left + 80, World.Box.Top - HugeStar.Size),
                    1.5f * XY.Down,
                    0,
                    Mathf.PI / 300
                )
            );
        }


        private void SpawnRightHugeStar () {
            _.World.Spawn (
                new HugeStar (
                    new XY (World.Box.Right - 80, World.Box.Top - HugeStar.Size),
                    1.5f * XY.Down,
                    0,
                    -Mathf.PI / 300
                )
            );
        }


/*
        private void SpawnHugeStars () {
            float x1 = World.Box.Left + 35;
            float x2 = World.Box.Right - 35;
            float y1 = World.Box.Top - HugeStar.Size;
//            float y2 = World.Box.Bottom + HugeStar.Size;
            _.World.Spawn (new HugeStar (new XY (x1, y1), 1.5f * XY.Down, 0, +Mathf.PI / 300));
            _.World.Spawn (new HugeStar (new XY (x2, y1), 1.5f * XY.Down, 0, -Mathf.PI / 300));
        }
*/

    }

}