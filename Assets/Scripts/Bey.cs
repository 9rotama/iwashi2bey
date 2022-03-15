using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Bey : MonoBehaviour
{
    //動くスピード
    protected float _moveSp;

    //スタミナ最大値
    float _maxStamina;

    //重さ
    float _weight;

    //アタック
    float _attackPwr;

    //現在のスタミナ
    protected float _crStamina;
    protected Rigidbody2D _rb2d;
    GameObject _child;
    Vector2 _prePos;
    Vector2 _crPos;

    virtual protected void Start()
    {
        _child =  transform.GetChild(0).gameObject;
        _rb2d = _child.GetComponent<Rigidbody2D>();
        

        BeyStatus beyStatus = _child.GetComponent<BeyStatus>();
        _moveSp = beyStatus.GetMoveSp();
        _maxStamina = beyStatus.GetMaxStamina();
        _weight = _rb2d.mass = beyStatus.GetWeight();
        _attackPwr = beyStatus.GetAttackPwr();
        _crStamina = _maxStamina;

        _crPos = _prePos = _child.transform.position;
    }


    //スタミナを減少させる
    protected void DecreaseStamina()
    {
        _prePos = _crPos;
        _crPos = _child.transform.position;
        float distance = ((_prePos-_crPos)).sqrMagnitude;
        if(_crStamina > 0) {
            _crStamina -= distance/10; //移動距離に応じて
            _crStamina -= 1.0f;        //時間経過で
        }
        else  _crStamina = 0;
    }

    //移動
    protected abstract void Move();

    //回転
    protected void Rotate()
    {
        const float rotatePwr = 3000.0f;
        _rb2d.angularVelocity = _crStamina / _maxStamina > 0.01 ? Mathf.Pow(_crStamina / _maxStamina, 0.5f) *rotatePwr : 0;
    }
}
