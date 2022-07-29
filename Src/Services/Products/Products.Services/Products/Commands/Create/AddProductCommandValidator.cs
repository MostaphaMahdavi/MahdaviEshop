using System;
using FluentValidation;

namespace Products.Services.Products.Commands.Create
{
    public class AddProductCommandValidator:AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(c=>c.Titile).NotEmpty()
                .WithMessage("{PropertyName} نمی تواند خالی باشد.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد.")
                .MaximumLength(250).WithMessage("{PropertyName} حداکثر ۲۵۰ کاراکتر می باشد.")
                .WithName("عنوان");


            RuleFor(c => c.Description).NotEmpty()
              .WithMessage("{PropertyName} نمی تواند خالی باشد.")
              .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد.")
              .MaximumLength(5000).WithMessage("{PropertyName} حداکثر ۵۰۰۰ کاراکتر می باشد.")
              .WithName("توضیحات");

            RuleFor(c => c.PermaLink).NotEmpty()
              .WithMessage("{PropertyName} نمی تواند خالی باشد.")
              .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد.")
              .MaximumLength(200).WithMessage("{PropertyName} حداکثر ۲۰۰ کاراکتر می باشد.")
              .WithName("لینک");



            RuleFor(c => c.CoverImageUrl).NotEmpty()
              .WithMessage("{PropertyName} نمی تواند خالی باشد.")
              .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد.")
              .MaximumLength(250).WithMessage("{PropertyName} حداکثر ۲۵۰ کاراکتر می باشد.")
              .WithName("کاور عکس");


            RuleFor(c => c.Code).NotEmpty()
              .WithMessage("{PropertyName} نمی تواند خالی باشد.")
              .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد.")
              .MaximumLength(50).WithMessage("{PropertyName} حداکثر ۵۰ کاراکتر می باشد.")
              .Must(ValidateCode).WithMessage("{PropertyName} نا معتبر است.")
              .WithName("کد");


            RuleFor(c => c.Price)
                .NotEqual(0).WithMessage("{PropertyName}  نمی تواند صفر باشد")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName}  نمی تواند  منفی باشد")
              .WithName("مبلغ");            

        }

        private bool ValidateCode(string value) {

            if (string.IsNullOrWhiteSpace(value))   return false;

            if (value.StartsWith("Mm"))  return false;

            if (value.Length > 50) return false;

            return true;

        }

    }
}
