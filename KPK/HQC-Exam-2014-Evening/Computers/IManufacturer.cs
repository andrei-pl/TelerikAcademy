namespace Computers.UI.Console
{
    public interface IManufacturer
    {
        IComputer MakeComputer();
        
        IComputer MakeServer();
        
        IComputer MakeLaptop();
    }
}
