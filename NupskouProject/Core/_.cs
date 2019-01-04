using System;
using NupskouProject.Entities;
using NupskouProject.Rendering;


namespace NupskouProject.Core {

    public static class _ {

        public static World      World      = new World ();
        public static int        Time       = 0;
        public static int        Scope      = 0;
        public static int        ScopeValue = 10000;
        public static int        Graze      = 0;
        public static int        LifeCount  = 3;
        public static int        BombCount  = 3;
        public static Renderer   Renderer   = new Renderer ();
        public static Assets     Assets     = new Assets ();
        public static Random     Random     = new Random ();
        public static Difficulty Difficulty = Difficulty.Lunatic;

        public static Player Player;


    }

}