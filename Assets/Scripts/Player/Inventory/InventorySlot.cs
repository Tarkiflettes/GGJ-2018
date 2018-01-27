using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public Pickable Pickable;
    public Image Image;
    public Text Text;

    void Start()
    {
        Clear();
    }

    public void AddPickable(Pickable pickable)
    {
        Pickable = pickable;
        Image.sprite = Pickable.Image;
        Text.text = Pickable.Name;
        Image.color = new Color(1f, 1f, 1f, 255);
    }

    public void Clear()
    {
        Pickable = null;
        Image.sprite = null;
        Text.text = "";
        Image.color = new Color(1f, 1f, 1f, 0);
    }

    public bool IsEmpty()
    {
        return Pickable == null;
    }


}
