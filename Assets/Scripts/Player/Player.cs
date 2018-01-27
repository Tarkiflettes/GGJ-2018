using UnityEngine;

public class Player : MonoBehaviour
{

    public Transform HoldPoint;
    public Inventory Inventory;
    private GameObject _objectHeld;
    private Rigidbody _objectHeldRb;
    private Transform _objectHeldOldParent;

    // Update is called once per frame
    void Update()
    {
        if (_objectHeld != null)
        {
            _objectHeld.transform.position = HoldPoint.position;
            _objectHeld.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    public void GrabObject(GameObject gameObject)
    {
        // Porte ou lâche un objet en fonction de ce qu'on tient
        if (_objectHeld == null)
        {
            _objectHeld = gameObject;
            _objectHeldRb = gameObject.GetComponent<Rigidbody>();
            // Gestion du parent
            _objectHeldOldParent = gameObject.transform.parent;
            gameObject.transform.parent = HoldPoint;
        }
        else
        {
            _objectHeld = null;
            gameObject.GetComponent<Rigidbody>().velocity = _objectHeldRb.velocity;
            gameObject.transform.parent = _objectHeldOldParent;
        }
    }

    public void PickObject(GameObject gameObject)
    {
        var p = gameObject.GetComponent<Pickable>();
        if (p != null)
        {
            var picked = Inventory.AddPickable(gameObject.GetComponent<Pickable>());
            if (picked)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                // TODO pas de destroy a cause du pickable, changer les 2 lignes au dessus ?
            }
        }
    }
}
