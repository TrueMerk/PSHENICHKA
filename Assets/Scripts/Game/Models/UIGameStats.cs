using SarrrGames.GoldenRush.Core.ObservableProperty;
using SarrrGames.GoldenRush.Gameplay.Entities;
using SarrrGames.GoldenRush.Gameplay.Entities.Player;
using SarrrGames.GoldenRush.Gameplay.Entities.Token;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace SarrrGames.GoldenRush.Game.Models
{
    public class UIGameStats : MonoBehaviour
    {

        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private TMP_Text _attackText;
        [SerializeField] private TMP_Text _attackSpeedText;
        [SerializeField] private TMP_Text _softText;
        
        private PlayerProgressModel _player;
        private TokenProgressModel _token;

        [Inject]
         public void Construct(PlayerProgressModel player,TokenProgressModel token)
         {
             _player = player;
             player.Attack.AttachToText(_attackText);
             player.Health.AttachToText(_healthText);
             player.AttackSpeed.AttachToText(_attackSpeedText);

             _token = token;
             _token.Soft.AttachToText(_softText);
         }
         
        public void UpHealth(int health)
        {
            if (_token.Soft.GetValue()>=_token.HpCost.GetValue())
            {
                _player.Health.SetValue(health + _player.Health.GetValue());
                _token.Soft.SetValue(_token.Soft.GetValue()-_token.HpCost.GetValue());
            }
        }

        public void UpAttack(int attack)
        {
            if (_token.Soft.GetValue()>=_token.AttackCost.GetValue())
            {
                _player.Attack.SetValue(attack + _player.Attack.GetValue());
                _token.Soft.SetValue(_token.Soft.GetValue()-_token.AttackCost.GetValue());
            }
        }
        
        public void UpAttackSpeed(int attackSpeed)
        {
            if (_player.AttackSpeed.GetValue()>=0)
            {
                if (_token.Soft.GetValue()>=_token.AsCost.GetValue())
                {
                    _player.AttackSpeed.SetValue(attackSpeed + _player.AttackSpeed.GetValue());
                    _token.Soft.SetValue(_token.Soft.GetValue()-_token.AsCost.GetValue());
                }
            }
            
        }
    }
}
