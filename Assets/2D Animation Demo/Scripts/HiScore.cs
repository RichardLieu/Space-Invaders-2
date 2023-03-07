using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HighScore", menuName = "Objects/HighScore", order = 1)]
public class HiScore : ScriptableObject
{
    public int Score;
    public string HiScoreText;
}
