using SarrrGames.GoldenRush.Core.ObservableProperty;

namespace SarrrGames.GoldenRush.Gameplay.Entities.Token
{
    public class TokenProgressModel 
    {
        public ObservableProperty<int> Soft { get; } = new ObservableProperty<int>(0);
        public ObservableProperty<int> HpCost { get; } = new ObservableProperty<int> (3);
        public ObservableProperty<int> AsCost { get; } = new ObservableProperty<int> (3);
        public ObservableProperty<int> AttackCost { get; } = new ObservableProperty<int> (3);
    }
}
