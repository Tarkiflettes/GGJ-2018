using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public Canvas InventoryCanvas;

    private InventorySlot[] _inventorySlots;

    void Start()
    {
        _inventorySlots = InventoryCanvas.GetComponentsInChildren<InventorySlot>();
    }

    public bool AddPickable(Pickable pickable)
    {
        var count = Count();
        if (count >= _inventorySlots.Length)
            return false;
        
        _inventorySlots[count].AddPickable(pickable);

        return true;
    }

    public void RemovePickable(Pickable pickable)
    {
        var slot = _inventorySlots.FindMember(x => x.Pickable == pickable);
        slot.Clear();
        Arrange();
    }

    public int Count()
    {
        return _inventorySlots.Count(slot => !slot.IsEmpty());
    }

    public bool Contains(Pickable pickable)
    {
        return _inventorySlots.Any(x => x.Pickable == pickable);
    }

    private void Arrange()
    {
        var count = Count();
        if (count == 0)
            return;
        
        var currentCount = 0;
        for (var i = 0; i < _inventorySlots.Length; i++)
        {
            if (!_inventorySlots[i].IsEmpty())
            {
                if (currentCount != i)
                {
                    var p = _inventorySlots[i].Pickable;
                    _inventorySlots[i].Clear();
                    _inventorySlots[currentCount].AddPickable(p);
                }
                currentCount++;
            }
        }
    }

}
