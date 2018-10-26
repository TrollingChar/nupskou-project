using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Stages.Enemy;
using NupskouProject.Util;


namespace NupskouProject.Stages {

    public class Stage1 : StdEntity {
        protected override void Update (int t) {
            switch (t) {
                case 120:
                    _.World.Spawn(new Clock(
                            i => _.World.Spawn(new EnemyMastirStage1Encounter1(
                                new XY(World.Box.Left, World.Box.Bottom * 0.1f), XY.Right, i % _.Difficulty.Choose (6, 3, 2, 2)  == 0, -1)),
                            12,
                            //Раден, ты ⑨
                            30,
                            0
                        )
                    );
                    _.World.Spawn(new Clock(
                            i => _.World.Spawn(new EnemyMastirStage1Encounter1(
                                new XY(World.Box.Right, World.Box.Bottom * 0.1f),   XY.Left, i % _.Difficulty.Choose (6, 3, 2, 2)  == 0, 1)),
                            12,
                            30,
                            0
                        )
                    );
                    break;
                case 600:
                    break;
                case 900:
                    break;
                case 1200:
                    break;
            }
        }

    }

}