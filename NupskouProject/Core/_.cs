using System;
using NupskouProject.Entities;
using NupskouProject.Rendering;


namespace NupskouProject.Core {

    public static class _ {

        public static World           World           = new World ();
        public static int             Time            = 0;
        public static int             Score           = 0;
        public static int             ScoreValue      = 10000;
        public static int             Graze           = 0;
        public static int             LifeCount       = 3;
        public static int             BombCount       = 3;
        public static Renderer        Renderer        = new Renderer ();
        public static Assets          Assets          = new Assets ();
        public static Random          Random          = new Random ();
        public static Difficulty      Difficulty      = Difficulty.Lunatic;
        public static PlayerCharacter PlayerCharacter = PlayerCharacter.Rashka;
        public static Player          Player;

    }

}