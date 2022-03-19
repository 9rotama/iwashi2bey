using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.UI.Controller;
using Game;

public class OffStage : MonoBehaviour
{
    [SerializeField] DecideResult decideResult;

    void OnTriggerExit2D(Collider2D other)
    {
        decideResult.DeicideLoserBey(other.transform.parent.gameObject);
    }
}
