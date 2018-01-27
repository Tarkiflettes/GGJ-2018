using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptexCylinder : MonoBehaviour {

	

    [ContextMenu("Rotate")]
    void NextStep()
    {
        transform.Rotate(Vector3.forward, 360f / 26f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Gizmos.DrawRay(ray.origin, ray.direction* 2);
    }

}
