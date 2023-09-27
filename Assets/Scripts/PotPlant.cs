using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotPlant : MonoBehaviour
{
    public int potPlantCount = 5;
    public GameObject potPlant;

    public void PlacePotPlant()
    {
        if (potPlantCount <= 0)
            return;

        LayerMask layerMask = LayerMask.GetMask("Ground");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            Instantiate(potPlant, hit.point, Quaternion.identity, transform);
    }
}
