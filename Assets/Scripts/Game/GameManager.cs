using System.Collections;
using System.Collections.Generic;
using Game.UI;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;　

using UniRx;

namespace Game
{
    public enum GameState
    {
        Ready,
        Battle,
        Result
    }

    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameUIManager gameUIManager;

        private GameState _gameState;

        [HideInInspector]
        public BoolReactiveProperty isCountDownStarted { get; private set; }
            = new BoolReactiveProperty(false);

        public GameState GetGameState()
        {
            return _gameState;
        }
        
        public void GameBegin()
        {
            _gameState = GameState.Battle;
        }

        public void GameFinish(GameObject obj)
        {
            _gameState = GameState.Result;
        }
    
    
        // Start is called before the first frame update
        private void Start()
        {
            isCountDownStarted.Value = true;
            _gameState = GameState.Ready;
        }

        // Update is called once per frame
        private void Update()
        {
        
        }
    }
}