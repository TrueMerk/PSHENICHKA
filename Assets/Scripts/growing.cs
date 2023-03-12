using UnityEngine;

public class growing : MonoBehaviour
{
    
    [SerializeField] private float _maxTime;
    [SerializeField] private float _speed;
    [SerializeField] private float _growth;
    private bool _max;
    
    private void Update()
    {
        GrowerMethod();
    }

    private void GrowerMethod()
    {
        _growth += 1 * Time.deltaTime;
        if (_max == false)
        {
            gameObject.transform.localScale +=
                new Vector3(_speed * Time.deltaTime, _speed * Time.deltaTime, _speed * Time.deltaTime);
        }

        if (_growth >= _maxTime)
        {
            _max = true;
        }
    }
}