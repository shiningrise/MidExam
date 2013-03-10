using System.Collections.Generic;
using Leafing.Data.Definition;

namespace DbEntryMembership
{
    public class DbEntryRole : DbObjectModel<DbEntryRole>
    {
        [Length(1, 30), Index(UNIQUE = true)]
        public string Name { get; set; }

        [HasAndBelongsToMany(OrderBy = "Id", CrossTableName = "DbEntryMembershipUser_Role")]
        public IList<DbEntryMembershipUser> Users { get; private set; }

        public override bool Equals(object obj)
        {
            var role = obj as DbEntryRole;
            return this.Name == role.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        protected override void OnDeleting()
        {

            base.OnDeleting();
        }
    }
}
