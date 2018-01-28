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
                if(currentCollider.tag =="GoToParent")
                {
                    Debug.Log("ParentGoing");
                    currentCollider.transform.parent.SendMessage("OnRaySelect", SendMessageOptions.DontRequireReceiver);
                    OnSelect(currentCollider.transform.parent.gameObject);
                }
                else
                {
                    currentCollider.SendMessage("OnRaySelect", SendMessageOptions.DontRequireReceiver);
                    OnSelect(currentCollider.gameObject);
                }
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

    protected virtual void OnSelect(GameObject gameObject)
    {

        Debug.Log(gameObject);
        if (gameObject.GetComponent<Movable>())
        {
            Player.GrabObject(gameObject);
        }
        if (gameObject.GetComponent<Pickable>())
        {
            Debug.Log(gameObject);
            Player.PickObject(gameObject);
        }
        if (gameObject.GetComponent<LockScreenAction>())
        {
            Player.LockScreen(gameObject.GetComponent<LockScreenAction>());
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, transform.forward * MAX_RAY_DISTANCE);
    }
}
