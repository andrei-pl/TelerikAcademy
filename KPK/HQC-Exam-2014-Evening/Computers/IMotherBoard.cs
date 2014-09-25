namespace Computers.UI.Console
{
    /// <summary>
    /// Implements motherboard functions which the proccessor can use
    /// </summary>
    public interface IMotherboard
    {
        int LoadRamValue();

        void SaveRamValue(int value);

        void DrawOnVideoCard(string data);
    }
}
