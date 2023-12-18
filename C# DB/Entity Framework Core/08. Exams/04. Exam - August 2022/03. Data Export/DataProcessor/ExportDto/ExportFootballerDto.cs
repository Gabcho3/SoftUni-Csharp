using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Footballers.Data.Models.Enums;
using Newtonsoft.Json;

namespace Footballers.DataProcessor.ExportDto
{
    public class ExportFootballerDto
    {
        public string FootballerName { get; set; } = null!;

        public string ContractStartDate { get; set; }

        public string ContractEndDate { get; set; }

        public string BestSkillType { get; set; } = null!;

        public string PositionType { get; set; } = null!;
    }
}
