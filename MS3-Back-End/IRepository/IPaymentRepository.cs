﻿using MS3_Back_End.DTOs.ResponseDTOs.Payment;
using MS3_Back_End.Entities;

namespace MS3_Back_End.IRepository
{
    public interface IPaymentRepository
    {
        Task<Payment> CreatePayment(Payment payment);
        Task<Payment> UpdatePayment(Payment payment);
        Task<ICollection<Payment>> GetAllPayments();
        Task<ICollection<Payment>> RecentPayments();
        Task<PaymentOverview> GetPaymentOverview();
        Task<ICollection<PaymentFullDetails>> GetPaginatedPayments(int pageNumber, int pageSize);
        Task<Payment> GetLastPaymentOfEnrollment(Guid EnrollId);
    }
}
