using System.Collections.Generic;

namespace Assets.Scripts.Interactives
{
    public abstract class Trigger : RayReceiver
    {
        public List<Triggered> TriggeredList;

        private void Triggering()
        {
            foreach (var t in TriggeredList)
            {
                t.Action();
            }
        }

        protected abstract void Action();

        protected override void OnRayEnter()
        {
        }

        protected override void OnRaySelect()
        {
            Triggering();
            Action();
        }

        protected override void OnRayExit()
        {
        }
    }
}
