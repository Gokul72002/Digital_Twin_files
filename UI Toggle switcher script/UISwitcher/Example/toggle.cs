using UnityEngine;
using UnityEngine.UI;

namespace UISwitcher {
	public class toggle : MonoBehaviour {

		[SerializeField] private UISwitcher switcher1;

		public GameObject[] visulizer;


		private void Awake() {
			//You can use UnityEvents
			switcher1.onValueChanged.AddListener(OnValueChanged1);

			//You can Set and get isOn value

			//You can also Set and get isOnNullable value
			
		}

		private void OnValueChanged1(bool isOn) {


			if (switcher1.isOn)
			{
				foreach (var vishulize in visulizer)
				{
					vishulize.SetActive(true);
				}
			}


			else
			{
				foreach (var vihulize in visulizer)
				{
					vihulize.SetActive(false);

				}

			}
				
		}

		
	}
}