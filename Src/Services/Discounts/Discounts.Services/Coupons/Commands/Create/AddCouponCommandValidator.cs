using System;
using Discounts.Domain.Coupons.Dtos;
using FluentValidation;

namespace Discounts.Services.Coupons.Commands.Create
{
    public class AddCouponCommandValidator: AbstractValidator<AddCouponInfo>
    {
        public AddCouponCommandValidator()
        {
            RuleFor(c => c.ProductTitle).NotEmpty().WithMessage(" نمی تواند خالی باشد.{PropertyName}")
                .NotNull().WithMessage(" نمی تواند خالی باشد.{PropertyName}")
                .MaximumLength(300).WithMessage(" حداکثر 300 کاراکتر می باشد. {PropertyName}")
                .WithName("عنوان محصول");

            RuleFor(c=>c.ProductId).NotNull().WithMessage(" نمی تواند خالی باشد.{PropertyName}")
                .NotEmpty().WithMessage(" نمی تواند خالی باشد.{PropertyName}")
                .WithName("کد محصول");

            RuleFor(c => c.Value).GreaterThan(0).WithMessage("{PropertyName} نمی تواند منفی باشد.")
                .NotEqual(0).WithMessage("{PropertyName} نمی تواند صغر باشد.")
                .WithName("تخفیف");



        }
    }
}
