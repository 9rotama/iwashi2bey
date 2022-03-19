using UnityEngine;

public enum BeyType
{
    Candy,
    Chocolate,
    Cookie,
    Donuts,
    HotCake,
    Kurimanju,
    ShortCake,
    Taiyaki,
    Yatsuhashi
}


namespace BeySelect
{
    public class BeySelectManager : MonoBehaviour
    {
        public BeyType PlayerBeyTmp { get; private set; } = BeyType.Candy;
        public BeyType EnemyBeyTmp { get; private set; } = BeyType.Candy;

        public void SetPlayerBey(BeyType type)
        {
            PlayerBeyTmp = type;
            PlayerPrefs.SetInt("PlayerBey", (int)PlayerBeyTmp);
            Debug.Log(PlayerPrefs.GetInt("PlayerBey", 0));
        }

        public void SetEnemyBey(BeyType type)
        {
            EnemyBeyTmp = type;
            PlayerPrefs.SetInt("EnemyBey", (int)EnemyBeyTmp);
            Debug.Log(PlayerPrefs.GetInt("EnemyBey", 0));

        }
    
        // Start is called before the first frame update
        void Awake()
        {
            PlayerBeyTmp = (BeyType)PlayerPrefs.GetInt("PlayerBey", 0);
            EnemyBeyTmp = (BeyType)PlayerPrefs.GetInt("EnemyBey", 0);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
