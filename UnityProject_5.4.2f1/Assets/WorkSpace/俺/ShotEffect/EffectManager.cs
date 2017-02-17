using UnityEngine;
using System.Collections;

public class EffectManager : MonoBehaviour {

    [SerializeField]
    private GameObject _effectObj;
    private GameObject _controlObj;
    [SerializeField]
    private Vector3 _defaultPos = new Vector3(0, -20, 0);

    private Vector3 _angle = new Vector3(0, 0, 60);
    private int _way = 1;
    [SerializeField]
    private Vector3 _entendSpeed = new Vector3(0, 0.1f, 0);

    private float _MAXSIZEY = 5;

    private ParticleSystem _particleSystem;

	void Start () {
        _controlObj = Instantiate(_effectObj);
        _controlObj.transform.Rotate(_angle);
        _controlObj.transform.position = _defaultPos;
	}
	
	void Update () {
        _controlObj.transform.localScale =
            _controlObj.transform.localScale + _entendSpeed;
        if (_controlObj.transform.localScale.y >= _MAXSIZEY)
        {
            //次のオブジェを生成＆位置角度調整
            GameObject nextObj = Instantiate(_effectObj);
            float degree = (_angle.z+90);
            float radian = degree * Mathf.PI / 180;
            float sizeY = _controlObj.transform.localScale.y;
            float posX = Mathf.Cos(radian) * sizeY;
            float posY = Mathf.Sin(radian) * sizeY;
            Vector3 pos = (new Vector3(posX, posY, 0))+_controlObj.transform.FindChild("effectObj").transform.position;
            nextObj.transform.position = pos;

            _controlObj = nextObj;

            _way = _way *-1;
            if(_way>=0){
            _MAXSIZEY = Random.Range(6, 6);
            _angle.z = Random.Range(40, 40);
            }
            _angle*=_way;
            nextObj.transform.Rotate(_angle);

            _particleSystem = _controlObj.transform.FindChild("effectObj").FindChild("Particle System").GetComponent<ParticleSystem>();
            _particleSystem.startRotation = _angle.z;
        }
	}
}
