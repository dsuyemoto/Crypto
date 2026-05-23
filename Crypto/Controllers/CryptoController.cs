using Microsoft.AspNetCore.Mvc;
using Crypto.Models;
using CryptoConverterNET;

namespace Crypto.Controllers
{
    public class CryptoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserSubmission()
        {
            return View();
        }

        public IActionResult Decrypt(CryptoInput cryptoInput)
        {
            var converter = new CryptoService(
                CryptoService.CryptoType.Vignere,
                cryptoInput.Key,
                cryptoInput.Alphabet);
            var cryptoOutput = new CryptoOutput();
            cryptoOutput.Result = converter.Decrypt(cryptoInput.Data);

            return View(cryptoOutput);
        }
    }
}