using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class Enemy : Bey
{
    [SerializeField] GameManager gameManager;
    [SerializeField] DecideResult decideResult;
    GameObject target;

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        if(Random.Range(0,2) == 0){
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            target = playerObj.transform.GetChild(0).gameObject;
        }
        else {
            target = GameObject.Find("StaminaDestination");
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        base.Rotate();
        if(gameManager.GetGameState() != GameState.Ready)
        {
            base.DecreaseStamina();
            if(CrStamina <= 0) decideResult.DeicideLoserBey(gameObject);
        }
        if(gameManager.GetGameState() == GameState.Battle)
        {
            Move();
        }

    }

    protected override void Move()
    {
        Vector2 diff = -base._child.transform.position + target.transform.position;
        const float ADD_PWR = 10f;
        if(CrStamina > 0) {base._rb2d.AddForce(diff.normalized*(Vector2.one*base._moveSp)*ADD_PWR);}
        else base._rb2d.AddForce((Vector2.zero - _rb2d.velocity)*ADD_PWR);
    }
}
