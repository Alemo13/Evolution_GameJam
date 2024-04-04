using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPickableObject : MonoBehaviour, IPickable
{
    public void TakeIt()
    {
        AudioManager.Instance.Play("SFX_GoodCoin");
        Destroy(gameObject);
    }
}
