using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateEnemy : MonoBehaviour {

    [SerializeField]
    GameObject enemyObject;

    private Lane _lane;

    [SerializeField]
    float createSpeed = 1;
    private float _time;
    //private const float _DEFAULT_POS_Y = 20;

    private int _randomInt;

    private List<Vector3> _lanePos;
    private float _laneSizeY;

	void Start () {
        _time = createSpeed;

        //レーン情報取得
        _lane = FindObjectOfType<Lane>();
        _lanePos = _lane.GetLaneList();
        _laneSizeY = _lane.GetLaneSizeY();
	}
	
	void Update () {
        //エネミー生成
        _time -= Time.deltaTime;
        if (_time <= 0.0)
        {
            _time = createSpeed;

            //エネミー生成
            _randomInt = Random.Range((int)0, (int)_lane.GetLaneNum());
            Vector3 pos = _lanePos[_randomInt] + new Vector3(0, _laneSizeY, 0);
            Instantiate(enemyObject, pos, new Quaternion(0, 0, 0, 0));
        }
	}
}
