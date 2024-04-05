using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour, IPickable
{
    [SerializeField] private int coinScore;
    public void TakeIt()
    {
        //play audio coin collected
        GameManager.Instance.UpdateScore(coinScore);
        Destroy(gameObject);

    }

}
