using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Mzl.EntityModel.Flight
{
    [Table("Flt_PeerTripartiteArrangementPassenger")]
    public class FltWhiteListPassengerEntity
    {
        [Key]
        public string PassengerName { get; set; }

        public string CardNo { get; set; }
        public string AgreementNo { get; set; }
    }
}
