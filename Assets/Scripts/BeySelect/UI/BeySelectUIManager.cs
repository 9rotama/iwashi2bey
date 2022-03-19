using BeySelect.UI.Controller;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UniRx;

namespace BeySelect.UI
{
    public class BeySelectUIManager : MonoBehaviour
    {
        [SerializeField] private BeySelectManager beySelectManager;
        
        [SerializeField] private BeyImageController playerBeyImg;
        [SerializeField] private Button playerPrevBtn;
        [SerializeField] private Button playerNextBtn;
        
        [SerializeField] private BeyImageController enemyBeyImg;
        [SerializeField] private Button enemyPrevBtn;
        [SerializeField] private Button enemyNextBtn;
        
        [SerializeField] private Button playBtn;

        private const int BeyTypeSize = 9;
        
        // Start is called before the first frame update
        void Start()
        {
            PlayerPrefs.DeleteAll ();
            PlayerPrefs.Save ();
            beySelectManager.ObserveEveryValueChanged(c => c.PlayerBeyTmp)
                .Skip(1)
                .Subscribe(value => {
                    playerBeyImg.SetSprite(value);
                });
            beySelectManager.ObserveEveryValueChanged(c => c.EnemyBeyTmp)
                .Skip(1)
                .Subscribe(value => {
                    enemyBeyImg.SetSprite(value);
                });
            playerPrevBtn.onClick.AsObservable()
                .Subscribe(x =>
                {
                    if( (int) beySelectManager.PlayerBeyTmp <= 0 ) return;
                    var prevType = (int) beySelectManager.PlayerBeyTmp - 1;
                    beySelectManager.SetPlayerBey((BeyType)prevType);
                });
            playerNextBtn.onClick.AsObservable()
                .Subscribe(x =>
                {
                    if( (int) beySelectManager.PlayerBeyTmp >= BeyTypeSize - 1 ) return;
                    var nextType = (int) beySelectManager.PlayerBeyTmp + 1;
                    beySelectManager.SetPlayerBey((BeyType)nextType);
                });
            enemyPrevBtn.onClick.AsObservable()
                .Subscribe(x =>
                {
                    if( (int) beySelectManager.EnemyBeyTmp <= 0 ) return;
                    var prevType = (int) beySelectManager.EnemyBeyTmp - 1;
                    beySelectManager.SetEnemyBey((BeyType)prevType);
                });
            enemyNextBtn.onClick.AsObservable()
                .Subscribe(x =>
                {
                    if( (int) beySelectManager.EnemyBeyTmp >= BeyTypeSize - 1 ) return;
                    var nextType = (int) beySelectManager.EnemyBeyTmp + 1;
                    beySelectManager.SetEnemyBey((BeyType)nextType);
                });
            playBtn.onClick.AsObservable()
                .Subscribe(x =>
                {
                    SceneManager.LoadScene("GameScene");
                });
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
