using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingOther : MonoBehaviour
{

    //衝突したとき
    void OnCollisionEnter2D(Collision2D bey)
    {
        GameAudioManager.PlayHitSe();
    }
}
