using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectEnum : MonoBehaviour
{
    public enum Effect
    {
        None,
        /// <summary>[�ܔM]�p���_���[�W</summary>
        Burning,
        /// <summary>[��]�p���_���[�W</summary>
        Poison,
        /// <summary>[�o��]�p���_���[�W</summary>
        Bleeding,
        /// <summary>[����]�p���_���[�W</summary>
        Frostbite,
        /// <summary>[����]�s���s��</summary>
        Sleep,
        /// <summary>[�C��]�s���s��</summary>
        Stun,
        /// <summary>[���|]�U���͒ቺ</summary>
        Fear,

    }
}
