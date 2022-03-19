using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Bey : MonoBehaviour
{
    //動くスピード
    protected float _moveSp;

    //スタミナ最大値
    public float MaxStamina { get; private set; }

    //重さ
    float _weight;

    //弾む力
    float _bouncePwr;

    //現在のスタミナ
    public float CrStamina { get; private set; }
    protected Rigidbody2D _rb2d;
    protected GameObject _child;
    Vector2 _prePos;
    Vector2 _crPos;

    virtual protected void Start()
    {
        _child =  transform.GetChild(0).gameObject;
        _rb2d = _child.GetComponent<Rigidbody2D>();

        BeyStatus beyStatus = _child.GetComponent<BeyStatus>();
        _moveSp = beyStatus.GetMoveSp();
        MaxStamina = beyStatus.GetMaxStamina();
        _weight = _rb2d.mass = beyStatus.GetWeight();
        _bouncePwr = _rb2d.sharedMaterial.bounciness = beyStatus.GetBouncePwr();
        CrStamina = MaxStamina;
        

        _crPos = _prePos = _child.transform.position;
    }


    //スタミナを減少させる
    protected void DecreaseStamina()
    {
        _prePos = _crPos;
        _crPos = _child.transform.position;
        float distance = ((_prePos-_crPos)).sqrMagnitude;
        if(CrStamina > 0) {
            CrStamina -= distance/10; //移動距離に応じて
            CrStamina -= 1.0f;        //時間経過で
        }
        else  CrStamina = 0;
    }

    //移動
    protected abstract void Move();

    //回転
    protected void Rotate()
    {
        const float rotatePwr = 3000.0f;
        _rb2d.angularVelocity = CrStamina / MaxStamina > 0.01 ? Mathf.Pow(CrStamina / MaxStamina, 0.5f) *rotatePwr : 0;
    }
}
