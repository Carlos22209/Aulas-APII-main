using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    int pontos = 0;
    [SerializeField] List<int> scores = new List<int>();

    [SerializeField] private TextMeshProUGUI pontosDisplay;
    [SerializeField] private TextMeshProUGUI highscoreDisplay;


    public void AdicionarPonto()
    {
        pontos++;
        AtualizarUI();
    }

    public void Reset()
    {
        scores.Add(pontos);
        pontos = 0;
        AtualizarUI();
    }

    private void AtualizarUI()
    {
        pontosDisplay.text = pontos.ToString("000");
        AtualizarHighscore();
    }

    private void AtualizarHighscore()
    {
        scores.Remove(0);
        if(scores.Count>5) scores.RemoveAt(0);

        int maiorScore = 0;
        for(int i = 0; i < scores.Count; i++)
        {
            if (scores[i] > maiorScore) maiorScore = scores[i];
        }
        highscoreDisplay.text = maiorScore.ToString("000");
    }
}
