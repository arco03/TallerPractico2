namespace _scripts.NPCs
{
    public interface INpcState
    {
        void EnterState();
        void UpdateState();
        void ExitState();
    }
}