using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameConstants gameConstants;
    private BoosterPooler itemPooler;
    private float leftX, rightX, leftY, rightY;
    private bool activated = false;

    void Start()
    {
        itemPooler = GetComponent<BoosterPooler>();
        leftX = gameConstants.spawnBoundary.x;
        rightX = gameConstants.spawnBoundary.y;
        leftY = gameConstants.spawnBoundary.z;
        rightY = gameConstants.spawnBoundary.w;
    }

    private void Update()
    {
        if (FindObjectOfType<GameManager>().IsGameStarted() && !activated)
        {
            StartCoroutine(randomSpawn());
            activated = true;
        }
    }

    IEnumerator randomSpawn()
    {
        while (true)
        {
            float waitSeconds = Random.Range(gameConstants.itemSpawnMinInterval, gameConstants.itemSpawnMaxInterval);
            yield return new WaitForSeconds(waitSeconds);
            float randomXPosition = Random.Range(leftX, rightX);
            float randomYPosition = Random.Range(leftY, rightY);
            System.Array enumArray = System.Enum.GetValues(typeof(BoosterPooler.ItemType));
            BoosterPooler.ItemType itemType = (BoosterPooler.ItemType)enumArray.GetValue(Random.Range(0, enumArray.Length));
            Vector3 position = new Vector3(randomXPosition, randomYPosition, 0);
            Quaternion rotation = Quaternion.identity;
            GameObject item = itemPooler.SpawnItem(itemType, position, rotation);
            item.SetActive(true);
        }
    }
}
