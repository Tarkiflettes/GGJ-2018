using System.Collections;
using UnityEngine;

public class LightSystem : Trigger
{

    protected override void Action()
    {
        Debug.Log("oui");
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.black;
        yield return new WaitForSeconds(2);
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(2);
        GetComponent<Renderer>().material.color = Color.yellow;
        yield return new WaitForSeconds(2);
        GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(2);
        GetComponent<Renderer>().material.color = Color.blue;
    }

}
