using UnityEngine;
using System.Collections;

public class MapGen : MonoBehaviour
{

    public float TileSize;
    public Vector2 StartPoint;
    public GameObject tile;


    static public int width = 100;
    static public int height = 100;
    private float chanceAlive = 0.45f;
    public int birthLim = 3;
    public int lowdeathLim = 2;
    public int highdeathLim = 3;
    public int numofSteps = 5;
    public bool[,] cellmap = new bool[width, height];

    // Use this for initialization
    void Start()
    {
        cellmap = genMap();
        applyTileMap();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool[,] initializeMap(bool[,] map)
    {
        for (int x = 0; x < map.GetLength(0); ++x)
        {
            for (int y = 0; y < map.GetLength(1); ++y)
            {
                if (Random.Range(0.0f, 1.0f) < chanceAlive)
                {
                    map[x, y] = true;
                }
                else
                {
                    map[x, y] = false;
                }
            }
        }
        return map;
    }

    public bool[,] simStep(bool[,] oldmap)
    {
        bool[,] newmap = new bool[width, height];
        for (int x = 0; x < oldmap.GetLength(0); ++x)
        {
            for (int y = 0; y < oldmap.GetLength(1); ++y)
            {
                int neighbors = countAliveNeighbors(oldmap, x, y);
                if (oldmap[x, y])
                {
                    if (neighbors < lowdeathLim)
                    {
                        newmap[x, y] = false;
                    }
                    else if(neighbors > highdeathLim)
                    {
                        newmap[x, y] = false;
                    }
                    else
                    {
                        newmap[x, y] = true;
                    }
                }
                else
                {
                    if (neighbors == birthLim)
                    {
                        newmap[x, y] = true;
                    }
                    else
                    {
                        newmap[x, y] = false;
                    }
                }
            }
        }
        return newmap;
    }

    public int countAliveNeighbors(bool[,] map, int x, int y)
    {
        int count = 0;
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                int neighbor_x = x + i;
                int neighbor_y = y + j;
                if (i == 0 && j == 0)
                {

                }
                //map size checking
                else if (neighbor_x < 0 || neighbor_y < 0 || neighbor_x >= map.GetLength(0) || neighbor_y >= map.GetLength(1))
                {
                   count++;
                }
                else if (map[neighbor_x, neighbor_y])
                {
                    count++;
                }
            }
        }

        return count;
    }

    public bool[,] genMap()
    {
        bool[,] genCellMap = new bool[width, height];
        genCellMap = initializeMap(genCellMap);
        for (int i = 0; i < numofSteps; ++i)
        {
            genCellMap = simStep(genCellMap);
        }
        return genCellMap;
    }


    public void applyTileMap()
    {
        TileSize = 1;
        StartPoint = new Vector2(1, 1);
        PopTileMap();
    }

    public void PopTileMap()
    {
        for (int x = 0; x < cellmap.GetLength(0); ++x)
        {
            for (int y = 0; y < cellmap.GetLength(1); ++y)
            {
                if (cellmap[x, y])
                {
                    tile = Resources.Load("Prefabs\\Wall") as GameObject;
                }
                else
                {
                    tile = Resources.Load("Prefabs\\Floor") as GameObject;
                }

                GameObject tileMap = Instantiate(tile, Vector3.zero, Quaternion.identity) as GameObject;
                tileMap.transform.position = new Vector3(StartPoint.x + (TileSize * x) + (TileSize / 2), StartPoint.y + (TileSize * y) + (TileSize / 2), 0);
            }
        }

    }

}
