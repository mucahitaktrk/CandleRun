using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            other.gameObject.SetActive(false);
            playerManager.CandleScaleUp(1.5f);
        }
        else if (other.gameObject.layer == 8)
        {
            playerManager.CandleScaleDown(2.0f);
        }
        else if (other.gameObject.layer == 9)
        {
            playerManager.GameWin();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            playerManager.CandleScaleDown(0.3f);
        }
    }
}
