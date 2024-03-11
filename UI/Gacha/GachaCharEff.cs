using DG.Tweening;
using UnityEngine;

public class GachaCharEff : MonoBehaviour
{
    private Vector3 origin;
    private Transform _transform;
    
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        origin = _transform.position;
    }

    private void OnEnable()
    {
        _transform.position = origin;
        _transform.DOMove(new Vector3(1, 0, 0), 0.5f).SetRelative(true);
    }

}
