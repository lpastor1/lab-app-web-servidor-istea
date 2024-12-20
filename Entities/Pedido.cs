﻿using System.ComponentModel.DataAnnotations.Schema;

namespace lab_app_web_servidor_istea.Entities;

public class Pedido : EntityWithId
{
  [ForeignKey(nameof(Comanda))] public int ComandaId { get; set; }

  [ForeignKey(nameof(Producto))] public int ProductoId { get; set; }

  [ForeignKey(nameof(EstadosPedido))] public int EstadosPedidoId { get; set; }
  public int Cantidad { get; set; }
  public DateTime FechaCreacion { get; set; }
  public DateTime? FechaFinalizacion { get; set; }

  public virtual Producto Producto { get; set; } = null!;
  public virtual Comanda Comanda { get; set; } = null!;
  public virtual EstadosPedido EstadosPedido { get; set; } = null!;
}