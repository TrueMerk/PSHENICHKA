using System.Threading.Tasks;

namespace SarrrGames.GoldenRush.Core.StateMachine
{
    public interface IState
    {
        Task OnEnter();
        Task OnExit();
    }
}