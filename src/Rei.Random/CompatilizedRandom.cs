/*
 * Copyright (C) Rei HOBARA 2007
 * 
 * Name:
 *     CompatilizedRandom.cs
 * Class:
 *     Rei.Random.CompatilizedRandom
 * Purpose:
 *     A compatilizer of Rei.Random.RandomBase with System.Random.
 * Remark:
 * History:
 *     2007/10/6 initial release.
 * 
 */

using System;

namespace Rei.Random {

    /// <summary>
    /// Rei.Random.RandomBaseをSystem.Random互換にするアダプタクラス。
    /// 各メンバ関数の入力・出力はSystem.Randomと同じ範囲になります。
    /// Rei.Random.RandomBase派生クラスをSystem.Randomとして使いたい場合に用います。
    /// </summary>
    public class CompatilizedRandom : System.Random {
        private RandomBase original;

        /// <summary>
        /// randをソースとしてアダプタクラスを初期化します。
        /// </summary>
        CompatilizedRandom( RandomBase rand ) {
            original = rand;
        }

        /// <summary>
        /// [0,Int32.MaxValue)の擬似乱数を取得します。
        /// </summary>
        public override Int32 Next() {
            uint r;
            do
                r = original.NextUInt32() & 0x7FFFFFFF;
            while (r == Int32.MaxValue);
            return (Int32)r;
        }

        /// <summary>
        /// [0,maxValue)の擬似乱数を取得します。
        /// 但しmaxValue=0の場合は0を返します。
        /// </summary>
        public override Int32 Next( Int32 maxValue ) {
            return Next(0, maxValue);
        }

        /// <summary>
        /// [minValue,maxValue)の擬似乱数を取得します。
        /// ただし、minValue=maxValueのときはminValueを返します。
        /// </summary>
        public override Int32 Next( Int32 minValue, Int32 maxValue ) {
            if (minValue > maxValue) throw new ArgumentOutOfRangeException();
            if (minValue == maxValue) return minValue;
            UInt32 range = (UInt32)((Int64)maxValue - minValue);
            UInt32 residue = (UInt32.MaxValue - range + 1) % range;// (MaxValue+1) % range でだとオーバーフローするのでrangeを引いておく。
            UInt32 r;
            do {
                r = original.NextUInt32();
            } while (r < residue);
            return (Int32)((Int64)((r - residue) % range) + minValue);
        }

        /// <summary>
        /// [0,1)の擬似乱数を取得します。
        /// </summary>
        protected override double Sample() {
            return this.Next() * 4.6566128752457969E-10;
        }

        /// <summary>
        /// バイト配列に擬似乱数を格納します。
        /// </summary>
        public override void NextBytes( byte[] buffer ) {
            original.NextBytes(buffer);
        }

    }

}
