using BusinesLogic.ViewModel.Settings;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace NetflixMVC.VIewComponents
{
    [ViewComponent(Name = "ContactUsViewComponent")]
    public class ContactUsViewComponent : ViewComponent
    {
        ISettingsService<SettingVM> _db;

        public ContactUsViewComponent(ISettingsService<SettingVM> db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Views/Home/Components/ContactUsViewComponent/ContactUs.cshtml
            return View("ContactUs", _db.GetWithId());
        }
    }
}
