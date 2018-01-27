using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Transform HoldPoint;
    public Transform ZoomPoint;
    public Inventory Inventory;
    public FPController FPController;
    public Fader Fader;
    public CapsuleCollider PlayerCollider;

    private GameObject _objectHeld;
    private Rigidbody _objectHeldRb;
    private Transform _objectHeldOldParent;
    private bool _screenLocked;
    private LockScreenAction _lockScreenAction;
    private float _originRadius;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _originRadius = PlayerCollider.radius;
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
    public void LockScreen(LockScreenAction lockScreenAction)
    {
        _screenLocked = !_screenLocked;
        if(_screenLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            FPController.enabled = false;

            //Fade in de la boule autour de la tête
            Fader.Fade(191);

            _lockScreenAction = lockScreenAction;
            PlayerCollider.radius = 0.01f; 
            StartCoroutine(Zoom());
        } else
        {
            Cursor.lockState = CursorLockMode.Locked;
            FPController.enabled = true;

            //Fade out de la boule autour de la tête
            Fader.Fade(0);

            PlayerCollider.radius = _originRadius;
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

    IEnumerator Zoom()
    {
        Vector3 direction = Camera.main.transform.position - _lockScreenAction.transform.position;
        while (_screenLocked)
        {
            _lockScreenAction.transform.position = Vector3.Lerp(_lockScreenAction.transform.position, ZoomPoint.position, 0.1f);

            _lockScreenAction.transform.rotation = Quaternion.Lerp(_lockScreenAction.transform.rotation, Quaternion.LookRotation(direction, _lockScreenAction.transform.up), 0.1f);
            yield return new WaitForSeconds(0.01f);
        }
        direction = _lockScreenAction.transform.position - _lockScreenAction._positionOrigin;
        for (float i = 0; i < 1; i +=0.1f)
        {
            _lockScreenAction.transform.position = Vector3.Lerp(_lockScreenAction.transform.position, _lockScreenAction._positionOrigin, i);
            _lockScreenAction.transform.rotation = Quaternion.Lerp(_lockScreenAction.transform.rotation, _lockScreenAction._rotationOrigin, i);
            yield return new WaitForSeconds(0.01f);
        }
        _lockScreenAction.transform.position = _lockScreenAction._positionOrigin;
        _lockScreenAction.transform.rotation = _lockScreenAction._rotationOrigin;
    }
}
