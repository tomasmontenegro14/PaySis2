//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationPaySis.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TRANSACTIONSEntities
    {
        public int ID_TRANSACTION { get; set; }
        public Nullable<int> STEP_TRANSACTION { get; set; }
        public string TYPE_TRANSACTION { get; set; }
        public Nullable<decimal> AMOUNT_TRANSACTION { get; set; }
        public string NAMEORIG_TRANSACTION { get; set; }
        public Nullable<decimal> OLDBALANCEORG_TRANSACTION { get; set; }
        public Nullable<decimal> NEWBALANCEORIG_TRANSACTION { get; set; }
        public string NAMEDEST_TRANSACTION { get; set; }
        public Nullable<decimal> OLDBALANCEDEST_TRANSACTION { get; set; }
        public Nullable<decimal> NEWBALANCEDEST_TRANSACTION { get; set; }
        public Nullable<int> ISFRAUD_TRANSACTION { get; set; }
        public Nullable<int> ISFLAGGEDFRAUD_TRANSACTION { get; set; }
    }
}
