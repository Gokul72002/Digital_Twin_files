using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click_info_canvas : MonoBehaviour
{
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        // Optionally initialize the panel to be inactive
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
    }

    // Function to toggle the panel's active state
    public void TogglePanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(!Panel.activeSelf);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
