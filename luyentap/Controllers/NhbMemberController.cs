using luyentap.Models;
using Microsoft.AspNetCore.Mvc;

namespace luyentap.Controllers
{
    public class NhbMemberController : Controller
    {
        //mock data
        private static readonly List<NhbMember> _NhbMembers = new List<NhbMember>()
        {
            new NhbMember
                {
                    NhbMemberId = Guid.NewGuid().ToString(),
                    NhbMemberUserName = "nguyenvana",
                    NhbMemberPassword = "123",
                    NhbMemberEmail = "nguyenvana@gmail.com",
                    NhbMemberFullName = "Nguyen Van A"
                },
                new NhbMember
                {
                    NhbMemberId = Guid.NewGuid().ToString(),
                    NhbMemberUserName = "tranthib",
                    NhbMemberPassword = "123",
                    NhbMemberEmail = "tranthib@gmail.com",
                    NhbMemberFullName = "Tran Thi B"
                },
                new NhbMember
                {
                    NhbMemberId = Guid.NewGuid().ToString(),
                    NhbMemberUserName = "levanc",
                    NhbMemberPassword = "123",
                    NhbMemberEmail = "levanc@gmail.com",
                    NhbMemberFullName = "Le Van C"
                }
        };
        public IActionResult Index()
        {
            return View(_NhbMembers);
        }

        public IActionResult Create()
        {
            return View();
        }

        //submit
        [HttpPost]
        public IActionResult Create(NhbMember nhbMember)
        {
            nhbMember.NhbMemberId = Guid.NewGuid().ToString();
            _NhbMembers.Add(nhbMember);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(string id)
        {
            var member1 = _NhbMembers.FirstOrDefault(x => x.NhbMemberId.Equals(id));
            return View(member1);
        }
        [HttpPost]
        public IActionResult Edit(string id,NhbMember nhbMember)
        {
            for (int i = 0; i < _NhbMembers.Count(); i++)
            {
                if (_NhbMembers[i].NhbMemberId == id)
                {
                    _NhbMembers[i].NhbMemberId = nhbMember.NhbMemberId;
                    _NhbMembers[i].NhbMemberUserName = nhbMember.NhbMemberUserName; 
                    _NhbMembers[i].NhbMemberPassword = nhbMember.NhbMemberPassword;
                    _NhbMembers[i].NhbMemberEmail = nhbMember.NhbMemberEmail;
                    _NhbMembers[i].NhbMemberFullName = nhbMember.NhbMemberFullName;
                    break;
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult NhbGetDetail()
        {
            var nhbMember = new NhbMember()
            {
                NhbMemberId = Guid.NewGuid().ToString(),
                NhbMemberUserName="Hoai Bao",
                NhbMemberPassword="Bao123@",
                NhbMemberEmail="Bao123@gmail.com",
                NhbMemberFullName="Nguyen Hoai Bao"
            };

            return View(nhbMember);
        }

    }
}
