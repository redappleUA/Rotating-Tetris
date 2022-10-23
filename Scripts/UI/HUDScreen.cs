using UnityEngine.UIElements;
using UnityEngine;

public class HUDScreen : MonoBehaviour
{
    private Label score;
    void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        score = root.Q<Label>("ScoreLabel");
        score.style.display = DisplayStyle.Flex;
    }
    void Update()
    {
        score.text = Score.ScorePoints.ToString() + " points";

        if(Time.timeScale < .2f) gameObject.SetActive(false);
    }
}
