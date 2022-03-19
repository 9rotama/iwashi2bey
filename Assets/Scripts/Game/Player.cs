using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Bey
{
    Vector2 crMousePos;
    Vector2 preMousePos;

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        base.Rotate();
        base.DecreaseStamina();
    }

    void Update()
    {
        Move();
    }

    protected override void Move()
    {

        if (Input.GetMouseButtonDown(0))
        {
            preMousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0) && CrStamina > 0)
        {
            const float MAX_SP = 250.0f, ADD_PWR = 0.1f;
            crMousePos = Input.mousePosition;
            Vector2 diff = crMousePos - preMousePos;
            diff *= (diff.magnitude > MAX_SP) ? (MAX_SP / diff.magnitude) : 1;
            base._rb2d.AddForce(diff * (Vector2.one * base._moveSp) * ADD_PWR, ForceMode2D.Impulse);
        }









    }

}
