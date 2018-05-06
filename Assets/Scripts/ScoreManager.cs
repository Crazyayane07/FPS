using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text scoreText;
	
    public void SetNewText(int number)
    {
        scoreText.text = "Paintings left = " + number.ToString();
    }
}
