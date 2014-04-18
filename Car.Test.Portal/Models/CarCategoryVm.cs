using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Car.Test.Portal.Models
{
    public class CarCategoryVm
    {
        public int ID { get; set; }

        [Display(Name = "类名")]
        [Required(ErrorMessage = "必填")]
        [StringLength(10, MinimumLength = 2,ErrorMessage = "长度2-10位")]
        public string Name { get; set; }

        [Display(Name = "前缀字母")]
        [Required(ErrorMessage = "必填")]
        [StringLength(1,ErrorMessage = "长度1位")]
        public string PreLetter { get; set; }

        [Display(Name = "所属父级")]
        [Required(ErrorMessage = "必填")]
        public int ParentID { get; set; }

        public System.DateTime SubTime { get; set; }

        [Display(Name = "层级(根节点为0级)")]
        [Required(ErrorMessage = "必填")]
        [Min(1, ErrorMessage = "至少为1")]
        public int Level { get; set; }

        [Display(Name = "是否为页节点")]
        [Required(ErrorMessage = "必填")]
        public bool IsLeaf { get; set; }

        public short Status { get; set; }
        public short DelFlag { get; set; } 
    }
}