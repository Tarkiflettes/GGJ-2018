using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform HoldPoint;
    private GameObject _objectHeld;
    private Rigidbody _objectHeldRb;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(_objectHeld != null)
        {
            _objectHeld.transform.position= HoldPoint.position;
            _objectHeld.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
	}
    
    public void GrabObject(GameObject gameObject)
    {
        // Porte ou lâche un objet en fonction de ce qu'on tient
        if(_objectHeld == null)
        {
            _objectHeld = gameObject;
            _objectHeldRb = gameObject.GetComponent<Rigidbody>();
        }
    }
}
