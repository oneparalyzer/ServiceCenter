using System.ComponentModel;

namespace oneparalyzer.ServiceCenter.Domain.Enums
{
    public enum OrderStatus
    {
        [Description("В процессе")]
        InProgress,

        [Description("Выполнено (утверждено)")]
        Confirm,

        [Description("Выполнено")]
        Success,

        [Description("Отказ (на переработке)")]
        Rejection,

        [Description("Отказ (возврат денежных средств)")]
        MoneyRefund,
    }
}
