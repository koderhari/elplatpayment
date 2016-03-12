using ElPlat_PaymentsPlugin.DataLayer.Entities;
using ElPlat_PaymentsPlugin.Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElPlat_PaymentsPlugin.Forms.Infrastructure
{
    public static class MappingExtension
    {
        public static PaymentCounterViewModel ToViewModel(this PaymentCounter model)
        {
            var viewModel = new PaymentCounterViewModel();
            viewModel.CounterId = model.CounterId;
            viewModel.IsRequired = model.IsRequired;
            viewModel.Name = model.Name;
            viewModel.NewValue = model.NewValue;
            viewModel.OldValue = model.OldValue;
            viewModel.Order = model.Order;
            viewModel.PaymentId = model.PaymentId;
            return viewModel;
        }

        public static PaymentCounter ToModel(this PaymentCounterViewModel viewModel)
        {
            var model = new PaymentCounter();
            model.CounterId = viewModel.CounterId;
            model.IsRequired = viewModel.IsRequired;
            model.Name = viewModel.Name;
            model.NewValue = viewModel.NewValue;
            model.OldValue = viewModel.OldValue;
            model.Order = viewModel.Order;
            model.PaymentId = viewModel.PaymentId;
            return model;
        }


        public static PaymentViewModel ToViewModel(this Payment model)
        {
            var viewModel = new PaymentViewModel();
            viewModel.Amount = model.Amount;
            viewModel.AmountComission = model.AmountComission;
            viewModel.ClientAddress = model.ClientAddress;
            viewModel.ClientFullName = model.ClientFullName;
            viewModel.Description = model.Description;
            viewModel.Id = model.Id;
            viewModel.IsConfirmed = model.IsConfirmed;
            viewModel.PaymentTypeId = model.PaymentTypeId;
            viewModel.PersonalNumber = model.PersonalNumber;
            viewModel.VendorId = model.VendorId;
            viewModel.VendorServiceId = model.VendorServiceId;
            viewModel.TransactionId = model.TransactionId;
            foreach(var counter in model.ListPaymentCounters)
                viewModel.ListPaymentCounters.Add(counter.ToViewModel());
            return viewModel;
        }

        public static Payment ToModel(this PaymentViewModel viewModel)
        {
            var model = new Payment();
            model.Amount = viewModel.Amount;
            model.AmountComission = viewModel.AmountComission;
            model.ClientAddress = viewModel.ClientAddress;
            model.ClientFullName = viewModel.ClientFullName;
            model.Description = viewModel.Description;
            model.Id = viewModel.Id;
            model.IsConfirmed = viewModel.IsConfirmed;
            model.PaymentTypeId = viewModel.PaymentTypeId;
            model.PersonalNumber = viewModel.PersonalNumber;
            model.VendorId = viewModel.VendorId;
            model.VendorServiceId = viewModel.VendorServiceId;
            model.TransactionId = viewModel.TransactionId;
            foreach (var counter in viewModel.ListPaymentCounters)
                model.ListPaymentCounters.Add(counter.ToModel());
            return model;
        }

    }
}
