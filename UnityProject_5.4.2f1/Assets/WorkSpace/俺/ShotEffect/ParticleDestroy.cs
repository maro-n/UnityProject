using UnityEngine;
using System.Collections;

public class ParticleDestroy : MonoBehaviour {
    [SerializeField]
    float _dispTime;
   
	void Update () 
    {
        _dispTime -= 1;

        if (_dispTime <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
