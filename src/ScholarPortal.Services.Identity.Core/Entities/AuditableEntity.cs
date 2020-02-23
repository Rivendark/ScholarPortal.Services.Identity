using System;
using Convey.Types;

namespace ScholarPortal.Services.Identity.Core.Entities
{
	public abstract class AuditableEntity : IIdentifiable<Guid>
	{
		public Guid Id { get; set; }
		public DateTime CreatedAt { get; set; }
		//public Employee CreatedBy { get; set; }
		public DateTime? UpdatedAt { get; set; }
		//public Employee UpdatedBy { get; set; }

		public AuditableEntity(Guid id)
		{
			Id = id;
			CreatedAt = DateTime.UtcNow;
			SetUpdatedDate();
		}

		protected virtual void SetUpdatedDate()
			=> UpdatedAt = DateTime.UtcNow;
	}
}