using UnityEngine;
using UnityEngine.Events;

public class SpikesBehaviour : MonoBehaviour
{
    [SerializeField] private int negativeScore;
    public UnityEvent onDamage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameManager.Instance.UpdateScore(negativeScore);
            onDamage.Invoke();
        }
    }
}
