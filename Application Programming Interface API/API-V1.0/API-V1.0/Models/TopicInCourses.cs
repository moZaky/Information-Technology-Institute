using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_V1._0.Models
{
    public class TopicInCourses
    {
        [Key]
        public Guid Topic_Id { get; set; }
        public string Topic_Name { get; set; }
        public Guid Crs_Id { get; set; }
    }
}