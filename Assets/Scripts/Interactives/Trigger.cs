using System.Collections.Generic;
using cakeslice;
using UnityEngine;

namespace Assets.Scripts.Interactives
{
    public abstract class Trigger : RayReceiver
    {
        public List<Triggered> TriggeredList;

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
    }
}
