using UnityEngine;
using System.Collections;

using Common;

public class PlayerScript : MonoBehaviour {

    
    [SerializeField]
    int _playerHp = 1;

    //位置情報取得
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public Vector3 GetScale()
    {
        return transform.localScale;
    }

	void Start () {
        //_playerHp = 1;
	}

    public void SubLife(int damage)
    {
        //ダメージ！
        _playerHp -= damage;
        //hpなかったら死
        if (_playerHp <= 0)
        {
            GameObject parent = transform.root.gameObject;
            Destroy(parent);

            //シーン切り替え
            FindObjectOfType<sceneManager>().NextScene(Define.GAME_OVER);
        }
    }
	void Update () {
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Enemy") {
            _playerHp -= 1;
        } 
    }

}
