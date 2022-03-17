using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace drm_NotePad.Models
{

    [Table("informations")]
    public class Information
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("level")]
        public int Level { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("comment")]
        public string Comment { get; set; }
        [Column("audio_path")]
        public string Audio_Path { get; set; }
        [Column("gps_coordinates")]
        public string Gps_Coordinates { get; set; }
        [Column("date")]
        public string Date { get; set; }
        [Column("reliability_level")]
        public int ReliabilityLevel { get; set; }
        [Column("source")]
        public string Source { get; set; }
        [Column("author")]
        public int Author { get; set; }
        [Column("theme")]
        public int Theme { get; set; }
    }
}
