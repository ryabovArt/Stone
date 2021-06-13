using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public Rigidbody rb; // рб игрока
    private GroundDetection groundDetection; // находится ли игрок на платформе
    public AudioSource movePlayer; // звук движения игрока
    public AudioSource jumping; // звук прыжка игрока
    private float speed; // скорость игрока
    private float jumpTimer; // время зависания при прыжке или падении


    void Awake()
    {
        groundDetection = GetComponent<GroundDetection>();
        movePlayer.Play();
    }

    void FixedUpdate()
    {
        speed = rb.velocity.magnitude;
        movePlayer.pitch = Mathf.Lerp(0.3f, 0.6f, speed * 0.01f);
        movePlayer.pitch = Mathf.Clamp01(movePlayer.pitch);

        if (speed < 1f || !groundDetection.isGround)
        {
            movePlayer.mute = true;
        }
        else
        {
            movePlayer.mute = false;
        }

        if (!groundDetection.isGround) jumpTimer += Time.deltaTime;

    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Pltf") && jumpTimer > 0.5f)
        {
            if (jumpTimer > 0.5f && jumpTimer < 1) jumping.volume = 0.3f;
            else jumping.volume = 0.8f;
            jumping.Play();
            jumpTimer = 0;
        }
    }
}
