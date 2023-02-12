using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı boş geçilemez.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş geçilemez.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Ünvan boş geçilemez.");
        }
    }
}
