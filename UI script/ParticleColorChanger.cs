using UnityEngine;

public class ParticleColorChanger : MonoBehaviour
{
/*    public new ParticleSystem particleSystem;
*/    private float temperature; // This is the variable that determines the color

    // Public variables to set the colors in the Inspector
    public Color inRangeColor;
    public Color midrange;
    public Color outOfRangeColor;

    // Shader Graph material and its color property name
    public Material shaderGraphMaterial;
    public string colorPropertyName = "_BaseColor"; 
    public string breathSpeed = "_BreathSpeed";
    public string breath = "_Breath";

    void Start()
    {
        /*if (particleSystem == null)
        {
            particleSystem = GetComponent<ParticleSystem>();
        }*/
    }

    public void SetTemperature(float temperature)
    {
        this.temperature = temperature;
        /*UpdateParticleColor();*/
        UpdateShaderGraphMaterialColor();
    }

    /*// For fog particle
    void UpdateParticleColor()
    {
        var main = particleSystem.main;
        if (temperature >= 15 && temperature <= 30)
        {
            main.startColor = inRangeColor;
        }
        else if (temperature >= 31 && temperature == 32)
        {
            main.startColor = midrange;
        }
        else if (temperature >= 33 && temperature == 38)
        {
            main.startColor = outOfRangeColor;
        }
    }*/

    // For shader graph
    void UpdateShaderGraphMaterialColor()
    {
        if (shaderGraphMaterial != null)
        {
            if (temperature >= 15 && temperature <= 30)
            {
                shaderGraphMaterial.SetColor(colorPropertyName, inRangeColor);
                shaderGraphMaterial.SetFloat(breathSpeed, 1.0f); // Example value
                shaderGraphMaterial.SetFloat(breath, -1.24f); // Example value
            }
            else if (temperature >= 31 && temperature == 32)
            {
                shaderGraphMaterial.SetColor(colorPropertyName, midrange);
                shaderGraphMaterial.SetFloat(breathSpeed, 1f); // Example value
                shaderGraphMaterial.SetFloat(breath, 1.24f); // Example value
            }
            else if (temperature >= 33 && temperature == 38)
            {
                shaderGraphMaterial.SetColor(colorPropertyName, outOfRangeColor);
                shaderGraphMaterial.SetFloat(breathSpeed, 1f); // Example value
                shaderGraphMaterial.SetFloat(breath, 1.24f); // Example value
            }
        }
    }
}
