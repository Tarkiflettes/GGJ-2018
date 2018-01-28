using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    private int _angle;
    public int Step = 2;
    private int _sens;
    private Vector3 _axis;
	
    public void Open(Vector3 axis, int angle)
    {
        _angle = angle;
        _axis = axis;
        _sens = 1;
        StartCoroutine(ContinuousRotation());
    }

    public void Close()
    {
        _sens = -1;
        StartCoroutine(ContinuousRotation());
    }

    private IEnumerator ContinuousRotation()
    {
        for (var i = 0; i < _angle/Step; i++)
        {
            foreach (Transform child in GetComponentsInChildren<Transform>())
            {
                if(child.tag == "Rotator")
                    child.Rotate(_axis, _sens*Step);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
