using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    public event Action<int> LifeLost;

    #region Field Declarations

    [SerializeField] private PlayerController playerPrefab;

    private int lives = 3;

    private WaitForSeconds playerSpawnDelay = new WaitForSeconds(1);

    #endregion

    #region Startup

    private void Start()
    {
        StartLevel();
    }

    private void StartLevel()
    {
        StartCoroutine(SpawnPlayer(false));
    }

    #endregion

    #region Spawning

    private IEnumerator SpawnPlayer(bool delayed)
    {
        if (delayed)
            yield return playerSpawnDelay;

        PlayerController player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        
        player.HitByEnemy += Player_HitByEnemy;

        yield return null;
    }

    private void Player_HitByEnemy()
    {
        lives--;

        if (LifeLost != null)
            LifeLost(lives);

        if(lives > 0)
        {
            StartCoroutine(SpawnPlayer(true));
        }
    }

    #endregion
}
