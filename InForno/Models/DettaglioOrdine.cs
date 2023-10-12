namespace InForno.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DettaglioOrdine")]
    public partial class DettaglioOrdine
    {
        [Key]
        public int IdDettaglioOrdine { get; set; }

        public int Quantita { get; set; }

        public int? IdAggiunzione { get; set; }

        public int IdProdotto { get; set; }

        public int IdOrdine { get; set; }

        public virtual Aggiunzione Aggiunzione { get; set; }

        public virtual Ordine Ordine { get; set; }

        public virtual Prodotto Prodotto { get; set; }

        public DettaglioOrdine() { }
        public DettaglioOrdine(int quantita, int? idAggiunzione, int idProdotto, int idOrdine)
        {
            Quantita = quantita;
            IdAggiunzione = idAggiunzione;
            IdProdotto = idProdotto;
            IdOrdine = idOrdine;
        }
    }
}
