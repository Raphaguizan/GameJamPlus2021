using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Game.Util.Matrix;

namespace Game.Minigame.FollowTheChick
{
    public class MatrixController : MonoBehaviour
    {
        [SerializeField]
        private FollowTheChickStateMachine manager;
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
        private StudentChicken currentPoint;

        private int pathIndex = 0;
        private int playerPathIndex = 0;
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
                    aux.transform.position = transform.position + new Vector3(space * j, 0, space * i);
                    aux.gameObject.name = "(" + i + "," + j + ")";
                    StudentChicken stdChicken = aux.gameObject.GetComponent<StudentChicken>();
                    if (stdChicken) stdChicken.Initialize(this, new Vector2Int(i, j));
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
            for (int i = 1; i < length - 1; i++)
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
            if (pathIndex >= PathLength) return null;

            Vector2Int point = path[pathIndex];
            var obj = matrix.GetPos(point.x, point.y);

            StudentChicken std = obj.GetComponent<StudentChicken>();
            if (std) currentPoint = std.SelectChicken();

            pathIndex++;
            return obj.transform;
        }

        public void HitPoint(float timeDelay)
        {
            if(currentPoint != null)
            {
                currentPoint.MakeAnimation(timeDelay);
                currentPoint = null;
            }
        }

        public void VerifyPlayerPath(Vector2Int pathPoint)
        {
            if(path[playerPathIndex] == pathPoint)
            {
                playerPathIndex++;
            }
            else
            {
                manager.Lose();
            }

            if (playerPathIndex == path.Count)
            {
                manager.Win();
            }
        }

        public void CallKarenTurn()
        {
            manager.KarenTurn();
        }
    }
}