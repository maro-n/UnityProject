using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Common;

public class Shooting : MonoBehaviour {

    [SerializeField]
    private GameObject _bullet;
    private Lane _lane;
    private List<Vector3> _lanePos;

    //public Transform muzzle;

    void Start () {
       // Shoot();
        _lane = FindObjectOfType<Lane>();
        _lanePos = _lane.GetLaneList();
    }

	void Update () {
        Shoot();
    }

    void Shoot() {
        ShootSystem(0, Define.SHOT_KEY1);
        ShootSystem(1, Define.SHOT_KEY2);
        ShootSystem(2, Define.SHOT_KEY3);
        ShootSystem(3, Define.SHOT_KEY4);
    }

    private void ShootSystem(int laneNum,KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            GameObject bullet = GameObject.Instantiate(_bullet);
            EffectManagerVer2 effect = bullet.GetComponent<EffectManagerVer2>();
            Vector3 pos = _lanePos[laneNum];
            effect.SetDefaltPos(pos);
        }
    }
}
