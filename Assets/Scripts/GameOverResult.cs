using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverResult : MonoBehaviour
{
    public Text resultText;
    // Start is called before the first frame update
    void Start()
    {
        resultText.text = GameData.result.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}