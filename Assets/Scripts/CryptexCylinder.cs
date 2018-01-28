using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptexCylinder : MonoBehaviour {

    public int CylinderPosition;
    public int Step = 0;
    public Vector3 Axis;

    [ContextMenu("Rotate")]
    void NextStepD()
    {
        Step++;
        transform.Rotate(Axis, 360f / 26f);
    }

    void NextStepG()
    {
        Step--;
        transform.Rotate(Axis*-1, 360f / 26f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Gizmos.DrawRay(ray.origin, ray.direction* 2);
    }

}
