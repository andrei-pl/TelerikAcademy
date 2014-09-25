namespace Computers.UI.Console
{
    public interface IComputer
    {
        void Play(int guessNumber);

        void ChargeBattery(int percentage);

        void Proccess(int data);
    }
}
