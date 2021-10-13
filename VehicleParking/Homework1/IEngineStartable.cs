namespace Homework1
{
    public interface IEngineStartable
    {
        bool IsEngineStarted { get; set; }
        void StartEngine();
        void StopEngine();
        int Kilometrage();
    }
}
