
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
    public int depth = 20;
    public float scale = 20f;

    private void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);

    }
    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, generateHeights());
        return terrainData;

    }
    float[,] generateHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                heights[x, y] = calculateheight(x, y);
            }
        }
        return heights;
    }
    float calculateheight(int x, int y)
    {
        float xcord = (float)x / width * scale;
        float ycord = (float)y / height * scale;

        return Mathf.PerlinNoise(xcord,ycord);
    }
}
