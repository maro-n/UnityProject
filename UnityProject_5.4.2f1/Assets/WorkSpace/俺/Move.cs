using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    //プレイヤーオブジェクト
    private PlayerScript _player;

    private Status _enemyStatus;

    private void Start()
    {
        _enemyStatus = GetComponent<Status>();
        _player = FindObjectOfType<PlayerScript>();
    }

    private void Update()
    {
        Rigidbody rigid = _enemyStatus.GetRigidbody();
        float moveSpeed = _enemyStatus.GetMoveSpeed();
        Vector3 moveForce = new Vector3(0, moveSpeed * -1, 0);
        //移動
        rigid.AddForce(moveForce);
    }
    private void OnTriggerEnter(Collider collider)
    {
        //被弾
        if (collider.gameObject.tag == "Shot")
        {
            _enemyStatus.SubLife(1);
        }

        //攻撃
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            //プレイヤーのライフを減らす関数を呼ぶ
            _player.SubLife(_enemyStatus.GetAttackVal());
        }
    }
}
