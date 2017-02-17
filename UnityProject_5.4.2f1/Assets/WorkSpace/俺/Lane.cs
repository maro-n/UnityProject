using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lane : MonoBehaviour
{

    private PlayerScript _player;
    [SerializeField]
    private GameObject _LaneObj;

    //レーン数
    [SerializeField]
    private int _laneCount = 4;
    public int GetLaneNum()
    {
        return _laneCount;
    }


    //レーンごとのポジション
    private List<Vector3> _lanePos;
    public List<Vector3> GetLaneList()
    {
        return _lanePos;
    }

    private float _laneSizeY;
    public float GetLaneSizeY()
    {
        return _laneSizeY;
    }

    void Awake()
    {
        _player = FindObjectOfType<PlayerScript>();
        _lanePos = new List<Vector3>() { };

        //ポジションの計算
        float playerScaleX = _player.GetScale().x;
        Vector3 playerPos = _player.transform.position;
        for (int i = 0; i < _laneCount; i++)
        {
            float pos = ((playerScaleX / ((float)_laneCount * 2)) * (i * 2 + 1)) + (playerScaleX / 2 * -1);
            _lanePos.Add(new Vector3(pos, playerPos.y, playerPos.z));

            //レーン生成
            if (i == 0)
            {
                GameObject laneObjLeft = Instantiate<GameObject>(_LaneObj);
                _laneSizeY = laneObjLeft.transform.localScale.y;
                laneObjLeft.transform.position
                    = new Vector3(playerScaleX * (i / _laneCount) + (playerScaleX / 2 * -1), playerPos.y + (_laneSizeY / 2), playerPos.z);
            }
            GameObject laneObjRight = Instantiate<GameObject>(_LaneObj);
            laneObjRight.transform.position
                = new Vector3(playerScaleX * ((i + 1) / (float)_laneCount) + (playerScaleX / 2 * -1), playerPos.y + (_laneSizeY / 2), playerPos.z);
        }
    }
}
