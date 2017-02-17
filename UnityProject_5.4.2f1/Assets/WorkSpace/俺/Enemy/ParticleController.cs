
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _particle = null;

    [SerializeField]
    Color _color = Color.white;

    void OnValidate()
    {
        if (_particle == null) { return; }
        _particle.startColor = _color;
    }
}
