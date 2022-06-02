using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.SpawnPos
{
    [CreateAssetMenu(menuName ="Game/Manager/GameSpawn", fileName ="SpawnManager")]
    public class GamePositionSpawnManager : ScriptableObject
    {
        [SerializeField, NaughtyAttributes.ReadOnly]
        private SpawnPos _currentPos;


        [Space, SerializeField]
        private List<SpawnPos> positions;


        private void Awake()
        {
            Reset();
        }

        [NaughtyAttributes.Button]
        public void Reset()
        {
            if (positions.Count <= 0) return;
            _currentPos = positions[0];
        }
        public Vector3 GetSpawnPos()
        {
            Vector3 pos = _currentPos.Pos;
            Reset();
            return pos;
        }
        public Vector3 GetSpawnPos(int index)
        {
            Vector3 pos = positions[index].Pos;
            Reset();
            return pos;
        }
        public void SetNewSpawn(string name)
        {
            if(positions.Exists(p => p.name.Equals(name)))
                _currentPos = positions.Find(p => p.name.Equals(name));
            else
                Reset();
        }
    }
}