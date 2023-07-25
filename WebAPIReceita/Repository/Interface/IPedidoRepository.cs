using WebAPIReceita.Models;

namespace WebAPIReceita.Repository.Interface
{
    public interface IPedidoRepository
    {
        Pedido CriarPedido(Pedido pedido);
        Pedido ConsultarPedido(int id);
        void AtualizarPedido(Pedido pedido);
        void ExcluirPedido(Pedido pedido);
        IEnumerable<Pedido> ListarPedidos();
    }
}
