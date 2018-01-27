using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayClicker : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit)
            {
                if (hitInfo.collider.gameObject.GetComponent<CryptexCylinder>())
                {
                    hitInfo.collider.SendMessage("NextStep", SendMessageOptions.DontRequireReceiver);
                }
                else
                {
                    Debug.Log("Nope ");
                }
            }
        }
    }
}
