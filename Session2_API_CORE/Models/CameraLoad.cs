using System;
using System.Collections.Generic;

#nullable disable

namespace Session2_API_CORE.Models
{
    public partial class CameraLoad
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
        public string StateNumber { get; set; }
        public string Img { get; set; }

        public CameraLoad(int id, DateTime? date, bool? status, string stateNumber, string img)
        {
            Id = id;
            Date = date;
            Status = status;
            StateNumber = stateNumber;
            Img = img;
        }
    }
}
