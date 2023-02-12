using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class FormValidator : AbstractValidator<Form>
    {
        public FormValidator()
        {
            RuleFor(x => x.AffMail).NotEmpty().WithMessage("Mail boş bırakılamaz!");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ücret boş bırakılamaz!");
            RuleFor(x => x.Contact).NotEmpty().WithMessage("İletişim adresi boş bırakılamaz");
        }
    }
}
