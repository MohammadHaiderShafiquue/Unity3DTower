using UnityEngine;

public class GraphManager : MonoBehaviour
{
    public GameObject towerPrefab;
    public float spacing = 3.5f;
    public float heightMultiplier = 0.05f;

    void Start()
    {
        ClearOldTowers();
        CreateGraph();
    }

    void ClearOldTowers()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    void CreateGraph()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("data");
        GraphData graphData = JsonUtility.FromJson<GraphData>(jsonFile.text);

        int count = graphData.entries.Length;
        float startOffset = -(count - 1) * spacing / 2f;

        for (int i = 0; i < count; i++)
        {
            Vector3 position = new Vector3(startOffset + i * spacing, 0f, 0f);

            GameObject towerObj = Instantiate(
                towerPrefab,
                position,
                Quaternion.identity,
                transform   // parent under GraphManager
            );

            Tower tower = towerObj.GetComponent<Tower>();
            tower.Initialize(
                graphData.entries[i].country,
                graphData.entries[i].value,
                heightMultiplier
            );
        }
    }
}
