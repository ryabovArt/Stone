using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseHealth : MonoBehaviour
{
    HealthSystem hs;
    MoveBall passedCheckpoint;
    public GameObject player;

    private void Start()
    {
        passedCheckpoint = player.GetComponent<MoveBall>();
        hs = player.GetComponent<HealthSystem>();
    }

    private void OnTriggerEnter(Collider col)
    {
        hs.health--;
        passedCheckpoint.PassedCheckpoint();
    }
}
