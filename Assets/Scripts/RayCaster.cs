using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour {

    private Collider _previousCollider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 20, LayerMask.GetMask("RayReceiver")))
        {
            Collider currentCollider = hit.collider;

            if(_previousCollider != currentCollider)
            {
                currentCollider.SendMessage("OnRayEnter", SendMessageOptions.DontRequireReceiver);
            }


                _previousCollider = hit.collider;
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, transform.forward * 5f);
    }
}
