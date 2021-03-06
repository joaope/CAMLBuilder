namespace CamlBuilder.Internal.Operators
{
    using System;

    internal class MembershipOperator : Operator
    {
        private readonly MembershipType _membershipType;

        public MembershipOperator(FieldReference fieldRef, MembershipType membershipType)
            : base(OperatorType.Membership, fieldRef)
        {
            this._membershipType = membershipType;
        }

        private string GetMembershipTypeString()
        {
            switch (_membershipType)
            {
                case MembershipType.SpWebAllUsers:
                    return "SPWeb.AllUsers";
                case MembershipType.SpGroup:
                    return "SPGroup";
                case MembershipType.SpWebGroups:
                    return "SPWeb.Groups";
                case MembershipType.CurrentUserGroups:
                    return "CurrentUserGroups";
                case MembershipType.SpWebUsers:
                    return "SPWeb.Users";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override string GetCaml()
        {
            return $@"
<{OperatorTypeString} Type='{GetMembershipTypeString()}'>
    {FieldReference.GetCaml()}
</{OperatorTypeString}>
";
        }
    }
}