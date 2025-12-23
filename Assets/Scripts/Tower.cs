using UnityEngine;
using TMPro;
using System.Collections;

public class Tower : MonoBehaviour
{
    public Transform towerMesh;
    public TextMeshPro label;

    private float targetHeight;

    public void Initialize(string country, float value, float heightMultiplier)
    {
        targetHeight = value * heightMultiplier;

        towerMesh.localScale = new Vector3(1f, 0f, 1f);
        towerMesh.localPosition = Vector3.zero;

        label.text = country + "\n" + value + "%";

        StartCoroutine(AnimateTower(value));
    }

    IEnumerator AnimateTower(float value)
{
    float t = 0f;
    float duration = 1f;

    Renderer r = towerMesh.GetComponent<Renderer>();
    r.material.color = Color.white;

    while (t < duration)
    {
        t += Time.deltaTime;
        float h = Mathf.Lerp(0f, targetHeight, t / duration);

        towerMesh.localScale = new Vector3(1f, h, 1f);
        towerMesh.localPosition = new Vector3(0f, h / 2f, 0f);
        label.transform.localPosition = new Vector3(0f, h + 0.6f, 0f);

        yield return null;
    }
}

}




