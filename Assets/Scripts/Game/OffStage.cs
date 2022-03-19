using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.UI.Controller;
using Game;

public class OffStage : MonoBehaviour
{
    [SerializeField] ResultController resultCtrl;
    [SerializeField] GameManager gameManager;
   

    void OnTriggerExit2D(Collider2D other)
    {   
        
        if(other.transform.parent.tag == "Player")
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
        Destroy(this);
    }
}
