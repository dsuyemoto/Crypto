using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Crypto.Models;

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
            var converter = new CryptoConverter.Converter(
                CryptoConverter.Converter.ConverterType.Vignere,
                cryptoInput.Key,
                cryptoInput.Alphabet);
            var cryptoOutput = new CryptoOutput();
            cryptoOutput.Result = converter.Decrypt(cryptoInput.Data);

            return View(cryptoOutput);
        }
    }
}