using UnityEngine;
using System.Collections;

public class TestEnemyScript : MonoBehaviour {

    [SerializeField]
     float speed =-0.5f;
	
    // Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        MoveEnemy();
    }

    void MoveEnemy() {
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(0.0f, speed, 0.0f);
        }


    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }

    }
}
