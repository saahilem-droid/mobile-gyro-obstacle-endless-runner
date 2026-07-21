using UnityEngine;

public class LaneSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject obstaclePrefab;

    public float spawnZ = 20f;
    public float rowSpacing = 5f;
    public int rowsAhead = 10;

    private float currentZ;

    void Start()
    {
        currentZ = spawnZ;

        for (int i = 0; i < rowsAhead; i++)
        {
            SpawnRow();
        }
    }

    void Update()
    {
        SpawnRow();
    }

    void SpawnRow()
    {
        int emptyLane = Random.Range(0, 3); // guarantee 1 safe lane

        for (int lane = 0; lane < 3; lane++)
        {
            Vector3 pos = GetLanePosition(lane, currentZ);

            if (lane == emptyLane)
                continue;

            int type = Random.Range(0, 2);

            if (type == 0)
                Instantiate(coinPrefab, pos, Quaternion.identity);
            else
                Instantiate(obstaclePrefab, pos, Quaternion.identity);
        }

        currentZ += rowSpacing;
    }

    Vector3 GetLanePosition(int lane, float z)
    {
        float x = 0;

        if (lane == 0) x = -3;
        if (lane == 1) x = 0;
        if (lane == 2) x = 3;

        return new Vector3(x, 0.509f, z);
    }
}