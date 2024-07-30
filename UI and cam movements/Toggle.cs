using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace UISwitcher
{
    public class Toggle : MonoBehaviour
    {
        [SerializeField] private UISwitcher switcher1;

        public RotateObject rotateObject;

        private void Awake()
        {
            // Subscribe to the toggle value change event
            switcher1.onValueChanged.AddListener(OnValueChanged1);
        }

        private void OnValueChanged1(bool isOn)
        {
            // Call the ToggleRotation method on the RotateObject to set the target rotation speed
            rotateObject.ToggleRotation(isOn);
        }
    }
}
