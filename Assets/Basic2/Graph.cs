using UnityEngine;

public class Graph : MonoBehaviour
{
    void Awake()
    {
        float step = 2f / resolution;
        var scale = Vector3.one * step;
        mPoints = new Transform[resolution * resolution];
        for (int i = 0; i < mPoints.Length; i++)
        {
            Transform point = mPoints[i] = Instantiate(mPointPrefab);
            point.localScale = scale;
            point.SetParent(transform, false);
        }
    }

    void Update()
    {
        FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);
        float time = Time.time;
        float step = 2f / resolution;
        float v = 0.5f * step - 1f;
        for (int i = 0, x = 0, z = 0; i < mPoints.Length; i++, x++)
        {
            if (x == resolution)
            {
                x = 0;
                z += 1;
                v = (z + 0.5f) * step - 1f;
            }
            float u = (x + 0.5f) * step - 1f;
            mPoints[i].localPosition = f(u, v, time);
        }
    }

    [SerializeField]
    private Transform mPointPrefab;
    [SerializeField, Range(10, 100)]
    private int resolution = 10;
    [SerializeField]
    FunctionLibrary.FunctionName function;

    Transform[] mPoints;
}
