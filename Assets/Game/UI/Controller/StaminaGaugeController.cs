using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Game.UI.Controller
{
    public class StaminaGaugeController : MonoBehaviour
    {
        [SerializeField] private GameUIManager gameUIManager;

        private Slider _sliderComp;

        public void SetValue(float staminaValue)
        {
            _sliderComp.value = staminaValue;
        }
        
        // Start is called before the first frame update
        void Start()
        {
            _sliderComp = GetComponent<Slider>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}