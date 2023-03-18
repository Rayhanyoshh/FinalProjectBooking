using HotelRealtaPayment.Domain.Entities;

namespace HotelRealtaPayment.Domain.Dto;

public class AccountUser : Account
{
    public string? PaymentName { get; set; }
}