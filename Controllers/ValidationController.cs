using System;
using System.Globalization;
using System.Web.Mvc;
using System.Web.UI;
using AddressBook.Models;

namespace AddressBook.Controllers {
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ValidationController : Controller {
        private const object OutputCacheLocation;
        IUserDB _repository;
#if  InMemDB
          public ValidationController() : this(InMemoryDB.Instance) { }
#else
        public ValidationController() : this(new EF_UserRepository()) { }
#endif


        public ValidationController(IUserDB repository) {
            _repository = repository;
        }

        public JsonResult IsUID_Available(string Username) {

            if (!_repository.UserExists(Username))
                return Json(true, JsonRequestBehavior.AllowGet);

            string suggestedUID = String.Format(CultureInfo.InvariantCulture,
                "{0} is not available.", Username);

            for (int i = 1; i < 100; i++) {
                string altCandidate = Username + i.ToString();
                if (!_repository.UserExists(altCandidate)) {
                    suggestedUID = String.Format(CultureInfo.InvariantCulture,
                   "{0} is not available. Try {1}.", Username, altCandidate);
                    break;
                }
            }
            return Json(suggestedUID, JsonRequestBehavior.AllowGet);
        }

    }
}