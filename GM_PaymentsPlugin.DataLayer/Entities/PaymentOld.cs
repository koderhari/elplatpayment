using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElPlat_PaymentsPlugin.DataLayer.Entities
{
    /// <summary>
    /// Сущность "Платеж"
    /// </summary>
    //[Table("Payments")]
    public class PaymentOld
    {


        public PaymentOld()
        {
            ListPaymentCounters = new List<PaymentCounter>();
        }
        #region Поля сущности

        /// <summary>
        /// Уникальный код платежа
        /// </summary>
        [Key, Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 PaymentId { get; set; }
        
        /// <summary>
        /// ИНН
        /// </summary>
        [Key, Column(Order = 0)]
        public string INN { get; set; }
        
        /// <summary>
        /// КПП
        /// </summary>
        [Key, Column(Order = 1)]
        public string KPP { get; set; }

        /// <summary>
        /// Описание платежа
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Сумма платежа
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Сумма комиссии
        /// </summary>
        public decimal AmountComission { get; set; }

        /// <summary>
        /// Номер лицевого счета
        /// </summary>
        public string PersonalNumber { get; set; }

        /// <summary>
        /// ФИО клиента
        /// </summary>
        public string ClientFullName { get; set; }

        /// <summary>
        /// Адрес клиента
        /// </summary>
        public string ClientAddress { get; set; }

        /// <summary>
        /// Тип платежа
        /// </summary>
        public string PaymentTypeId { get; set; }

        /// <summary>
        /// Признак подтвержденности платежа
        /// </summary>
        public bool IsConfirmed { get; set; }

        #endregion

        #region Навигационные свойства

        /// <summary>
        /// Тип платежа
        /// </summary>
        public virtual PaymentType PaymentType { get; set; }

        /// <summary>
        /// Поставщик
        /// </summary>
        public virtual Vendor Vendor { get; set; }

        #endregion


        public List<PaymentCounter> ListPaymentCounters {get;set;}
    }
}
