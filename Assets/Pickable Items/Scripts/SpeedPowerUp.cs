using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour, IPickable
{
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private float powerUpTime;

    void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
    }

    public void TakeIt()
    {
        StartCoroutine(SpeedPowerUP());
    }

    private IEnumerator SpeedPowerUP()
    {
        float speedBase = playerMovement.speedMultiplier;
        playerMovement.speedMultiplier *= 2.0f;

        yield return new WaitForSeconds(powerUpTime);

        playerMovement.speedMultiplier = speedBase;
    }
}
