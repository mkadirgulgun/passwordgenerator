using Microsoft.AspNetCore.Mvc;
using PasswordGenerator.Models;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace PasswordGenerator.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [Route("/PasswordGenerator")]
        public IActionResult PasswordGenerator()
        {
            return View();
        }

        [HttpPost]
        [Route("/NewsLetter")]
        public IActionResult NewsLetter(Form model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Eksik veya hatalý form.");
            }
            var body = @"
<h1>Qwerty'e Hoþ Geldiniz!</h1>
<p>Deðerli Üyemiz,</p>

<p>Qwerty, güçlü ve güvenli þifreler oluþturmanýza yardýmcý olmak için tasarlandý. Artýk çevrimiçi hesaplarýnýz için güvenlik endiþelerini geride býrakabilirsiniz. Bizimle birlikte olduðunuz için teþekkür ederiz!</p>

<h2>Öne Çýkan Özelliklerimiz:</h2>
<ul>
    <li><strong>Güçlü Þifre Üretimi:</strong> Karmaþýk ve tahmin edilmesi zor þifreler oluþturun.</li>
    <li><strong>Kullanýcý Dostu Arayüz:</strong> Hýzlý ve kolay kullaným için optimize edildi.</li>
    <li><strong>Güvenlik Önlemleri:</strong> Verilerinizi korumak için en yüksek güvenlik standartlarýný kullanýyoruz.</li>
</ul>

<p>Hemen baþlayýn ve Securium ile çevrimiçi güvenliðinizi artýrýn!</p>

<p>Herhangi bir sorunuz veya geri bildiriminiz varsa, lütfen bizimle iletiþime geçmekten çekinmeyin.</p>

<p>Güvenli günler dileriz!</p>
<p><strong>Qwerty Ekibi</strong></p>
";
            

            var mailMessage = new MailMessage
            {
                From = new MailAddress("postmaster@info.mkadirgulgun.com.tr"),
                Subject = "NewsLetter'a abone oldunuz!",
                Body = body,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(new MailAddress(model.Email));

            client.Send(mailMessage);
            return View("Index");
        }
    }
}
