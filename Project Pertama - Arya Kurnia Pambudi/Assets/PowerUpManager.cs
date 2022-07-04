using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public int maxPowerUpAmount;
    public int spawnInterval;
    public Transform spawnArea;
    public Vector2 PowerUpAreaMin;
    public Vector2 PowerUpAreaMax;
    public List<GameObject> powerUpTemplateList;

    private List<GameObject> powerUpList;

    private float timer;

    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }

    private void Update()
    {
       timer += Time.deltaTime;
       if (timer > spawnInterval)
       {
        GenerateRandomPowerUp();
        timer -= spawnInterval;
       }
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp (new Vector2(Random.Range(PowerUpAreaMin.x, PowerUpAreaMax.x), Random.Range(PowerUpAreaMin.y, PowerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {

        if (powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }

        if (position.x < PowerUpAreaMin.x ||
            position.x > PowerUpAreaMax.x ||
            position.y < PowerUpAreaMin.y ||
            position.y > PowerUpAreaMax.y)
        {
            return;
        }
        
        Debug.Log("Test");

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }
}
