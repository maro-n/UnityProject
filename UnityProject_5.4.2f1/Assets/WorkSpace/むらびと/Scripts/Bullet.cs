using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    [SerializeField]
   public float bullet_speed = 1.0f;

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0.0f, bullet_speed, 0.0f);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }

    }


    void OnBecameInvisible() {
        Destroy(this.gameObject);
    }

    void BulletType() {

    }

    void BulletSpeed() {

    }
}
