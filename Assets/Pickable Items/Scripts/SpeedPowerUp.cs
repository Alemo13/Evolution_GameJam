using System.Collections;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour, IPickable
{
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private float powerUpTime;

    void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        //if (playerMovement == null) Debug.Log("Socio no lo encontro");
    }

    public void TakeIt()
    {
        AudioManager.Instance.Play("SFX_PowerUp");
        StartCoroutine(SpeedPowerUP());
        gameObject.SetActive(false);
    }

    private IEnumerator SpeedPowerUP()
    {
        float speedBase = playerMovement.speedMultiplier;
        playerMovement.speedMultiplier *= 2.0f;

        //Debug.Log("Si entro " + playerMovement.speedMultiplier);

        yield return new WaitForSeconds(powerUpTime);

        playerMovement.speedMultiplier = speedBase;
    }
}
