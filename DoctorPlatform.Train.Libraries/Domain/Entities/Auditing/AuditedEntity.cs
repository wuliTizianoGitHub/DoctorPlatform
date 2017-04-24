using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Entities.Auditing
{
    [Serializable]
    public abstract class AuditedEntity : AuditedEntity<int>, IEntity
    {

    }


    [Serializable]
    public abstract class AuditedEntity<TPrimaryKey> : CreationAuditedEntity<TPrimaryKey>, IAudited
    {

    }
}
