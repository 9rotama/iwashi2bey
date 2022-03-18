using UnityEngine;

namespace Game
{
    public class Enemy : Bey
    {
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
            base.DecreaseStamina();
            Move();
        }

        protected override void Move()
        {
            Vector2 diff = -transform.GetChild(0).gameObject.transform.position + target.transform.position;
            const float addPwr = 10f;
            if(CrStamina > 0) {base._rb2d.AddForce(diff.normalized*(Vector2.one*base._moveSp),ForceMode2D.Impulse);}
            else base._rb2d.AddForce((Vector2.zero - _rb2d.velocity)*addPwr);
        }
    }
}
