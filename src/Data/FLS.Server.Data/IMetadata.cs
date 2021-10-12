using System;

namespace FLS.Server.Data
{
    public interface IMetadata : ICreatedMetadata
	{
		DateTime? ModifiedOn { get; set; }
		string ModifiedBy { get; set; }
		byte[] RowVersion { get; set; }
	}
}
