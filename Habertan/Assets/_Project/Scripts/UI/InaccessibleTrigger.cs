using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InaccessibleTrigger : MonoBehaviour
{
    void Update()
    {
        if (Timer.Instance.IsWinCondition())
        {
            Destroy(gameObject);
        }
    }
}
