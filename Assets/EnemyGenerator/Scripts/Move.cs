using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Time.deltaTime, 0, 0);
    }
}
