using UnityEngine;

public class Loading : MonoBehaviour
{

    Transform _transform;
    [SerializeField] float speed; 

    private void Awake()
    {
        _transform = transform;
    }
    private void Update()
    {
        _transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed));
    }
}
