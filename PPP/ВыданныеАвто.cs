//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PPP
{
    using System;
    using System.Collections.Generic;
    
    public partial class ВыданныеАвто
    {
        public int ID { get; set; }
        public Nullable<int> Клиент { get; set; }
        public Nullable<int> Авто { get; set; }
        public Nullable<System.DateTime> Дата_выдачи { get; set; }
        public Nullable<int> Количество_дней { get; set; }
        public Nullable<System.DateTime> Дата_возврата { get; set; }
        public Nullable<decimal> Сумма { get; set; }
        public Nullable<int> Скидка { get; set; }
        public Nullable<int> Штрафы { get; set; }
        public Nullable<decimal> Итого { get; set; }
    
        public virtual Авто Авто1 { get; set; }
        public virtual Клиенты Клиенты { get; set; }
        public virtual Скидки Скидки { get; set; }
        public virtual Штрафы Штрафы1 { get; set; }
    }
}
