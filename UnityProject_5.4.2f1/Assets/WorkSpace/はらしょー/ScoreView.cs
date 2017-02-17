using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreView : MonoBehaviour
{
    // 数字画像
    [SerializeField]
    private Sprite[] numimage;
    private List<int> number = new List<int>();

    // 全部で何種類の数字を表示するか
    private const int _dispInfo = 4;

    private bool isResult = true;

    void Update()
    {
        if (isResult)
        {
            //var scoreObj = FindObjectOfType<Score>();
            //scoreObj.SortingHighScore();
            ViewScore();
            isResult = false;
        }
    }

    public void ViewScore()
    {
        // スコア表示個数だけループ
        for (int i = 0; i <= _dispInfo - 1; i++)
        {
            var score = 0;

            if (i == 3)
            {
                score = Score._toScore;
            }
            else
            {
                score = Score._rankingScore[i];
            }

            UpdateScore(score, i);
        }
    }
    //スコアを表示するメソッド
    void UpdateScore(int score, int type)
    {
        var digit = score;
        //要素数0には１桁目の値が格納
        number = new List<int>();
        if (digit == 0)
        {
            number.Add(digit);
        }
        else
        {
            while (digit != 0)
            {
                score = digit % 10;
                digit = digit / 10;
                number.Add(score);
            }
        }

        GameObject.Find("ScoreImage" + type.ToString()).GetComponent<Image>().sprite = numimage[number[0]];
        for (int i = 1; i < number.Count; i++)
        {
            //複製
            const int margin = 30;
            RectTransform scoreimage = (RectTransform)Instantiate(GameObject.Find("ScoreImage" + type.ToString())).transform;
            scoreimage.SetParent(this.transform, false);
            scoreimage.localPosition = new Vector2(
                scoreimage.localPosition.x - (scoreimage.sizeDelta.x - margin) * i,
                scoreimage.localPosition.y);
            scoreimage.GetComponent<Image>().sprite = numimage[number[i]];
        }
    }
}