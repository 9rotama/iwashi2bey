using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeyStatus : MonoBehaviour
{
    //動くスピード
    [SerializeField] float _moveSp;
    public float GetMoveSp() => _moveSp;

    //スタミナ最大値
    [SerializeField] float _maxStamina;
    public float GetMaxStamina() => _maxStamina;

    //重さ
    [SerializeField] float _weight;
    public float GetWeight() => _weight;

    //弾む力
    [SerializeField] float _bouncePwr;
    public float GetBouncePwr() => _bouncePwr;

    //現在のスタミナ
    float _crStamina;

}
