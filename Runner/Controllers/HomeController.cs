using Runner.BLL;
using Runner.Common;
using Runner.DAL;
using Runner.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Runner.Controllers
{
    public class HomeController : Controller
    {
        private readonly IComandExecute _cmdCommandExecute;
        private readonly IFileWorker _fileWorker;
        private readonly IConfigManager _configManager;

        public HomeController(IComandExecute command, IFileWorker fileWorker, IConfigManager configManager)
        {
            this._cmdCommandExecute = command;
            this._fileWorker = fileWorker;
            this._configManager = configManager;
        }

        public ActionResult Index()
        {
            string commandResult = _cmdCommandExecute.ExecuteComand();

            commandResult = commandResult.Replace("<DIR>", "DIR"); // STUB!

            string fileContent = string.Empty;
            try
            {
                fileContent = _fileWorker.GetFileContent(_configManager.File_FullPath);
            }
            catch (Exception)
            {
                //TODO: Add error.
            }

            return View(new HomePage(commandResult, fileContent));
        }

        [HttpPost]
        public ActionResult Index(HomePage homePage)
        {
            try
            {
                _fileWorker.UpdateFileContent(_configManager.File_FullPath, homePage.FileContent);

            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }



    }
}