using SarrrGames.GoldenRush.Gameplay.Entities.Token;
using SarrrGames.GoldenRush.Gameplay.ObjectsPool;
using UnityEngine;
using Zenject;

namespace SarrrGames.GoldenRush.Gameplay.Entities.Grows
{
    public class BlocksPool : MonoBehaviour
    {
        [SerializeField] private int _poolCount = 3;
        [SerializeField] private bool _autoExpand = true;
        [SerializeField] private BlockOfGrow _block;
        [SerializeField] private Transform _tokenSpawner;
        
        private Pool _pool;

        [Inject]
        public void Construct(Pool pool)
        {
            _pool = pool;
            CreatePool();
        }
        
        private void CreatePool()
        {
            _pool.CreatePool<BlockOfGrow>(_block.gameObject,_poolCount,transform);
        }
    
        public void CreateBlock(Transform blockPoint)
        {
            var token = _pool.GetFreeElement<BlockOfGrow>();
            var o = token.gameObject;
            o.transform.position = blockPoint.position;
            o.transform.rotation = blockPoint.rotation;
        }
    }
}
