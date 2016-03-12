using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElPlat_PaymentsPlugin.DataLayer.Entities
{
    /// <summary>
    /// Сущность "Тип платежа"
    /// </summary>
    [Table("PaymentTypes")]
    public class PaymentType
    {
        public PaymentType()
        {
            Vendors = new HashSet<Vendor>();
            Payments = new HashSet<PaymentOld>();
        }

        #region Поля сущности

        /// <summary>
        /// ID типа платежа
        /// </summary>
        [Key]
        public string PaymentTypeId { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        #endregion

        #region Навигационные свойства

        /// <summary>
        /// Поставщики
        /// </summary>
        public virtual HashSet<Vendor> Vendors { get; private set; }

        /// <summary>
        /// Платежи
        /// </summary>
        public virtual HashSet<PaymentOld> Payments { get; private set; }

        #endregion
    }
}
