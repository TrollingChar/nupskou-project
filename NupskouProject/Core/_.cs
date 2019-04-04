using System;
//using NupskouProject.Entities;
using NupskouProject.Rendering;


namespace NupskouProject.Core {

    public static class _ {

        public static World           World           = new World ();
        public static int             Time            = 0;
        
        public static Renderer        Renderer        = new Renderer ();
        public static GameData        GameData;
        public static Assets          Assets          = new Assets ();
        public static Random          Random          = new Random ();
        public static Difficulty      Difficulty      = Difficulty.Lunatic;
        public static PlayerCharacter PlayerCharacter = PlayerCharacter.Rashka;
        //public static Player          Player;

    }

}