using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    public static int currentScore;
    public static int highscore;
    public static int currentLevel;
    public static int unlockedLevel;

	public static void CompleteLevel()
    {
        currentLevel += 1;
        Application.LoadLevel(currentLevel);
    }
}
