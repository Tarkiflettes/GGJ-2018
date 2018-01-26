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

            Debug.Log("sdrfdf");
            if (_previousCollider != currentCollider)
            {
                Debug.Log("Different");
                currentCollider.SendMessage("OnRayEnter", SendMessageOptions.DontRequireReceiver);
                if(_previousCollider != null)
                {
                    _previousCollider.SendMessage("OnRayExit", SendMessageOptions.DontRequireReceiver);
                }
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                currentCollider.SendMessage("OnRaySelect", SendMessageOptions.DontRequireReceiver);
            }
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, transform.forward * 5f);
    }
}
