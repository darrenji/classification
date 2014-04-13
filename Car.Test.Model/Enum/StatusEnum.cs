using Car.Test.Model.Extension;

namespace Car.Test.Model.Enum
{
    public enum StatusEnum
    {
        [DisplayEnum("启用")]
        Enable = 0,
        [DisplayEnum("禁用")]
        Disable = 1
    }
}