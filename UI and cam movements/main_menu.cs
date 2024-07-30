using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_menu : MonoBehaviour
{
    public GameObject all_panels;
    public GameObject menu_icon;
    public GameObject cancel_icon;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void On_menu_clicked()
    {
        cancel_icon.SetActive(true);
        menu_icon.SetActive(false);

        all_panels.SetActive(true);
    }

    public void On_cancel_cliked()
    {
        menu_icon.SetActive(true);
        cancel_icon.SetActive(false);
        all_panels.SetActive(false);
    }
}
