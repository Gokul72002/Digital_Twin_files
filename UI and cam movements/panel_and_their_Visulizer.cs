using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel_and_their_Visulizer : MonoBehaviour
{
    [Header("Overall")]
    public GameObject[] Overall;

    [Header("Employees")]
    public GameObject[] Employeees;
    public GameObject[] Other_than_Emp;

    [Header("Camera_logo")]
    public GameObject[] Camelogo;
    public GameObject[] Other_than_cam_logo;

    [Header("Light")]
    public GameObject[] Lights;
    public GameObject[] NON_others;

    [Header("Temprature")]
    public GameObject[] temp_shader;
    public GameObject[] Other_detals;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void on_temp_logo_clicked()
    {
        foreach( var temp_Shader in temp_shader)
        { 
            temp_Shader.SetActive(true);
        }

        foreach(var Other_gameobject in Other_detals)
        {
            Other_gameobject.SetActive(false);

        }


    }
    public void On_Light_logo_clicked()
    {
        foreach( var light in Lights)
        {
            light.SetActive(true);
        }

        foreach ( var non_lit in NON_others)
        {
            non_lit.SetActive(false);
        }

    }

    public void On_cam_clicked()
    {
        foreach ( var cam in Camelogo)
        {
            cam.SetActive(true);
        }

        foreach (var Other_than_cam_Logo in Other_than_cam_logo)
        {
            Other_than_cam_Logo.SetActive(false);
        }
    }

    public void ON_Emp_clicked()
    {
        foreach(var emp in Employeees)
        {
            emp.SetActive(true);
        }

        foreach( var other_emp in  Other_than_Emp)
        {
            other_emp.SetActive(false);
        }
    }
     
    public void Over_all()
    {
        foreach ( var overall in Overall)
        {
            overall.SetActive(true);
        }
    }


    
}
