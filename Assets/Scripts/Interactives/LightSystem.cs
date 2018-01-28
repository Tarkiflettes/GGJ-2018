using System.Collections;
using UnityEngine;

<<<<<<< HEAD
public class LightSystem : Triggered
{
    
    public override void Action()
=======
public class LightSystem : MonoBehaviour
{
    public int NbClignotements;
    public float TimeBetweenLights;
    public Fader Fader;

    public IEnumerator ChangeColor()
>>>>>>> Florian
    {
        for (int i = 0; i<NbClignotements; i++)
        {
            Fader.Fade(255);
            yield return new WaitForSeconds(TimeBetweenLights);
            Fader.Fade(0);
            yield return new WaitForSeconds(TimeBetweenLights);

        }
    }

}
