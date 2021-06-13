using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
    HealthSystem hs;
    public GameObject player;

    private void Start()
    {
        hs = player.GetComponent<HealthSystem>();
    }

    private void OnTriggerEnter(Collider col)
    {
        hs.health++;
        Destroy(gameObject);
    }
}
