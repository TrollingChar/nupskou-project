using System;


namespace NupskouProject {

    public class Clock : StdEntity {

        private int         _delay;
        private int         _interval;
        private int         _iterations;
        private Func <bool> _f;


        public Clock (Func <bool> f, int delay, int interval, int iterations) {
            _delay      = delay;
            _interval   = interval;
            _iterations = iterations;
            _f          = f;
        }


        protected override void Update (int t) {
            t -= _delay;
            if (t < 0 || t % _interval != 0) return;
            t /= _interval;
            if (_f () || --_iterations == 0) Despawn ();
        }

    }

}