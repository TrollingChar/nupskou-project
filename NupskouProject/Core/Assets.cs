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
        public Sprite UI;

        public Sound Pjiu;


        public void Load (ContentManager content) {
            Circle = Sprite.Load (content.Load <Texture2D> ("Assets/circle"), 64);
            UI     = Sprite.Load (content.Load <Texture2D> ("Assets/ui"),     1, Vector2.Zero);

            Bass.BASS_Init (-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);

            Pjiu = Sound.Load (SoundPrefix + "pjiu.wav", 32);
        }


        public void Unload () {
            Pjiu.Unload ();
            Bass.BASS_Free ();
        }

    }

}