using Assets.Scripts.MyScripts;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private SpawnTypes spawnTypes;
        public SpawnTypes SpawnTypes => spawnTypes;
    }
}