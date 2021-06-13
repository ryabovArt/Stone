using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// определяем, находится ли игрок на платформе
public class GroundDetection : MonoBehaviour 
{
    public bool isGround;
    
    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("Pltf"))
        {
            isGround = true; 
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Pltf"))
        {
            isGround = false;
        }
    }
}
