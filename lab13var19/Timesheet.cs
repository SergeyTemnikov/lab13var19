//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lab13var19
{
    using System;
    using System.Collections.Generic;
    
    public partial class Timesheet
    {
        public int Id { get; set; }
        public int TrainNumber { get; set; }
        public string Direction { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan DepartureTime { get; set; }
        public System.TimeSpan ArrivalTime { get; set; }
    }
}
