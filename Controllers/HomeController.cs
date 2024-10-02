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
                return BadRequest("Eksik veya hatal� form.");
            }
            var body = @"
<h1>Qwerty'e Ho� Geldiniz!</h1>
<p>De�erli �yemiz,</p>

<p>Qwerty, g��l� ve g�venli �ifreler olu�turman�za yard�mc� olmak i�in tasarland�. Art�k �evrimi�i hesaplar�n�z i�in g�venlik endi�elerini geride b�rakabilirsiniz. Bizimle birlikte oldu�unuz i�in te�ekk�r ederiz!</p>

<h2>�ne ��kan �zelliklerimiz:</h2>
<ul>
    <li><strong>G��l� �ifre �retimi:</strong> Karma��k ve tahmin edilmesi zor �ifreler olu�turun.</li>
    <li><strong>Kullan�c� Dostu Aray�z:</strong> H�zl� ve kolay kullan�m i�in optimize edildi.</li>
    <li><strong>G�venlik �nlemleri:</strong> Verilerinizi korumak i�in en y�ksek g�venlik standartlar�n� kullan�yoruz.</li>
</ul>

<p>Hemen ba�lay�n ve Securium ile �evrimi�i g�venli�inizi art�r�n!</p>

<p>Herhangi bir sorunuz veya geri bildiriminiz varsa, l�tfen bizimle ileti�ime ge�mekten �ekinmeyin.</p>

<p>G�venli g�nler dileriz!</p>
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
