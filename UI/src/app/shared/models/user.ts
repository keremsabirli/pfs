import Shared from "./shared";
import Tenant from "./tenant";
import UserGroup from "./usergroup";

export default interface User extends Shared {
    Name: string;
    UserGroups: UserGroup[];
    Tenant: Tenant;
}