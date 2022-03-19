using System.Collections;
using System.Collections.Generic;
using Game.UI;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;

using UniRx;
using System;
using Game.UI.Controller;

namespace Game.UI
{
    public class GameUIManager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private Player player;
        [SerializeField] private CountDownController countDownCtrl;
        [SerializeField] private ResultController resultCtrl;
        [SerializeField] private StaminaGaugeController staminaGaugeCtrl;
        
        // Start is called before the first frame update
        private void Start()
        {
            gameManager.ObserveEveryValueChanged(c => c.IsCountDownStarted)
                .Subscribe(value =>
                {
                    if (value)
                    {
                        countDownCtrl.StartCountDown();
                    } 
                });
            countDownCtrl.ObserveEveryValueChanged(c => c.IsCountDownFinished)
                .Subscribe(value => {
                    if (value)
                    {
                        gameManager.GameBegin();
                        
                        //↓デバッグ用
                        //resultCtrl.Display(true);
                    }
                });
            player.ObserveEveryValueChanged(c => c.CrStamina)
                .Subscribe(value => {
                    staminaGaugeCtrl.SetValue(value / player.MaxStamina);
                });
            
            
        }

        // Update is called once per frame
        private void Update()
        {
        
        }
    }
}
