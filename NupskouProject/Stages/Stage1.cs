using System;
using NupskouProject.Core;
using NupskouProject.Entities;
using NupskouProject.Math;
using NupskouProject.Stages.Enemy;
using NupskouProject.Util;


namespace NupskouProject.Stages {

    public class Stage1 : StdEntity {
        protected override void Update (int t) {
            switch (t) {
                case 60:
                    _.World.Spawn(new Clock(
                            i => _.World.Spawn(new EnemyMastirStage1Encounter1(
                                new XY(World.Box.Left, World.Box.Bottom * 0.1f), XY.Right, i % _.Difficulty.Choose (6, 3, 2, 2)  == 0, -1)),
                            12,
                            //а может быть ты
                            //⑨
                            30,
                            0
                        )
                    );
                    break;
                case 120:
                    _.World.Spawn(new Clock(
                            i => _.World.Spawn(new EnemyMastirStage1Encounter1(
                                new XY(World.Box.Right, World.Box.Bottom * 0.15f),   XY.Left, i % _.Difficulty.Choose (6, 3, 2, 2)  == 0, 1)),
                            12,
                            30,
                            0
                        )
                    );
                    break;
                case 780:
                   //здесь должна быть табличка, да
                    break;
                case 960:
                    _.World.Spawn(new CircleEnemyStage1Encounter2
                    (
                        new XY(World.Box.Right * 0.5f, 0),
                        XY.Down
                    )
                    );
                    break;
                case 1020:
                    _.World.Spawn(new SpreadingEnemyStage1Encounter2
                        (
                            new XY(World.Box.Left, World.Box.Bottom * 0.2f), XY.Right
                        )
                    );
                    break;
                case 1080:
                    _.World.Spawn(new SpreadingEnemyStage1Encounter2
                        (
                            new XY(World.Box.Right, World.Box.Bottom * 0.2f),   XY.Left
                        )
                    );
                    break;
                case 1440:
                    _.World.Spawn(new Clock(
                        i => _.World.Spawn(
                            new DropperEnemyStage1Encounter3(new XY(World.Box.Left, World.Box.Bottom * 0.2f),
                                XY.Right * 3)),
                        6,
                        120));
                    break;
                case 1470:
                    _.World.Spawn(new Clock(
                        i => _.World.Spawn(
                            new DropperEnemyStage1Encounter3(new XY(World.Box.Right, World.Box.Bottom * 0.2f),
                                XY.Left * 3)),
                        6,
                        120));
                    break;
                case 1750:
                    _.World.Spawn(new SpreadingEnemyStage1Encounter2
                        (
                            new XY(World.Box.Left, World.Box.Bottom * 0.4f), XY.Right
                        )
                    );
                    break;
                case 1870:
                    _.World.Spawn(new SpreadingEnemyStage1Encounter2
                        (
                            new XY(World.Box.Right, World.Box.Bottom * 0.4f),   XY.Left
                        )
                    );
                    break;
                case 3600:
                    //босс
                    break;
            }

        }

    }

}