using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int currentPoints = 0;
    public TMP_Text scoreSystem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreSystem.text = "score: " + currentPoints.ToString();
    }
}
