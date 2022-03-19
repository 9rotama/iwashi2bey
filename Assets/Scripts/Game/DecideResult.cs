using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using Game.UI.Controller;

public class DecideResult : MonoBehaviour
{
    [SerializeField] ResultController resultCtrl;
    [SerializeField] GameManager gameManager;


    public void DeicideLoserBey(GameObject obj)
    {
        if (gameManager.GetGameState() == GameState.Battle)
        {
            if (obj.tag == "Player")
            {
                resultCtrl.Display(false);
                GameAudioManager.PlayLoseSe();
            }
            else
            {
                resultCtrl.Display(true);
                GameAudioManager.PlayWinSe();
            }
            gameManager.GameFinish(this.gameObject);
        }
    }
}
