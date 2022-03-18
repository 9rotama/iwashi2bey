using UnityEngine;

namespace Game
{
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
            //Move();
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
                base._rb2d.AddForce(diff*(Vector2.one*base._moveSp-_rb2d.velocity),ForceMode2D.Impulse);
            }





            // if(Input.GetMouseButton(0))
            // {
            //     preMousePos = crMousePos;
            //     crMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //     Vector2 delta = crMousePos - preMousePos;
            //     const float addPwr = 100f;
            //     base._rb2d.AddForce(delta*(Vector2.one*base._moveSp-_rb2d.velocity)*addPwr);
            
            
            //     Debug.Log(delta);
            // }
            // else
            // {
            //     preMousePos = crMousePos = Vector2.zero;
            // }

        }

    }
}
