using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePowerup : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 80.0f * Time.deltaTime);
    }
}
