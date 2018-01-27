using UnityEngine;

public abstract class RayReceiver : MonoBehaviour
{

    protected abstract void OnRayEnter();

    protected abstract void OnRaySelect();

    protected abstract void OnRayExit();
}
