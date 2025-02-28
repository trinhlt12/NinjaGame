namespace _Game.Scripts.StateMachine
{
    public interface IState
    {
        void OnEnter(Enemy enemy);
        
        void OnExecute(Enemy enemy);
        
        void OnExit(Enemy enemy);
    }
}