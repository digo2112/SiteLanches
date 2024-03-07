using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Options;
using SiteLanches.Models;

namespace SiteLanches.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminImagesController : Controller
    {

        private readonly ConfigurationImages _myconfig;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminImagesController(IOptions<ConfigurationImages> myconfig, IWebHostEnvironment webHostEnvironment)
        {
            _myconfig = myconfig.Value;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {

            //aqui nao teria que ter aquele try catch?
            if (files == null || files.Count == 0)
            {
                ViewData["Erro"] = "Error: Arquivo(s) não selecionado(s)";
                return View(ViewData);
            }

            if (files.Count > 10)
            {
                ViewData["Erro"] = "Error: Quantidade de arquivos passou do limite";
                return View(ViewData);
            }

            var filePathName = new List<string>();
            long size = files.Sum(f => f.Length);
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, _myconfig.NomePastaImagensProdutos);

            foreach (var formFile in files)
            {
                if (formFile.FileName.Contains(".jpg") || formFile.FileName.Contains(".gif") ||
                       formFile.FileName.Contains(".png"))
                {
                    var fileNameWithPath = string.Concat(filePath, "\\", formFile.FileName);

                    filePathName.Add(fileNameWithPath);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            //monta a ViewData que será exibida na view como resultado do envio 
            ViewData["Resultado"] = $"{files.Count} arquivos foram enviados ao servidor, " +
             $"com tamanho total de : {size} bytes";

            ViewBag.Arquivos = filePathName;

            //retorna a viewdata
            return View(ViewData);
        }

        public IActionResult GetImages()
        {
            FileManagerModel model = new FileManagerModel();

            var userImagesPath = Path.Combine(_webHostEnvironment.WebRootPath,
                 _myconfig.NomePastaImagensProdutos);

            DirectoryInfo dir = new DirectoryInfo(userImagesPath);
            FileInfo[] files = dir.GetFiles();
            model.PathImagesProduto = _myconfig.NomePastaImagensProdutos;

            if (files.Length == 0)
            {
                ViewData["Erro"] = $"Nenhum arquivo encontrado na pasta {userImagesPath}";
            }

            model.Files = files;
            return View(model);
        }

        public IActionResult DeleteImage(string fname)
        {
            string _imagemDeleta = Path.Combine(_webHostEnvironment.WebRootPath,
                _myconfig.NomePastaImagensProdutos + "\\", fname);

            if ((System.IO.File.Exists(_imagemDeleta)))
            {
                System.IO.File.Delete(_imagemDeleta);
                ViewData["Deletado"] = $"Arquivo(s) {_imagemDeleta} deletado com sucesso";
            }
            return View("index");
        }
    }
}
