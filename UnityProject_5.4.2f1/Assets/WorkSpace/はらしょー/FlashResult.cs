using UnityEngine;
using UnityEngine.UI;

public class FlashResult : MonoBehaviour
{
    private GameObject _resultTexture;
    private float _alpha;

    [SerializeField]
    private float _interval;
    private int _sign;

    void Start()
    {
        _resultTexture = this.gameObject;
        _alpha = 0.0f;
        _sign = -1;
    }

    void Update()
    {
        _alpha = _resultTexture.GetComponent<Image>().color.a;

        if (_alpha >= 1 || _alpha <= 0)
        {
            _interval = _interval * _sign;
        }

        _resultTexture.GetComponent<Image>().color = new Color(255, 255, 255, _alpha + _interval);
    }

}