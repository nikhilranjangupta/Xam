using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorageXamarin.Forms
{
    [Table("Settings")]
    public class SettingsModel
    {
        [PrimaryKey]
        public string Key { get; set; }
        [MaxLength(1000)]
        public string Value { get; set; }

    }
}
