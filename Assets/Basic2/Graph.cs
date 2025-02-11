using UnityEngine;

public class Graph : MonoBehaviour
{
    private void Awake()
    {
        float step = 2f / resolution;
        Vector3 position = Vector3.zero;
        var scale = Vector3.one * step;
        mPoints = new Transform[resolution];
        for(int i = 0; i < mPoints.Length; ++i)
        {
            Transform point = mPoints[i] = Instantiate(mPointPrefab);
            point.SetParent(transform, false);
            position.x = (i + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
        }
    }

    private void Update()
    {
        var time = Time.time;
        for (int i = 0; i < mPoints.Length; i++) {
            Transform point = mPoints[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + time));
            point.localPosition = position;
        }
    }

    [SerializeField]
    private Transform mPointPrefab;
    [SerializeField, Range(10, 100)]
    private int resolution = 10;

    Transform[] mPoints;
}
