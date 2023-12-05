using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class EmployeeValidator:AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.EmployeeName).NotEmpty().WithMessage("Personel Adı boş geçilemez");
            RuleFor(x => x.EmployeeEmail).NotEmpty().WithMessage("Email boş geçilemez");

            //Telefon numarası
            RuleFor(x => x.EmployeePhoneNumber).NotEmpty().Must(x => !string.IsNullOrEmpty(x) && x.StartsWith("5")).WithMessage("Telefon numarası 5 ile başlamalı");

            RuleFor(x => x.EmployeeEmail).NotEmpty().NotNull().WithMessage("Telefon bilgisi Boş geçilemez")
      .MinimumLength(10).WithMessage("En az 10 karakter olmalı")
      .MaximumLength(20).WithMessage("En fazla 10 karakter olmalı")
      .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("Geçerli telefon no giriniz");


            //Email
            //RuleFor(x =>x.EmployeeEmail).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().Matches("@").WithMessage("@ içermelidir");

            RuleFor(x => x.EmployeeEmail).EmailAddress().WithMessage("Mail adresini doğru formatta giriniz @ içermelidir.");

        }
    }
}
