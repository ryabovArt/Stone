using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Color clr;
    private string col = "#C1532D";

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        ColorUtility.TryParseHtmlString(col, out clr);
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            meshRenderer.material.color = Color.red;
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            meshRenderer.material.color = clr;
        }
    }
}
