using TMPro;
using UnityEngine;
using DG.Tweening;
public class MenuManager : MonoBehaviour
{
    public int score, bestScore;
    public TextMeshProUGUI scoreText, finalScoreText, bestScoreText;
    public GameObject restartMenu;

    private void Start()
    {
        //Score = 0;
        //scoreText = GameObject.FindWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        //finalScoreText = GameObject.FindWithTag("FinalScoreText").GetComponent<TextMeshProUGUI>();
        //restartMenu = GameObject.FindWithTag("RestartMenu");//gameobject tipinden olduðu için getcomponent gerek yok
        //restartMenu.SetActive(false);
        score = 0;
        bestScore = 0;
        RestartGame();
    }

    public void AddScore()
    {
        score++;
        scoreText.SetText(score.ToString());
    }

    public void FetchRestartMenu()
    {
        if(bestScore < score)
        {
            bestScore = score;
            bestScoreText.SetText(bestScore.ToString());
        }
        finalScoreText.SetText(score.ToString());
        scoreText.gameObject.SetActive(false);

        restartMenu.SetActive(true);
        restartMenu.transform.DOMoveY(0f, 1.3f).SetEase(Ease.OutExpo);
    }

    public void RestartGame()
    {
        scoreText.gameObject.SetActive(true);

        restartMenu.transform.DOKill();
        restartMenu.transform.position = new Vector2(0, 10f);
        restartMenu.SetActive(false);
        score = 0;
        scoreText.SetText(score.ToString());
    }

}
