using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class GateCollider : MonoBehaviour
{
    [SerializeField] private Image finishInstructionImage;

    private StarterAssetsInputs _starterAssetsInput;



    private void OnTriggerEnter(Collider other)
    {
        finishInstructionImage.gameObject.SetActive(true);
    }
}
