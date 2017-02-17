using UnityEngine;
using System.Collections;

//RigidBodyの追加
[RequireComponent(typeof(Rigidbody))]

public class Status : MonoBehaviour {

    //スコアオブジェクト
    private Score _score;

    //スコア
    [SerializeField]
    private int _scoreOwn = 100;

    //移動速度
	[SerializeField]
	private float _moveSpeed = 1;
	public float GetMoveSpeed()
    {
		return _moveSpeed;
	}
    //ライフ
	[SerializeField]
    private int _life = 1;

    //攻撃力
    [SerializeField]
    private int _attackVal = 1;
    public int GetAttackVal()
    {
        return _attackVal;
    }

    //消滅時のエフェクト
    [SerializeField]
    ParticleSystem _destroyParticle;

    public void SubLife(int damage)
    {
        if (_life > 0)
        {
            _life -= damage;
        }
        if (_life <= 0)
        {
            _life = 0;
            DestroyOwn();
        }
    }

    //リジッドボディー
    private Rigidbody _rigidbody;
    public Rigidbody GetRigidbody()
    {
        return _rigidbody;
    }

    private void Awake()
    {
        this.tag = "Enemy";
        _rigidbody = GetComponent<Rigidbody>();

        _score = FindObjectOfType<Score>();
    }

    //消滅
    private void DestroyOwn()
    {
        //スコア加算関数呼び出し
        _score.AddScoreForEnemy(_scoreOwn);

        //消滅エフェクト
        ParticleSystem particle = Instantiate(_destroyParticle);
        particle.transform.position = this.transform.position;
        //消滅
        Destroy(gameObject);
    }
}