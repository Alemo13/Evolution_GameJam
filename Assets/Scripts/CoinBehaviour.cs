using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour, IPickable
{
    [SerializeField] private int coinScore;

    public Vector3 rotationSpeed = new Vector3(0, 30, 0); // Rotation speed in degrees per second
    public void TakeIt()
    {
        //play audio coin collected
        if (coinScore > 0) AudioManager.Instance.Play("SFX_GoodCoin");
        else AudioManager.Instance.Play("SFX_BadCoin");

        GameManager.Instance.UpdateScore(coinScore);
        Destroy(gameObject);

    }
    void Update()
    {
        // Rotate the prefab around its own position
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }

}
