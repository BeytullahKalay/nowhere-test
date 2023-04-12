using Assets.Scripts.MyScripts;
using UnityEngine;
using UnityEngine.Pool;

public class Pooler : MonoSingleton<Pooler>
{
    [SerializeField] private GameObject _ballPrefab;
    public ObjectPool<GameObject> BallPool { get; private set; }


    private void Awake()
    {
        BallPool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(_ballPrefab);
        }, ball =>
        {
            ball.gameObject.SetActive(true);
        }, ball =>
        {
            ball.gameObject.SetActive(false);
        }, ball =>
        {
            Destroy(ball.gameObject);
        }, false, 100,250);
    }
}
