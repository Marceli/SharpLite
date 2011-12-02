// Type: SharpLite.Domain.EntityWithTypedId`1
// Assembly: SharpLite.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f2f64e823dfaf078
// Assembly location: C:\dev\tools\Sharp-Lite\Example\MyStore\lib\SharpLite.Domain.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Serialization;

namespace SharpLite.Domain
{
    [Serializable]
    public abstract class EntityWithTypedId<TId> : ComparableObject, IEntityWithTypedId<TId>
    {
        #region IEntityWithTypedId<TId> Members

        public virtual bool IsTransient();

        [XmlIgnore]
        public virtual TId Id { get; protected set; }

        #endregion

        public override bool Equals(object obj);
        public override int GetHashCode();
        protected override IEnumerable<PropertyInfo> GetTypeSpecificSignatureProperties();
    }
}
