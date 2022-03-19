using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Serialization;

using UniRx;
using System;

namespace Game.UI.Controller
{
    public class CountDownController : MonoBehaviour
    {
        [HideInInspector]
        public bool IsCountDownFinished { get; private set; }
            = false;

        private Text _textComp;
        
        public void StartCountDown()
        {
            this.gameObject.SetActive(true);
            StartCoroutine(nameof(CountDown));
        }
        
        private IEnumerator CountDown()
        {
            yield return new WaitForSeconds(1);
            GameAudioManager.PlayCountDownSe();
            _textComp.text = "3";
            yield return new WaitForSeconds(1);
            _textComp.text = "2";
            yield return new WaitForSeconds(1);
            _textComp.text = "1";
            yield return new WaitForSeconds(1);
            _textComp.text = "GO!";
            IsCountDownFinished = true;
            yield return new WaitForSeconds(0.5f);
            this.gameObject.SetActive(false); //GO!の0.5秒後消す
            yield break;
        }
        
        // Start is called before the first frame update
        private void Awake()
        {
            this.gameObject.SetActive(false);
            _textComp = GetComponent<Text>();
            _textComp.text = "";
        }
    }
}
