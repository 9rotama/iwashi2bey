using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Game.UI.Controller
{
    public class ResultController : MonoBehaviour
    {
        private Text _textComp;
        private Color _winTextColor = new Color(1.0f, 0.3f, 0.2f);
        private Color _loseTextColor = new Color(0.28f, 0.25f, 1.0f);
        
        public void Display(bool didPlayerWin)
        {
            this.gameObject.SetActive(true);
            _textComp.text = didPlayerWin ? "WIN!" : "LOSE...";
            _textComp.color = didPlayerWin ? _winTextColor : _loseTextColor;
        }
        
        // Start is called before the first frame update
        void Start()
        {
            this.gameObject.SetActive(false);
            _textComp = GetComponent<Text>();
            _textComp.text = "";
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
