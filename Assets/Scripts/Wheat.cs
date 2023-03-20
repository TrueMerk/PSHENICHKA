using System;
using System.Collections;
using SarrrGames.GoldenRush.Gameplay.Entities.Grows;
using UnityEngine;

namespace SarrrGames.GoldenRush
{
  public class Wheat : MonoBehaviour
  {

    [SerializeField] private int _health = 2;
    [SerializeField] private Grower _grower;
    [SerializeField] private Collider _collider;
    [SerializeField] private BlocksPool _block;
    
    public Action ZeroHealth;

    private void Start()
    {
      _grower.Growed += EnableHealth;
    }

    private void Update()
    {
      if (_health < 1)
        ZeroHealthMethod();
    }

    private void EnableHealth()
    {
      _collider.enabled = true;
    }

    private void ZeroHealthMethod()
    {
      _collider.enabled = false;
      ZeroHealth?.Invoke();
      _health = 2;
      _block.CreateBlock(transform);
    }

    public void HasBeenCut()
    {
      
      _health--;
    }

  }
}
