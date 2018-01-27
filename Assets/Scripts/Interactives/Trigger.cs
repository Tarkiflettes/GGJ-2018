using System.Collections.Generic;
using cakeslice;
using UnityEngine;

namespace Assets.Scripts.Interactives
{
    public abstract class Trigger : RayReceiver
    {
        public List<Triggered> TriggeredList;
        public List<Pickable> RequiredToTrigger;

        protected void Triggering()
        {
            foreach (var t in TriggeredList)
            {
                t.Action();
            }
        }

        protected abstract void Action();

        protected override void OnRayEnter()
        {
            var ol = GetComponent<Outline>();
            if (ol != null)
            {
                ol.eraseRenderer = false;
            }
        }

        protected override void OnRaySelect()
        {
            if (!CanBeTrigger())
                return;
            Triggering();
            Action();
        }

        protected override void OnRayExit()
        {
            var ol = GetComponent<Outline>();
            if (ol != null)
            {
                ol.eraseRenderer = true;
            }
        }

        private bool CanBeTrigger()
        {
            var players = GameObject.FindGameObjectsWithTag("Payer");
            foreach (var player in players)
            {
                var p = player.GetComponent<Player>();
                foreach (var r in RequiredToTrigger)
                {
                    if (!p.Inventory.Pickables.Contains(r))
                        return false;
                }
            }
            return true;
        }
    }
}
