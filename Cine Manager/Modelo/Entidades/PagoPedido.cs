using Modelo.Entidades;

public class PagoPedido
{
    private int pagoPedidoId;
    private Pedido pedido;
    private DateTime fechaPago;
    private string codigo;
    private MetodoPago metodoPago;

    public int PagoPedidoId
    {
        get { return pagoPedidoId; }
        set { pagoPedidoId = value; }
    }

    public Pedido Pedido
    {
        get { return pedido; }
        set { pedido = value; }
    }

    public DateTime FechaPago
    {
        get { return fechaPago; }
        set { fechaPago = value; }
    }

    public string Codigo
    {
        get { return codigo; }
        set { codigo = value; }
    }

    public MetodoPago MetodoPago
    {
        get { return metodoPago; }
        set { metodoPago = value; }
    }

    // Agregamos la propiedad MetodoPagoId para la clave foránea
    public int MetodoPagoId { get; set; }
}