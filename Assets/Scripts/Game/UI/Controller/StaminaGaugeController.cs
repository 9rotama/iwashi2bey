using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Game.UI.Controller
{
    public class StaminaGaugeController : MonoBehaviour
    {
        private Image _ImageComp;

        public void SetValue(float staminaRate)
        {
            _ImageComp.fillAmount = staminaRate;
//            Debug.Log(_ImageComp.fillAmount);
        }
        
        // Start is called before the first frame update
        void Awake()
        {
            _ImageComp = GetComponent<Image>();
            _ImageComp.fillAmount = 1.0f;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
