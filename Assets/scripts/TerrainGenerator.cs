using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int width = 256;
    public int length = 256;
    public int depth = 20;

    public float scale = 20f;

    public float offsetX = 100f;
    public float offsetY = 100f;

    public float speed = 2.5f;


    void Start()
    {
        offsetX = Random.Range(0f, 9999f);
        offsetY = Random.Range(0f, 9999f);
    }


    void Update ()
    {
       Terrain terrain = GetComponent<Terrain>();

       terrain.terrainData = GenerateTerrain(terrain.terrainData);

        offsetX += Time.deltaTime * speed / 2;
        offsetY += Time.deltaTime * -speed / 2;

    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;

        terrainData.size = new Vector3(width, depth, length);

        terrainData.SetHeights(0, 0, GenerateLengths());

        return terrainData;
    }

    float[,] GenerateLengths()
    {
        float[,] heights = new float[width, length];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < length; y++)
            {
                heights[x, y] = CalculateLength(x, y);
            }
        }

        return heights;
    }

    float CalculateLength (int x, int y)
    {
        float xCord = (float)x / width * scale + offsetX;
        float yCord = (float)y / length * scale + offsetY;

        return Mathf.PerlinNoise(xCord, yCord);
    }

}
