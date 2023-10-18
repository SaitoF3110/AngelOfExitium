using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectEnum : MonoBehaviour
{
    public enum Effect
    {
        None,
        /// <summary>[灼熱]継続ダメージ</summary>
        Burning,
        /// <summary>[毒]継続ダメージ</summary>
        Poison,
        /// <summary>[出血]継続ダメージ</summary>
        Bleeding,
        /// <summary>[凍傷]継続ダメージ</summary>
        Frostbite,
        /// <summary>[睡眠]行動不可</summary>
        Sleep,
        /// <summary>[気絶]行動不可</summary>
        Stun,
        /// <summary>[恐怖]攻撃力低下</summary>
        Fear,

    }
}
