using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class headpanel : MonoBehaviour
{
    public GameObject whiteGameObject;
    public Button toButton;
    public Button FPButton;

   

    public TextMeshProUGUI topText;
    public TextMeshProUGUI FPText;

    private void Start()
    {
        toButton.onClick.AddListener(OnTemperatureButtonClick);
        FPButton.onClick.AddListener(OnLightsButtonClick);
    }

    public void OnTemperatureButtonClick()
    {
        MoveBlackGameObject(toButton.transform.position.x);

        

        ChangeTextColor(topText, Color.black);
        ChangeTextColor(FPText, Color.white);
    }

    public void OnLightsButtonClick()
    {
        MoveBlackGameObject(FPButton.transform.position.x);

        

        ChangeTextColor(topText, Color.white);
        ChangeTextColor(FPText, Color.black);
    }

    private float moveSpeed = 3.2f; // Adjust as needed for desired speed

    private void MoveBlackGameObject(float targetX)
    {
        Vector3 targetPosition = whiteGameObject.transform.position;
        targetPosition.x = targetX;

        StartCoroutine(MoveCoroutine(targetPosition));
    }

    private IEnumerator MoveCoroutine(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        Vector3 startPosition = whiteGameObject.transform.position;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * moveSpeed;
            whiteGameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime);
            yield return null;
        }

        // Ensure final position
        whiteGameObject.transform.position = targetPosition;
    }

    private void ActivatePanel(GameObject panel)
    {
        if (panel != null)
            panel.SetActive(true);
    }

    private void DeactivatePanel(GameObject panel)
    {
        if (panel != null)
            panel.SetActive(false);
    }

    private void ChangeTextColor(TextMeshProUGUI text, Color color)
    {
        text.color = color;
    }
}
