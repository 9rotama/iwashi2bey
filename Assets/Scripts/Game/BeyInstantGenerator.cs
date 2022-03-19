using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeyInstantGenerator : MonoBehaviour
{
    
    [SerializeField] private GameObject[] beys;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        var playerBeyType = PlayerPrefs.GetInt("PlayerBey", 0);
        var playerChildObj = (GameObject) Instantiate(beys[playerBeyType], player.transform.position, Quaternion.identity);
        playerChildObj.transform.parent = player.transform;
        
        var enemyBeyType = PlayerPrefs.GetInt("EnemyBey", 0);
        var enemyChildObj = (GameObject) Instantiate(beys[enemyBeyType], enemy.transform.position, Quaternion.identity);
        enemyChildObj.transform.parent = enemy.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
