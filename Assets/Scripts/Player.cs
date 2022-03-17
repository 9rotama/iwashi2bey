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

        if(Input.GetMouseButtonDown(0))
        {
            preMousePos = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            crMousePos = Input.mousePosition;
            Vector2 diff = crMousePos - preMousePos;
            base._rb2d.AddForce(diff*(Vector2.one*base._moveSp),ForceMode2D.Impulse);
        }

        if(base._moveSp  < base._rb2d.velocity.magnitude)
        {
            base._rb2d.velocity = base._rb2d.velocity.normalized * base._moveSp;
        }
    






    }

}
