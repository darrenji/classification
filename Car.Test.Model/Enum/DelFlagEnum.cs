using Car.Test.Model.Extension;

namespace Car.Test.Model.Enum
{
    public enum DelFlagEnum
    {
        [DisplayEnum("正常状态")]
        Normal = 0,
        [DisplayEnum("逻辑删除")]
        Delete = 1,
        [DisplayEnum("物理删除")]
        NoComeback = 2
    }
}