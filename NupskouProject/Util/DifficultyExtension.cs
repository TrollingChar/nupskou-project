using System;


namespace NupskouProject.Util {

    public static class DifficultyExtension {

        public static T Choose <T> (this Difficulty d, T easy, T normal, T hard, T lunatic) {
            switch (d) {
                case Difficulty.Easy:    return easy;
                case Difficulty.Normal:  return normal;
                case Difficulty.Hard:    return hard;
                case Difficulty.Lunatic: return lunatic;
                default:                 throw new ArgumentOutOfRangeException (nameof (d), d, null);
            }
        }

    }

}