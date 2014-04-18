using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Car.Test.Portal.Models;

namespace Car.Test.Portal.Controllers
{
    public class ZTreeController : Controller
    {
        #region 用标准json格式显示树
        public ActionResult Index()
        {
            return View();
        } 
        #endregion

        #region 用简单json格式显示树

        public ActionResult SimpleData()
        {
            return View();
        }
        #endregion

        #region 异步加载数据

        public ActionResult Asyn()
        {
            return View();
        }

        public ActionResult GetAsync()
        {
            List<TreeView> list = new List<TreeView>()
            {
                new TreeView(){id=1,pId = 0,name = "父节点1",click = "",icon = "",iconClose = @"../Content/zTreeStyle/img/diy/1_close.png",iconOpen = @"../Content/zTreeStyle/img/diy/1_open.png",open = true,target = "",url = ""},
                new TreeView(){id = 11, pId = 1, name = "父节点101",click = "",icon = @"../Content/zTreeStyle/img/diy/5.png",iconClose = "",iconOpen = "",open = false,target = "_blank",url = @"http://www.baidu.com"},
                new TreeView(){id = 111,pId = 11,name = "父节点10101",click = @"alert('我是不会跳转的...');return false;",icon = "",iconClose = "",iconOpen = "",open = false,target = "_blank",url = ""},
                new TreeView(){id=112,pId = 11,name = "父节点10102",click = "",icon = "",iconClose = "",iconOpen = "",open = false,target = "",url = ""},
                new TreeView(){id=113,pId = 11, name = "父节点10103",click = "",icon = "",iconClose = "", iconOpen = "",open = false,target = "",url = ""},
                new TreeView(){id=12,pId = 1,name = "父节点2",click = "",icon = "",iconClose = "",iconOpen = "",open = false,target = "",url = ""},
                new TreeView(){id = 121,pId = 12,name = "父节点201",click = "",icon = "",iconClose = "",iconOpen = "",open = false, target = "", url = ""},
                new TreeView(){id = 122, pId = 12,name = "父节点202",click = "",icon = "",iconClose = "",iconOpen = "", open = false,target = "",url = ""}
            };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 使用ZTree的回调方法进行重新加载、追加、悄悄重新加载、悄悄追加
        //悄悄加载：在父节点不打开的情况下，父节点下的所有节点重新加载
        //悄悄追加：在父节点不打开的情况下，为父节点"默默地"增加子节点
        public ActionResult ZTreeFunc()
        {
            return View();
        }
        #endregion

        #region 更新节点

        public ActionResult UpdateNode()
        {
            return View();
        }
        #endregion

        #region 单击节点

        public ActionResult ClickNode()
        {
            return View();
        }
        #endregion

        #region 展开折叠节点

        public ActionResult Expand()
        {
            return View();
        }
        #endregion

        #region 查找节点

        public ActionResult SearchNodes()
        {
            return View();
        }
        #endregion

        #region 鼠标事件

        public ActionResult Mouse()
        {
            return View();
        }
        #endregion

        //单选框和复选框
        #region 复选框基本 勾选取消同时关联父和子节点

        public ActionResult CBBasic()
        {
            return View();
        }
        #endregion

        #region 设置节点不带复选框

        public ActionResult NoCheck()
        {
            return View();
        }
        #endregion

        #region 禁用以及动态禁用复选框

        public ActionResult DisableChk()
        {
            return View();
        }
        #endregion

        //高级功能
        #region 单击展开折叠节点

        public ActionResult ClickExpand()
        {
            return View();
        }
        #endregion

        #region 单选下拉菜单

        public ActionResult SingleSelect()
        {
            return View();
        }
        #endregion

        #region 多选下拉菜单

        public ActionResult MultiSelect()
        {
            return View();
        }
        #endregion

    }
}
