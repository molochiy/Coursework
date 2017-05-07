using System.Web.Mvc;
using Coursework.Entities;
using Coursework.Repositories.Abstract;

namespace Coursework.Web.Controllers
{
  public class HomeController : Controller
  {
    private readonly IRepository _repository;

    public HomeController(IRepository repository)
    {
      _repository = repository;
    }

    // GET: Home
    public ActionResult Index()
    {
      var states = _repository.Get<State>();
      ViewBag.States = states;
      var roles = _repository.Get<Role>();
      ViewBag.Roles = roles;

      return View();
    }
  }
}