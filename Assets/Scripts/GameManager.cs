using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] Text score1;
    [SerializeField] Text score2;
    [SerializeField] Text playerWins;
    [SerializeField] UnityEvent gameoverEvent;
    [SerializeField] UnityEvent restartEvent;

    private int PlayerScore1;
    private int PlayerScore2;


    private void Start()
    {
        Invoke("RestartGame", 3);
    }

    public void Score(string wall)
    {
        if (wall == "RightWall")
        {
            PlayerScore1++;
            UpdateScores();

            if (PlayerScore1 >= 10)
            {
                playerWins.text = "Player 1 Wins";
                gameoverEvent.Invoke();
            }
            else
            {
                UpdateScores();
                restartEvent.Invoke();
            }
        }
        else
        {
            PlayerScore2++;
            UpdateScores();

            if (PlayerScore2 >= 10)
            {
                playerWins.text = "Player 2 Wins";
                gameoverEvent.Invoke();
            }
            else
            { 
                restartEvent.Invoke();
            }
        }
    }

    public void RestartGame()
    {
        PlayerScore1 = 0;
        PlayerScore2 = 0;
        playerWins.text = "";

        UpdateScores();
        restartEvent.Invoke();
    }

    private void UpdateScores()
    {
        score1.text = PlayerScore1.ToString();
        score2.text = PlayerScore2.ToString();
    }
}
