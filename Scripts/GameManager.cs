using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Hole[] holes;

    public int badMoleCount, goodMoleCount;
    private float timerTime;

    [SerializeField] private Text timerTimeText, badMoleCountText, goodMoleCountText;

    [SerializeField] private GameObject readyUI;
    [SerializeField] private GameObject actionUI;

    [SerializeField] private GameObject resultUI;
    [SerializeField] private Text resultBadMoleCountText;
    [SerializeField] private Text resultGoodMoleCountText;
    [SerializeField] private Text resultScoreText;

    [SerializeField] private Button replayButton;

    public bool IsGameOver
    {
        get
        {
            return timerTime <= 0f;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PlayGame();
    }

    public void PlayGame()
    {
        StartCoroutine(PlayGameCoroutine());
    }

    private IEnumerator PlayGameCoroutine()
    {
        resultUI.SetActive(false);
        badMoleCount = 0;
        goodMoleCount = 0;
        timerTime = 0f;
        timerTimeText.text = "60:00";

        readyUI.SetActive(true);
        yield return new WaitForSeconds(3f);
        readyUI.SetActive(false);
        actionUI.SetActive(true);
        yield return new WaitForSeconds(1f);
        actionUI.SetActive(false);

        foreach (var hole in holes)
        {
            hole.animator.SetBool("Start", true);
        }

        timerTime = 60f;
        float _time = 0f;
        while (timerTime > 0f)
        {
            _time += Time.deltaTime;
            timerTime = Mathf.Lerp(60f, 0f, _time / 60f);
            badMoleCountText.text = badMoleCount.ToString();
            goodMoleCountText.text = goodMoleCount.ToString();
            timerTimeText.text = (int)timerTime / 10 % 10 + "" + (int)timerTime % 10 + ":" + (int)(timerTime * 10) % 10 + "" + (int)(timerTime * 100) % 10;
            yield return null;
        }

        resultBadMoleCountText.text = badMoleCount.ToString();
        resultGoodMoleCountText.text = goodMoleCount.ToString();
        resultScoreText.text = "Score : " + (badMoleCount * (100) + goodMoleCount * (-1000)).ToString();
        replayButton.interactable = false;
        resultUI.SetActive(true);

        yield return new WaitForSeconds(5f);
        replayButton.interactable = true;
    }
}