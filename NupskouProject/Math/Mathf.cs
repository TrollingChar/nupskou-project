namespace NupskouProject.Math {

    public static partial class Mathf {

        public static float Sin (float f)            { return (float) System.Math.Sin (f); }
        public static float Cos (float f)            { return (float) System.Math.Cos (f); }
        public static float Tan (float f)            { return (float) System.Math.Tan (f); }
        public static float Asin (float f)           { return (float) System.Math.Asin (f); }
        public static float Acos (float f)           { return (float) System.Math.Acos (f); }
        public static float Atan (float f)           { return (float) System.Math.Atan (f); }
        public static float Atan2 (float y, float x) { return (float) System.Math.Atan2 (y, x); }
        public static float Sqrt (float f)           { return (float) System.Math.Sqrt (f); }
        public static float Pow (float f, float p)   { return (float) System.Math.Pow (f, p); }
        public static float Exp (float power)        { return (float) System.Math.Exp (power); }
        public static float Log (float f, float p)   { return (float) System.Math.Log (f, p); }
        public static float Log (float f)            { return (float) System.Math.Log (f); }
        public static float Log10 (float f)          { return (float) System.Math.Log10 (f); }
        public static float Ceil (float f)           { return (float) System.Math.Ceiling (f); }
        public static float Floor (float f)          { return (float) System.Math.Floor (f); }
        public static float Round (float f)          { return (float) System.Math.Round (f); }
        public static int   CeilToInt (float f)      { return (int) System.Math.Ceiling (f); }
        public static int   FloorToInt (float f)     { return (int) System.Math.Floor (f); }
        public static int   RoundToInt (float f)     { return (int) System.Math.Round (f); }

        public const float PI       = (float) System.Math.PI;
        public const float Deg2Rad  = 2 * PI / 360;
        public const float Rad2Deg  = 1 / Deg2Rad;
        public const float Phi      = 1.61803398875f;
        public const float phi      = 0.61803398875f;
        public const float phiAngle = 2f * PI * phi;


        public static float Clamp (float value, float min, float max) {
            if (value < min)
                value = min;
            else if (value > max)
                value = max;
            return value;
        }


        public static int Clamp (int value, int min, int max) {
            if (value < min)
                value = min;
            else if (value > max)
                value = max;
            return value;
        }


        public static float Clamp01 (float value) {
            if (value < 0F)
                return 0F;
            else if (value > 1F)
                return 1F;
            else
                return value;
        }


        public static float Lerp (float a, float b, float t) {
            return a + (b - a) * Clamp01 (t);
        }


        public static float LerpUnclamped (float a, float b, float t) {
            return a + (b - a) * t;
        }


        public static float LerpAngle (float a, float b, float t) {
            float delta = Repeat ((b - a), 360);
            if (delta > 180)
                delta -= 360;
            return a + delta * Clamp01 (t);
        }


//        static public float MoveTowards (float current, float target, float maxDelta) {
//            if (Math.Abs (target - current) <= maxDelta)
//                return target;
//            return current + Mathf.Sign (target - current) * maxDelta;
//        }


//        static public float MoveTowardsAngle (float current, float target, float maxDelta) {
//            float deltaAngle = DeltaAngle (current, target);
//            if (-maxDelta < deltaAngle && deltaAngle < maxDelta)
//                return target;
//            target = current + deltaAngle;
//            return MoveTowards (current, target, maxDelta);
//        }


        public static float SmoothStep (float from, float to, float t) {
            t = Clamp01 (t);
            t = -2.0F * t * t * t + 3.0F * t * t;
            return to * t + from * (1F - t);
        }


        public static float Repeat (float t, float length) {
            return Clamp (t - Floor (t / length) * length, 0.0f, length);
        }


        public static float PingPong (float t, float length) {
            t = Repeat (t, length * 2F);
            return length - System.Math.Abs (t - length);
        }


        public static float InverseLerp (float a, float b, float value) {
            return a == b ? 0.0f : Clamp01 ((value - a) / (b - a));
        }


        public static float DeltaAngle (float current, float target) {
            float delta = Repeat ((target - current), 360.0F);
            if (delta > 180.0F)
                delta -= 360.0F;
            return delta;
        }

    }

}