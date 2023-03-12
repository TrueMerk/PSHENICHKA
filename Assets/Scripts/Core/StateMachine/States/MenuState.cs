using System.Threading.Tasks;

namespace SarrrGames.GoldenRush.Core.StateMachine.States
{
    public class MenuState : BaseState
    {
        public MenuState(IStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override Task OnEnter()
        {
            return Task.CompletedTask;
        }

        public override Task OnExit()
        {
            return Task.CompletedTask;
        }
    }
}