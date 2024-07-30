using UnityEngine;
using UnityEngine.UI;

public class ToggleObject : MonoBehaviour
{
   
    public GameObject tempindicator;
    public Button enableButton; // The button to enable the GameObject
    public Button disableButton;
    public GameObject fog;// The button to disable the GameObject

    void Start()
    {
        // Assign the button click listeners
        enableButton.onClick.AddListener(EnableObject);
        disableButton.onClick.AddListener(DisableObject);
    }

    void EnableObject()
    {
        fog.gameObject.SetActive(true);
  
        tempindicator.SetActive(true);
    }

    void DisableObject()
    {
        fog.gameObject.SetActive(false);
       
       
        tempindicator.SetActive(false);
    }
}
