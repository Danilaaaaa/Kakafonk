//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Видео_к_демоэкзамену.DataFilesApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class History
    {
        public int ID { get; set; }
        public int IDTeacher { get; set; }
        public int IDStudent { get; set; }
        public int IDStatus { get; set; }
        public System.DateTime DateEvent { get; set; }
    
        public virtual Status Status { get; set; }
        public virtual Student Student { get; set; }
        public virtual User User { get; set; }
    }
}
