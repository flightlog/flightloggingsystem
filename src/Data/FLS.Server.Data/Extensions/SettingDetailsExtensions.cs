using FLS.Common.Validators;
using FLS.Data.WebApi.Settings;
using FLS.Server.Data.DbEntities;

namespace FLS.Server.Data.Extensions
{
    public static class SettingDetailsExtensions
	{
		/// <summary>
		/// Mapping SettingsDetails to Settings
		/// </summary>
		/// <param name="details"></param>
		/// <param name="entity"></param>
		/// <returns></returns>
		public static Setting ToSetting(this SettingDetails details, Setting entity = null)
		{
			details.ArgumentNotNull("details");

			if (entity == null) entity = new Setting();

			entity.SettingKey = details.SettingKey;
			entity.SettingValue = details.SettingValue;
			entity.SettingScope = details.SettingScope;

			return entity;
		}
	}
}
