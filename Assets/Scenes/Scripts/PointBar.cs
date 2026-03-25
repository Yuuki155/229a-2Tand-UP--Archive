using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointBar : MonoBehaviour
{
    public PaperCollected paperCollected;
    public TextMeshProUGUI pointText;
    public int points;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        AddPoint();
        UpdateUI();
    }
    public void AddPoint()
    {
        points = paperCollected.paperCount;
    }
    // Update is called once per frame
    void UpdateUI()
    { 
        pointText.text = "Points: " + points.ToString(); 
    }
}
