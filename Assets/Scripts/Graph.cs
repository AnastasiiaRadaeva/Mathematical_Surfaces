using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private Transform pointPrefab;
    [SerializeField, Range(10, 100)] private int resolution = 10;
    [SerializeField, Range(0, 2)] private int function;
    
    private Transform[] _points;

    private void Awake()
    {
        float step = 2f / resolution;
        var scale = Vector3.one * step;
        var position = Vector3.zero;

        _points = new Transform[resolution];
        
        for (int i = 0; i < _points.Length; i++)
        {
            var point = _points[i] = Instantiate(pointPrefab, transform, false);
            position.x = (i + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
        }
    }

    private void Update()
    {
        float time = Time.time;
        
        foreach (var point in _points)
        {
            var position = point.localPosition;
            position.y = function switch
            {
                0 => FunctionLibrary.Wave(position.x, time),
                1 => FunctionLibrary.MultiWave(position.x, time),
                _ => FunctionLibrary.Ripple(position.x, time)
            };
            point.localPosition = position;
        }
    }
}
