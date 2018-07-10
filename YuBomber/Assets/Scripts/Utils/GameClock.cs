using System;

namespace Assets.Scripts.Game.Utils
{
    /// <summary>
    ///     游戏时钟
    /// </summary>
    internal sealed class GameClock
    {
        /// <summary>
        ///     当前系统时间的时间戳.
        /// </summary>
        private static long _mTimestamp = DateTime.Now.ToFileTime();

        /// <summary>
        ///     当前服务器时间时间戳.
        /// </summary>
        public static long Timestamp
        {
            get { return _mTimestamp; }

            set { _mTimestamp = value; }
        }

        public static long Offset { get; set; }

        public static DateTime Now()
        {
            return DateTime.FromFileTime(_mTimestamp + Offset);
        }
    }
}