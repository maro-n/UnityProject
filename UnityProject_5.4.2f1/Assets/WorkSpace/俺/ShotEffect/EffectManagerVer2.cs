using UnityEngine;
using System.Collections;

public class EffectManagerVer2 : MonoBehaviour
{
    private bool _play;

    private GameObject _topObj;
    [SerializeField]
    private GameObject _effectObj;

    [SerializeField]
    private int _createSpeed = 1;
    private float _count = 0;

    private int _createLimit = 4;
    private int _createCount = 0;

    private Vector3 _defaultPos = new Vector3(0, 0, 0);
    private Vector3 _angle = new Vector3(0, 0, 60);
    private int _way = 1;

    private ParticleSystem _particleSystem;
    [SerializeField]
    private float _MAXPOSY;

    void Awake()
    {

        _topObj = Instantiate(_effectObj);
        _topObj.transform.Rotate(_angle);
        _topObj.transform.position = _defaultPos;
        _topObj.tag = "Shot";

        _play = false;

        _count = 0;
    }

    public void SetDefaltPos(Vector3 pos){
        _defaultPos = pos;
        _topObj.transform.position = _defaultPos;
        _play = true;
    }

    void Start()
    {
        _MAXPOSY = FindObjectOfType<Lane>().GetLaneSizeY();
    }

    void Update()
    {
        if (!_play) return;
        _count += Time.deltaTime;
        //if (_count >= _createSpeed)
        for (int i = 0; i < _createSpeed; i++)
        {
            if (_topObj.transform.position.y >= _MAXPOSY)
            {
                Destroy(this.gameObject);
            }

            //次のオブジェを生成＆位置角度調整
            GameObject nextObj = Instantiate(_effectObj);
            float degree = (_angle.z + 90);
            float radian = degree * Mathf.PI / 180;
            float sizeY = _topObj.transform.localScale.y;
            float posX = Mathf.Cos(radian) * sizeY;
            float posY = Mathf.Sin(radian) * sizeY;
            Vector3 pos = (new Vector3(posX, posY, 0)) + _topObj.transform.position;
            nextObj.transform.position = pos;
            nextObj.tag = "Shot";
            _topObj = nextObj;

            _createCount++;
            _count = 0;
            if (_createCount >= _createLimit)
            {
                _way = _way * -1;
                if (_way >= 0)
                {
                    _createLimit = Random.Range(8, 8);
                    _angle.z = Random.Range(45, 45);
                }
                _angle *= _way;
                _createCount = 0;
            }
            nextObj.transform.Rotate(_angle);

            _particleSystem = _topObj.transform.FindChild("effectObj").FindChild("Particle System").GetComponent<ParticleSystem>();
            //_particleSystem = _topObj.transform.FindChild("Particle System").GetComponent<ParticleSystem>();
            _particleSystem.startRotation = _way * -1;
        }
    }
}
