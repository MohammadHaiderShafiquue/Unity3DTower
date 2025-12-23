using UnityEngine;

public class CameraAutoFit : MonoBehaviour
{
    public float padding = 4f;
    public float height = 12f;

    void Start()
    {
        FitCamera();
    }

    void FitCamera()
    {
        Renderer[] renderers =
            FindObjectsByType<Renderer>(FindObjectsSortMode.None);

        if (renderers.Length == 0) return;

        Bounds bounds = renderers[0].bounds;
        foreach (Renderer r in renderers)
            bounds.Encapsulate(r.bounds);

        Vector3 center = bounds.center;
        float size = Mathf.Max(bounds.size.x, bounds.size.z) + padding;

        transform.position = center + new Vector3(0f, height, -size);
        transform.LookAt(center);
    }
}
