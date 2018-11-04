using Un4seen.Bass;


namespace NupskouProject.Util {

    public class Sound {

        private readonly int _sample;


        private Sound (int sample) {
            _sample = sample;
        }


        public static Sound Load (string filename, int maxInstances) {
            return new Sound (Bass.BASS_SampleLoad (filename, 0, 0, maxInstances, BASSFlag.BASS_DEFAULT));
        }


        public void Play (float volume = 100) {
            int channel = Bass.BASS_SampleGetChannel (_sample, false);
            Bass.BASS_ChannelPlay (channel, false);
            Bass.BASS_ChannelSetAttribute (channel, BASSAttribute.BASS_ATTRIB_VOL, volume);
        }


        public void Unload () {
            Bass.BASS_SampleFree (_sample);
        }

    }

}