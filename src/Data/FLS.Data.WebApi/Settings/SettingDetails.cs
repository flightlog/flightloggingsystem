﻿using System.ComponentModel.DataAnnotations;

namespace FLS.Data.WebApi.Settings
{
    public class SettingDetails
	{
		public SettingScope SettingScope { get; set; }

		[Required]
		[StringLength(250)]
		public string SettingKey { get; set; }

		public string SettingValue { get; set; }
	}
}
