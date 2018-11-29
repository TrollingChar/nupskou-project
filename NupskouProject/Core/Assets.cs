using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NupskouProject.Rendering;
using NupskouProject.Util;
using Un4seen.Bass;


namespace NupskouProject.Core {

    public class Assets {

        private const string SoundPrefix = "../../Assets/";

        public Sprite Circle;
        public Sprite Petal;
        public Sprite PetalBeam;
        public Sprite RedStar;
        public Sprite UI;
        public SpriteFont UItext;

        public Sound Pjiu;              


        public void Load (ContentManager content) {
            Circle    = Sprite.Load (content.Load <Texture2D> ("Assets/circle"),    64);
            Petal     = Sprite.Load (content.Load <Texture2D> ("Assets/petal"),     32);
            PetalBeam = Sprite.Load (content.Load <Texture2D> ("Assets/petalbeam"), 16);
            RedStar   = Sprite.Load (content.Load <Texture2D> ("Assets/redstar"),   192);
            UI        = Sprite.Load (content.Load <Texture2D> ("Assets/ui"),        1, Vector2.Zero);

            UItext    = content.Load<SpriteFont>("Assets/font_arial") ;
            Bass.BASS_Init (-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);

            Pjiu = Sound.Load (SoundPrefix + "pjiu.wav", 32);
            
        }


        public void Unload () {
            Pjiu.Unload ();
            Bass.BASS_Free ();
        }

    }

}