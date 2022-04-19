using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.AI;

public class MatrixController : MonoBehaviour
{
    [SerializeField]
    private GameObject chickenPrefab;
    [SerializeField]
    private Vector2Int matrixDimensions;
    [SerializeField]
    private float space = 3f;

    [Space, SerializeField]
    private Matrix<GameObject> matrix;

    [Header("Path")]
    [SerializeField]
    private int PathLength;
    [SerializeField]
    private List<Vector2Int> path;

    private int pathIndex = 0;
    private NavMeshObstacle prevObstacle;
    void Start()
    {
        path = new List<Vector2Int>();
        SpawnMatrix();
        SortPath(PathLength);
    }

    public void SpawnMatrix()
    {
        matrix = new Matrix<GameObject>(matrixDimensions.x, matrixDimensions.y);
        for (int i = 0; i < matrix.lines; i++)
        {
            for (int j = 0; j < matrix.colluns; j++)
            {
                GameObject aux = Instantiate(chickenPrefab, transform);
                matrix.SetPos(i, j, aux);
                aux.transform.position = transform.position + new Vector3(space*j, 0, space*i);
                aux.gameObject.name = "(" + i + "," + j + ")";
            }
        }
    }

    [Button]
    public void LoadPath()
    {
        SortPath(PathLength);
    }

    public void SortPath(int length)
    {
        if (length == 0) return;
        path.Add(new Vector2Int(0, Random.Range(0, matrix.colluns)));
        Vector2Int newPath;
        for (int i = 1; i < length-1; i++)
        {
            do
            {
                newPath = new Vector2Int(Random.Range(0, matrix.lines), Random.Range(0, matrix.colluns));
            } while (newPath == path[i - 1]);
            
            path.Add(newPath);
        }
        do
        {
            newPath = new Vector2Int(matrix.lines - 1, Random.Range(0, matrix.colluns));
        } while (newPath == path[PathLength - 2]);
        path.Add(newPath);
    }

    [Button]
    public Transform NextPathPoint()
    {
        if (prevObstacle) prevObstacle.enabled = true;

        if (pathIndex >= PathLength) return null;

        Vector2Int point = path[pathIndex];
        var obj = matrix.GetPos(point.x, point.y);

        NavMeshObstacle navMesh = obj.GetComponent<NavMeshObstacle>();
        navMesh.enabled = false;
        prevObstacle = navMesh;

        pathIndex++;
        return obj.transform;
    }
}
