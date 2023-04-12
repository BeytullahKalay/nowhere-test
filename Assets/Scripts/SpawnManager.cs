using System.Collections.Generic;
using Assets.Scripts.MyScripts;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private Transform coloredBallsParent;

        private List<Ball> _balls = new List<Ball>();

        private Pooler _pooler;

        private void Awake()
        {
            _pooler = Pooler.Instance;
        }
        

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SpawnBallAtMouseAndGiveName(Helpers.GetWorldPositionOfPointer(Helpers.MainCamera), "Colored Ball");
            }
            else if (Input.GetMouseButtonDown(1))
            {
                RemoveAllRedBalls();
            }
        }

        private void RemoveAllRedBalls()
        {
            var arrayList = _balls.ToArray();
            for (var i = 0; i < arrayList.Length; i++)
            {
                if (arrayList[i].Color == Color.red)
                {
                    _pooler.BallPool.Release(arrayList[i].gameObject);
                    _balls.Remove(arrayList[i]);
                }
            }
        }

        private void SpawnBallAtMouseAndGiveName(Vector3 mousePosition, string newName)
        {
            InstantiateBall(mousePosition,newName);
            EventManager.PlaynSpawnSound?.Invoke();
        }

        private void InstantiateBall(Vector3 position,string newName)
        {
            var ballGameObject = _pooler.BallPool.Get();
            ballGameObject.transform.position = position;
            ballGameObject.transform.SetParent(coloredBallsParent);
            
            if (ballGameObject.TryGetComponent<Ball>(out var ball))
            {
                ball.SetName(newName);
                _balls.Add(ball);
            }
            else
            {
                Debug.LogError("Object doesn't contain Ball component!");
            }
        }
    }
}