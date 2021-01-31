using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabler : MonoBehaviour
{
    public bool disabler = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        if (!disabler) {
            Shooting shooting = go.GetComponent<Shooting>();
            if (shooting != null)
            {
                shooting.enabled = true;
            }
        }
        else
        {
            Destroy(go);
        }
    }
}
