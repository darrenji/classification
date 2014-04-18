using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Car.Test.DAL;
using Car.Test.Model;
using Car.Test.Model.Enum;
using Car.Test.Portal.Helpers;
using Car.Test.Portal.Models;
using Car.Test.Portal.Models.QueryParams;

namespace Car.Test.Portal.Controllers
{
    public class HomeController : Controller
    {
        private string txtName = string.Empty;
        private DateTime? startSubTime = null;
        private DateTime? endSubTime = null;

        public ICarCategoryRepository CarCategoryRepository { get; set; }

        public HomeController(ICarCategoryRepository carCategoryRepository)
        {
            this.CarCategoryRepository = carCategoryRepository;
        }

        public HomeController():this(new CarCategoryRepository()){}

        #region 显示分类 
        public ActionResult Index()
        {
            return View();
        }

        //显示所有分类并考虑查询和分页
        public ActionResult GetCarCategoryJson()
        {
            //获取datagrid传来的2个参数
            int pageIndex = int.Parse(Request["page"]);
            int pageSize = int.Parse(Request["rows"]);

            //获取搜索参数
            if (!string.IsNullOrEmpty(Request["txtName"]))
            {
                txtName = Request["txtName"];
            }
            if (!string.IsNullOrEmpty(Request["startSubTime"]))
            {
                startSubTime = DateTime.Parse(Request["startSubTime"]);
            }
            if (!string.IsNullOrEmpty(Request["endSubTime"]))
            {
                endSubTime = DateTime.Parse(Request["endSubTime"]);
            }

            //初始化查询实例
            var temp = new CarCategoryQueryParams
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Name = txtName,
                JoinEndTime = endSubTime,
                JoinStartTime = startSubTime
            };

            //获取所有满足条件的数据，并获得总记录数
            int totalNum = 0;
            var allCarCategory = LoadPageCarCategoryData(temp, out totalNum);

            //投影出需要传递到前台的数据
            var result = from c in allCarCategory
                select new
                {
                    c.ID,
                    c.Name,
                    c.IsLeaf,
                    c.Level,
                    c.ParentID,
                    c.PreLetter,
                    c.Status,
                    c.DelFlag,
                    c.SubTime                  
                };

            //构建datagrid所需要的json格式
            var jsonResult = new { total = totalNum, rows = result };
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        //根据查询条件获得分页数据
        private IEnumerable<CarCategory> LoadPageCarCategoryData(CarCategoryQueryParams param, out int total)
        {
            var allCarCategories =
                CarCategoryRepository.LoadEntities(
                    c => c.Status == (short) StatusEnum.Enable && c.DelFlag == (short) DelFlagEnum.Normal);
            if (!string.IsNullOrEmpty(param.Name))
            {
                allCarCategories = allCarCategories.Where(c => c.Name.Contains(param.Name));
            }
            if (!string.IsNullOrEmpty(param.JoinStartTime.ToString()) &&
               !string.IsNullOrEmpty(param.JoinEndTime.ToString()))
            {
                allCarCategories =
                    allCarCategories.Where(c => c.SubTime >= param.JoinStartTime && c.SubTime <= param.JoinEndTime);
            }

            total = allCarCategories.Count();

            IEnumerable<CarCategory> result = allCarCategories
                .OrderByDescending(c => c.ID)
                .Skip(param.PageSize*(param.PageIndex - 1))
                .Take(param.PageSize);
            return result;
        }
        #endregion

        #region 添加分类

        public ActionResult AddCarCategory()
        {
            //return PartialView(new CarCategoryVm());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCarCategory(CarCategoryVm carCategoryVm)
        {
            if (ModelState.IsValid)
            {
                carCategoryVm.Status = (short)StatusEnum.Enable;
                carCategoryVm.DelFlag = (short)DelFlagEnum.Normal;
                carCategoryVm.SubTime = DateTime.Now;

                CarCategory carCategory = AutoMapper.Mapper.DynamicMap<CarCategoryVm, CarCategory>(carCategoryVm);
                CarCategoryRepository.AddEntity(carCategory);
                CarCategoryRepository.SaveChanges();
                return Json(new {msg = true});
            }
            else
            {
                //return PartialView(carCategoryVm);
                return PartialView("AddModel", carCategoryVm);
            }
        }

        //[ChildActionOnly]
        public ActionResult AddModel()
        {
            return PartialView(new CarCategoryVm());
        }
        #endregion

        #region 编辑分类

        public ActionResult EditCarCategory(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        public ActionResult EditModel(int id)
        {
            var carCategoryDb = CarCategoryRepository.LoadEntities(c => c.ID == id).FirstOrDefault();
            CarCategoryVm carCategoryVm = AutoMapper.Mapper.DynamicMap<CarCategory, CarCategoryVm>(carCategoryDb);
            return PartialView(carCategoryVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCarCategory(CarCategoryVm carCategoryVm)
        {
            if (ModelState.IsValid)
            {
                carCategoryVm.Status = (short)StatusEnum.Enable;
                carCategoryVm.DelFlag = (short)DelFlagEnum.Normal;
                carCategoryVm.SubTime = DateTime.Now;

                CarCategory carCategory = AutoMapper.Mapper.DynamicMap<CarCategoryVm, CarCategory>(carCategoryVm);
                CarCategoryRepository.UpdateEntity(carCategory);
                CarCategoryRepository.SaveChanges();
                return Json(new {msg = true});
            }
            else
            {
                //return PartialView(carCategoryVm);
                return PartialView("EditModel", carCategoryVm);
            }
        }
        #endregion

        #region 批量删除

        [HttpPost]
        public ActionResult DeleteCarCategories()
        {
            var strIds = Request["ids"];
            strIds = strIds.Substring(0, strIds.Length - 1);
            string[] ids = strIds.Split('_');
            List<int> list = new List<int>();
            foreach (var item in ids)
            {
                int id = int.Parse(item);
                list.Add(id);
            }
            if (DeleteCarCategoriesByBatch(list) > 0)
            {
                return Json(new {msg = true});
            }
            else
            {
                return Json(new { msg = "no"});
            }
        }

        private int DeleteCarCategoriesByBatch(List<int> ids)
        {
            var carCategories = CarCategoryRepository.LoadEntities(c => ids.Contains(c.ID)).ToList();
            for (int i = 0; i < carCategories.Count(); i++)
            {
                carCategories[i].DelFlag = (short)DelFlagEnum.Delete;
                carCategories[i].SubTime = DateTime.Now;
            }
            return CarCategoryRepository.SaveChanges();
        }
        #endregion

        #region 显示所有分类的树

        public string LoadAllCategories()
        {
            var temp =
                CarCategoryRepository.LoadEntities(
                    c => c.DelFlag == (short) DelFlagEnum.Normal && c.Status == (short) StatusEnum.Enable);
            var result = from c in temp
                select new {c.ID, c.Name, c.ParentID};
            //return Json(result, JsonRequestBehavior.AllowGet);
            return JsonSerializeHelper.SerializeToJson(result);
        }
        #endregion
    }
}
