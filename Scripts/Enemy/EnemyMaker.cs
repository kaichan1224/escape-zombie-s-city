using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    [SerializeField] private GameObject[] enemys;//出現するEnemyのリスト
    [SerializeField] private GameObject player;
    [SerializeField] private float regulerTime = 3f;
    [SerializeField] private int generateRadius;//出現する半径外側部分
    [SerializeField] private int generatePlaceY;
    [SerializeField] private int notGenerateDistance;//出現しないようにする半径内側部分
    private PlayerController playerController;
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        StartCoroutine(Generate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomGenerate(int index)
    {
        int x, y, z;
        Vector3 playerPosition = player.transform.position;
        Vector2 randomCircle = Random.insideUnitCircle.normalized * generateRadius;
        x = (int)playerPosition.x + (int)randomCircle.x;
        y = generatePlaceY;
        z = (int)playerPosition.z + (int)randomCircle.y;
        Vector3 generatePlace = new Vector3(x,y,z);
        // 敵を生成
        while (Vector3.Distance(generatePlace, playerPosition) <= notGenerateDistance)
        {
            randomCircle = Random.insideUnitCircle.normalized * generateRadius;
            x = (int)playerPosition.x + (int)randomCircle.x;
            y = generatePlaceY;
            z = (int)playerPosition.z + (int)randomCircle.y;
            generatePlace = new Vector3(x, y, z);
        }
        GameObject enemy = Instantiate(enemys[index],generatePlace,Quaternion.identity);
        enemy.GetComponent<IMoveStrategy>().Setup(player.transform);
    }

    private IEnumerator Generate()
    {
        while (true) // このGameObjectが有効な間実行し続ける
        {
            if (playerController.isDead)
                break;
            yield return new WaitForSeconds(regulerTime);
            if(player != null)
                RandomGenerate(Random.Range(0,enemys.Length));
        }
    }
}
