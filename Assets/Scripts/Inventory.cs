using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Inventory : MonoBehaviour
    {

        public List<Pickable> Pickables;
        public int Limit;

        public bool AddPickable(Pickable pickable)
        {
            if (Pickables.Count >= Limit)
                return false;
            Pickables.Add(pickable);
            return true;
        }

        public void RemovePickable(Pickable pickable)
        {
            Pickables.Remove(pickable);
        }

    }
}
