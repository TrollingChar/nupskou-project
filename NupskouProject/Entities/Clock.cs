using System;


namespace NupskouProject.Entities {

    public class Clock : StdEntity {

        private int          _delay;
        private int          _interval;
        private int          _iterations;
        private Action <int> _f;


        public Clock (Action <int> f, int iterations, int interval, int delay = 0) {
            _delay      = delay;
            _interval   = interval;
            _iterations = iterations;
            _f          = f;
        }


        protected override void Update (int t) {
            t -= _delay;
            if (t < 0 || t % _interval != 0) return;
            t /= _interval;
            if (t < _iterations) _f (t);
            else                 Despawn ();
        }

    }

}