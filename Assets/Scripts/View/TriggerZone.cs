using System;
using UnityEngine;

namespace View
{
    public class TriggerZone : MonoBehaviour
    {
        public Action<string> OnEnter;
        public Action<string> OnExit;

        private void OnTriggerEnter(Collider other)
        {
            OnEnter?.Invoke(other.gameObject.tag);
        }

        private void OnTriggerExit(Collider other)
        {
            OnExit?.Invoke(other.gameObject.tag);
        }
    }
}