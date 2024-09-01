
namespace Adopet.Console.Commands
{
    internal interface IComando
    {
        Task ExecutarAsync(string[] args);
    }
}
