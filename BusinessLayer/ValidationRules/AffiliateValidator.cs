using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AffiliateValidator : AbstractValidator<Affiliate>
    {
        public AffiliateValidator()
        {
            RuleFor(x => x.AccountName).NotEmpty().WithMessage("Hesap İsmi boş bırakılamaz!");
            RuleFor(x => x.Contact).NotEmpty().WithMessage("İletişim adresi boş bırakılamaz");
            RuleFor(x => x.CryptoWallet).NotEmpty().WithMessage("Cüzdan boş bırakılamaz!");
            RuleFor(x => x.CryptoWallet).MaximumLength(34).WithMessage("TRC20 cüzdan 34 karakterden fazla olamaz!");
            RuleFor(x => x.CryptoWallet).MinimumLength(34).WithMessage("TRC20 cüzdan 34 karakterden az olamaz!");
            RuleFor(x => x.SocialMediaID).NotEmpty().WithMessage("Sosyal Medya boş bırakılamaz!");
            RuleFor(x => x.PartnerID).NotEmpty().WithMessage("Affiliate ID boş bırakılamaz!");
            RuleFor(x => x.DailyPostNumber).NotEmpty().WithMessage("Paylaşım sıklığı boş bırakılamaz!");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("Bitiş tarihi boş bırakılamaz");
        }
    }
}
