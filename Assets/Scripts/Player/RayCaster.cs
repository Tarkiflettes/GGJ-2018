using UnityEngine;

public class RayCaster : MonoBehaviour
{

    public Player Player;

    private Collider _previousCollider;

    private const float MAX_RAY_DISTANCE = 2.5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, MAX_RAY_DISTANCE, LayerMask.GetMask("RayReceiver")))
        {
            Collider currentCollider = hit.collider;

            if (_previousCollider != currentCollider)
            {
                currentCollider.SendMessage("OnRayEnter", SendMessageOptions.DontRequireReceiver);

                _previousCollider = currentCollider;
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                currentCollider.SendMessage("OnRaySelect", SendMessageOptions.DontRequireReceiver);
                OnSelect(currentCollider);
            }
        }
        else
        {
            if (_previousCollider != null)
            {
                _previousCollider.SendMessage("OnRayExit", SendMessageOptions.DontRequireReceiver);
                _previousCollider = null;
            }
        }
    }

    protected virtual void OnSelect(Collider collider)
    {
        if (collider.gameObject.GetComponent<Movable>())
        {
            Player.GrabObject(collider.gameObject);
        }
        if (collider.gameObject.GetComponent<Pickable>())
        {
            Player.PickObject(collider.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, transform.forward * MAX_RAY_DISTANCE);
    }
}
