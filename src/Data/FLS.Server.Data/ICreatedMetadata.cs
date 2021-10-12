using System;

namespace FLS.Server.Data
{
    public interface ICreatedMetadata
    {
        DateTime CreatedOn { get; set; }
        string CreatedBy { get; set; }
    }
}

