using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotPlant : MonoBehaviour
{
    public void PlacePotPlant()
    {
        var layerMask = LayerMask.GetMask("Ground");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            GameObject.CreatePrimitive(PrimitiveType.Cube);
    }
}
