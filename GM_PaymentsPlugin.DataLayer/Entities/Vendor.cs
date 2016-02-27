using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GM_PaymentsPlugin.DataLayer.Entities
{
    /// <summary>
    /// Сущность "Поставщик"
    /// </summary>
    //[Table("Vendors")]
    public class Vendor
    {
        public Vendor()
        {
            Payments = new HashSet<PaymentOld>();    
        }

        #region Поля сущности

        /// <summary>
        /// Уникальный код поставщика
        /// </summary>
        public string VendorId { get; set; }


        public string Number { get; set; }
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
        /// Тип платежа
        /// </summary>
        public string PaymentTypeId { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Юридический адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }

        #endregion

        #region Навигационные свойства

        /// <summary>
        /// Тип платежа
        /// </summary>
        public virtual PaymentType PaymentType { get; set; }

        /// <summary>
        /// Платежи
        /// </summary>
        public virtual HashSet<PaymentOld> Payments { get; private set; }

        #endregion
    }
}
