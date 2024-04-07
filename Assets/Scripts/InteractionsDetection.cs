using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionsDetection : MonoBehaviour
{
    [SerializeField] private int spikeNegativeScore;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Spikes"))
        {
            AudioManager.Instance.Play("SFX_Spike");
            GameManager.Instance.UpdateScore(spikeNegativeScore);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameWin"))
        {
            GameManager.Instance.GameWin();
            Destroy(other.gameObject);
        }
    }
}
