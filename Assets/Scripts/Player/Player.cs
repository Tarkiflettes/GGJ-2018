using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform HoldPoint;
    public Inventory Inventory;
    public FPController FPController;
    public Fader Fader;

    private GameObject _objectHeld;
    private Rigidbody _objectHeldRb;
    private Transform _objectHeldOldParent;
    private bool _screenLocked;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (_objectHeld != null)
        {
            _objectHeld.transform.position = HoldPoint.position;
            _objectHeld.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    // Methode pour les objets qui s'affichent devant le jouer et qui unlock le curseur
    public void LockScreen(GameObject gameObject)
    {
        if(!_screenLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            FPController.enabled = false;
            //Fade in de la boule autour de la tête
            Fader.Fade(191);
        } else
        {
            Cursor.lockState = CursorLockMode.Locked;
            FPController.enabled = true;
            //Fade out de la boule autour de la tête
            Fader.Fade(0);
        }
        _screenLocked = !_screenLocked;
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
